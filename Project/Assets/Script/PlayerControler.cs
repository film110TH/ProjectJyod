using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public static float rotate = 0f;
    private Animator animation;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
        
    }

    void Update()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(MoveHorizontal * speed, 0.0f, MoveVertical * speed);

        rb.AddForce(Movement);

        if (Input.GetKey(KeyCode.A))
        {
            animation.SetBool("WalkA", true);
            if (rotate != -90f)
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                rotate = -90;

            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            animation.SetBool("WalkD", true);
            if (rotate != 90f)
            {

                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                rotate = 90;

            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            animation.SetBool("WalkS", true);
            if (rotate != 180f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                rotate = 180;

            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            animation.SetBool("WalkW", true);
            if (rotate != 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                rotate = 0;

            }
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            
            if (rotate != 45f)
            {
                transform.rotation = Quaternion.Euler(0f, 45f, 0f);
                rotate = 45f;

            }
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            if (rotate != 135f)
            {
               
                transform.rotation = Quaternion.Euler(0f, 135f, 0f);
                rotate = 135f;

            }
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            if (rotate != 225f)
            {
                
                transform.rotation = Quaternion.Euler(0f, 225f, 0f);
                rotate = 225f;

            }
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            if (rotate != 315f)
            {
                
                transform.rotation = Quaternion.Euler(0f, 315f, 0f);
                rotate = 315f;

            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animation.SetBool("WalkW",false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animation.SetBool("WalkA", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animation.SetBool("WalkS", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animation.SetBool("WalkD", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animation.SetBool("Run", true);
            speed += 20;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animation.SetBool("Run", false);
            speed -= 20;
        }

        
    }
}
