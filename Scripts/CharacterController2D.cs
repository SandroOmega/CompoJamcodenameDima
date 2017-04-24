using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterController2D : TwoDimPhysics
{
    [SerializeField]
    private int Score = 0;
    [SerializeField]
    public float maxSpeed = 5;
    [SerializeField]
    public float JumpForce = 5;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="heart")
        {
            Score += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadSceneAsync(2);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadSceneAsync(1);
        }


        Debug.Log(Score.ToString());
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Vector2.right.x;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = JumpForce;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        Debug.Log(Score.ToString());
        targetVelocity = move * maxSpeed;
    }

}
