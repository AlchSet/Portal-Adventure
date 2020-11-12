using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Npc : MonoBehaviour
{
    [TextArea]
    public string[] messages;

    int msgIndex;

    public delegate void Action();

    public Action OnTalk;

    public Action OnExitTalk;

    bool isTalking;


    public GameObject msgUI;

    public TextMeshProUGUI txt;


    public DialogueTreeContrainer DialogueTree;

    MessageAndSignal msgSig;


    public UnityEvent OnEnd;

    public UnityEvent OnStart;


    public bool isShop;

    public bool useDialogueTree = true;

    public void Talk(Action action, Action exit)
    {
        Time.timeScale = 0;
        OnExitTalk = exit;
        action();
        //isTalking = true;
        msgUI.SetActive(true);

        OnStart.Invoke();

        //messages = DialogueTree.state.GetMessage();
        if (!isShop)
        {

            if (useDialogueTree)
            {
                msgSig = DialogueTree.state.GetMessageAndSignal();

                messages = msgSig.message;
            }
            else
            {
                msgSig = new MessageAndSignal();
                msgSig.message = messages;
                msgSig.code = 0;
            }
        }
        else
        {


        }

        UpdateMsgText();
        StartCoroutine(Delay());

    }


    private void Update()
    {




        if (!isShop)
        {

            if (isTalking)
            {


                if (msgIndex < messages.Length)
                {
                    //Debug.Log(messages[msgIndex]);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        msgIndex++;
                        UpdateMsgText();
                    }
                }
                else
                {
                    isTalking = false;
                    Time.timeScale = 1;
                    OnExitTalk();
                    msgIndex = 0;

                    switch (msgSig.code)
                    {
                        case 0:

                            break;


                        case 1:

                            OnEnd.Invoke();
                            Debug.Log("Unlock Portal");

                            break;
                    }

                    Debug.Log("END MSG");
                    msgUI.SetActive(false);
                }
            }
            else
            {

            }




        }
        else
        {
            if(isTalking)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    isTalking = false;
                    Time.timeScale = 1;
                    OnExitTalk();
                    msgIndex = 0;
                    msgUI.SetActive(false);
                    OnEnd.Invoke();
                }
            }
           
        }

    }


    public void UpdateMsgText()
    {
        txt.text = messages[msgIndex];

    }


    IEnumerator Delay()
    {
        yield return new WaitForEndOfFrame();
        isTalking = true;
    }

}
