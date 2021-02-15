using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotateSpeed = 200f;

    public float runSpeed;
    public float walkSpeed;
    float jumpcounter = 0;

    public Rigidbody PlayerRb;
    public Animator PlayerAni;

    public AudioClip[] audiocliparray;
    private AudioSource audiosource;

    public GameObject playerobj;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        Jump();
    }

    void Movement()
    {

        //walking state
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

        //running state
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
            PlayerAni.SetBool("IsRunning", true);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
            PlayerAni.SetBool("IsRunning", true);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
            PlayerAni.SetBool("IsRunning", true);
        }

        //key released
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W))
        {
            PlayerAni.SetBool("IsWalking", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerAni.SetBool("IsRunning", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAni.SetBool("IsWalkingB", false);
        }
        
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpcounter == 0)
        {
            PlayerRb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            PlayerAni.SetTrigger("Jump");
            jumpcounter++;
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAni.SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpcounter = 0;
        }
    }
    /*
    //player follow mouse
    void playerMouse()
    {
        //Plane facing mouse
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerplane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            //rotate by 7 units/sec
            playerobj.transform.rotation = Quaternion.Slerp(playerobj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }   
    }
    */
}
