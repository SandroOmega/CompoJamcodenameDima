using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3DController : MonoBehaviour {

    public GameObject player;

    public float rotSpeed = 15;
    private float ry;
  

    private Vector3 offset;

    void Start()
    {
        ry = transform.eulerAngles.y;
        offset =  player.transform.position-transform.position;
    }

    void LateUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        if (MoveHorizontal != 0)
        {
            ry += MoveHorizontal * rotSpeed;
        }
        else
        {
            ry += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }
        Quaternion rotation = Quaternion.Euler(0, ry, 0);
        transform.position = player.transform.position -(rotation *offset);
        transform.LookAt(player.transform);
    }
}
