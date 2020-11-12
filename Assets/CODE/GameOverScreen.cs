using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Damageable player;
    CanvasGroup group;


    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        player.OnDeath.AddListener(GameOverSequence);

        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
    }



    private void Update()
    {
        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void  GameOverSequence()
    {
        gameOver = true;
        StartCoroutine(StartGameOverSeq());
    }



    IEnumerator StartGameOverSeq()
    {
        group.alpha = 1;
        yield return null;
    }

}
