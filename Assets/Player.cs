using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float maxspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 saved_vel = rb.velocity; saved_vel.x += Input.GetAxis("Horizontal") * speed;
        saved_vel.x = Mathf.Clamp(saved_vel.x, maxspeed * -1f, maxspeed);
        rb.velocity = saved_vel;



    }
}
