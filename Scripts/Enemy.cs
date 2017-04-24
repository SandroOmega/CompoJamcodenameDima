using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : TwoDimPhysics {

    // Use this for initialization

    public float time;
    public float Ctime;
    void Start()
    {
        InvokeRepeating("ChangeGrav", time, Ctime );
    }
    
    void ChangeGrav(){
        velocity = Vector2.zero;
        gravityModifier = -gravityModifier;
    }

}
