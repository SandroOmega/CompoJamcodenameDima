using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character3Dcontrolle : MonoBehaviour {
    Rigidbody rb;
  
    Vector3 Velocity;
    public float Score;
    public Transform target;
    public float maxVelocity;
    public float rotspeed = 15f;
    public float JumpSpeed = 1000f;
    [SerializeField]bool grounded;
    private void OnEnable()
    {
      
        rb = GetComponent<Rigidbody>();
    }
    
    // Use this for initialization
    void Start () {
        grounded = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "heart")
        {
            Destroy(other.gameObject);
            Score += 5;
            
        }
        if (other.gameObject.tag=="Finish")
        {
            if (Score == 100)
                SceneManager.LoadScene("Epilogue");
            else SceneManager.LoadScene("Bad");
        }
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Test3D");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 movement = Vector3.zero;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            movement.x = moveHorizontal*maxVelocity;
            movement.z = moveVertical*maxVelocity;
            movement = Vector3.ClampMagnitude(movement, maxVelocity);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);

            target.rotation = tmp;

            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotspeed * Time.deltaTime);
        }

            if (Input.GetButtonDown("Jump")&& grounded)
            {
                movement.y = JumpSpeed;
                
            }else if (Input.GetButtonUp("Jump"))
            {
                while(movement.y>0)
                movement.y = movement.y * Physics.gravity.y*Time.deltaTime;
            }
       

        movement *= Time.deltaTime;
        Movement(movement);
        
        
    }
    private void FixedUpdate()
    {
        
    }


    void Movement(Vector3 move)
    {

        rb.position = rb.position + move;
    }
}
