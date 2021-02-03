using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotateSpeed = 200f;
    public float walkSpeed;
    public Animator PlayerAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {

        
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
            PlayerAni.SetBool("IsWalking", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
            PlayerAni.SetBool("IsWalking", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * walkSpeed);
            PlayerAni.SetBool("IsWalkingB", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
            PlayerAni.SetBool("IsWalking", true);
        }

        //key released
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W))
        {
            PlayerAni.SetBool("IsWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAni.SetBool("IsWalkingB", false);
        }
        
    }
}
