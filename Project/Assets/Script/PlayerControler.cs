using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    private Rigidbody rb;
    public float speed;
    public static float rotate = 0f;
    private Animator animation;

    public float turnSmootthime = 0.1f;
    float turnsmoothvelocity;

   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();

        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(MoveHorizontal * speed, 0.0f, MoveVertical * speed);

        rb.AddForce(Movement);

        if (Movement.magnitude >= 0.1f)
        {
            float targelAngle = Mathf.Atan2(Movement.x, Movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targelAngle, ref turnsmoothvelocity, turnSmootthime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targelAngle, 0f)* Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animation.SetBool("Walk", true);
        }else { animation.SetBool("Walk", false); }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animation.SetBool("Run", true);
            speed += 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animation.SetBool("Run", false);
            speed -= 2;
        }

    }
}
