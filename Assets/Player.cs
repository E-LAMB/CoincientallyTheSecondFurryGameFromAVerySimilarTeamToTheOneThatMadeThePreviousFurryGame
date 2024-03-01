using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float maxspeed;
    public float climbingspeed;

    public GameObject groundchecker;
    public LayerMask ground;
    public LayerMask ladder;
    public LayerMask rough;

    public bool is_grounded;
    public bool is_laddered;
    public bool has_special_gloves;

    public Collider2D my_col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, ground);
        is_laddered = Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, ladder);
        if (!is_laddered)
        {
            is_laddered = has_special_gloves && Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, rough);
        }

        Vector3 saved_vel = Vector3.zero;

        my_col.enabled = true;

        if (is_laddered && Input.GetAxisRaw("Vertical") != 0)
        {
            my_col.enabled = false;
            saved_vel = rb.velocity; saved_vel.y = Input.GetAxis("Vertical") * climbingspeed;
            saved_vel.y = Mathf.Clamp(saved_vel.y, climbingspeed * -1f, climbingspeed);
            saved_vel.x = 0f;
            rb.velocity = saved_vel;

        } else
        {
            saved_vel = rb.velocity; saved_vel.x += Input.GetAxis("Horizontal") * speed;
            saved_vel.x = Mathf.Clamp(saved_vel.x, maxspeed * -1f, maxspeed);
            rb.velocity = saved_vel;
        }

    }
}
