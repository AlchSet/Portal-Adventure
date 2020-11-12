using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Controller2D : MonoBehaviour
{
    public enum Direction { North, South, East, West }


    public Vector2 InputVel;
    public Vector2 LastInputVel;
    public Rigidbody2D body;
    public float speed = 3;

    public Vector2 FacingDirection;
    public Direction faceDir = Direction.South;

    public bool isMoving;

    public bool freeze;

    public bool move = true;


    public bool lockDirection;

    


    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        LastInputVel = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputVel.sqrMagnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        Vector2 dirVel = new Vector2(Mathf.Round(InputVel.x), Mathf.Round(InputVel.y));



        if (!lockDirection)
        {
            if (Mathf.Abs(dirVel.x) > 0 && dirVel.y == 0)
            {
                //Debug.Log("A");

                FacingDirection = new Vector2(Mathf.Sign(LastInputVel.x), 0);



            }
            else if (Mathf.Abs(dirVel.y) > 0 && dirVel.x == 0)
            {

                FacingDirection = new Vector2(0, Mathf.Sign(LastInputVel.y));

            }
            else if (Mathf.Abs(dirVel.x) > 0 && Mathf.Abs(dirVel.y) > 0)
            {
                if (faceDir == Direction.North && dirVel.y < 0)
                {
                    FacingDirection = new Vector2(0, Mathf.Sign(LastInputVel.y));

                    //Debug.Log("WALKBACKWArDs");




                }
                if (faceDir == Direction.South && dirVel.y > 0)
                {
                    FacingDirection = new Vector2(0, Mathf.Sign(LastInputVel.y));

                    ////Debug.Log("WALKBACKWArDs");




                }

                if (faceDir == Direction.East && dirVel.x < 0)
                {
                    FacingDirection = new Vector2(0, Mathf.Sign(LastInputVel.y));

                    ////Debug.Log("WALKBACKWArDs");




                }
                if (faceDir == Direction.West && dirVel.x > 0)
                {
                    FacingDirection = new Vector2(0, Mathf.Sign(LastInputVel.y));

                    ////Debug.Log("WALKBACKWArDs");




                }



            }

            if (FacingDirection.normalized == Vector2.right)
            {
                faceDir = Direction.East;
                //sword.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            else if (FacingDirection.normalized == Vector2.left)
            {
                faceDir = Direction.West;
                //sword.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (FacingDirection.normalized == Vector2.down)
            {
                faceDir = Direction.South;
                //sword.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (FacingDirection.normalized == Vector2.up)
            {
                faceDir = Direction.North;
                //sword.transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }




    }



    private void FixedUpdate()
    {
        if (move)
        {
            Vector2 nPos = (Vector2)transform.position + InputVel * speed * Time.deltaTime;
            body.MovePosition(nPos);
        }
    }

    public void SetInputVel(Vector2 input)
    {
        if (!freeze)
        {
            InputVel = input;

            if (InputVel.sqrMagnitude > 0)
            {
                LastInputVel = input;
            }
        }
        else
        {
            InputVel = Vector2.zero;
        }

    }
}
