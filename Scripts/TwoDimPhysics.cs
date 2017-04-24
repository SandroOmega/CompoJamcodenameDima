using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimPhysics : MonoBehaviour {

    public float gravityModifier = 1f;
    public float minGroundNormalY = .6f;


    protected Vector2 targetVelocity;
    Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter2D;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected bool grounded;
    protected Vector2 groundNormal;

    protected const float MinMoveDistance = 0.001f;
    protected const float ShellRadius = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {
        contactFilter2D.useTriggers = false;
        contactFilter2D.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter2D.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }
    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlong = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlong * deltaPosition.x;
        Movement(move, false);
        move = Vector2.up * deltaPosition.y;
        Movement(move, true);
    }

    protected virtual void ComputeVelocity()
    {

    }


    void Movement(Vector2 direct, bool yMovement)
    {
        float distance = direct.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = rb2d.Cast(direct, contactFilter2D, hitBuffer, distance + ShellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }
            for (int i = 0; i < hitBufferList.Count; i++)
            {

                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
               
                float modifiedDistance = hitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }
        rb2d.position= rb2d.position + direct.normalized * distance;

    }
}
