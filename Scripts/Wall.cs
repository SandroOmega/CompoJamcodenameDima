using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour {

    Rigidbody2D rb2d; 
    RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    // Use this for initialization
    float distance = 0.1f;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HitRaycast();
	}
    void HitRaycast()
    {
        int count = rb2d.Cast(Vector2.left, hitBuffer, distance);
        for (int i = 0; i < count; i++)
        {
            if (hitBuffer[i].transform.gameObject.tag == "Player")
                SceneManager.LoadScene(1);
        }
    }
}
