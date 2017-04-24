using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDimPhysics : MonoBehaviour {
    public float graityModifier = 1f;
    
    Rigidbody rb;
    protected Vector3 Velocity;
    RaycastHit hit;
    Vector3 Move;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = true;
    }
    // Use this for initialization
    void Start () {
        
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Move.y = 0;
        }
      
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void FixedUpdate()
    {
        Velocity = graityModifier * Physics.gravity * Time.deltaTime;
        Vector3 deltaposition = Velocity * Time.deltaTime;
        Move = Vector3.down * deltaposition.y;
        Movement(Move);
    }
    void Movement(Vector3 direct)
    {
        rb.position=rb.position+direct;
    }

}
