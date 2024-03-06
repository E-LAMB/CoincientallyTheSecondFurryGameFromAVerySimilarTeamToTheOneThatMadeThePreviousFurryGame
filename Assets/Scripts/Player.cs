using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float maxspeed;
    public float climbingspeed;
    public Vector2 dashing_speed;

    public GameObject groundchecker;
    public LayerMask ground;
    public LayerMask ladder;
    public LayerMask rough;
    public LayerMask oob;
    public LayerMask checkpoint;

    public bool is_grounded;
    public bool is_laddered;

    public string gained_abilities;

    public static bool wearing_hackvision;

    public bool dashing;
    public float dash_direction;
    public float dash_time;

    public int amount_stick;
    public int amount_rock;
    public int amount_metal;

    public Collider2D my_col;

    public UnityEvent listening_to;

    public Vector3 new_checkpoint;

    public float float_speed;

    public float checkpoint_time;

    public SpriteRenderer walking;
    public SpriteRenderer standing;

    public GameObject drone;

    // Start is called before the first frame update
    void Start()
    {
        listening_to.AddListener(ClearCheckpoint);
    }

    public void ClearCheckpoint()
    {
        new_checkpoint = Vector3.zero;
    }

    public void GainItem(string new_type)
    {
        if (new_type == "stick") {amount_stick += 1;}
        if (new_type == "rock") {amount_rock += 1;}
        if (new_type == "metal") {amount_metal += 1;}
    }

    public void GainAbility(string new_type)
    {
        gained_abilities += new_type + "/";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0) 
        {
            walking.enabled = false;
            standing.enabled = true;

        } else
        {
            walking.enabled = true;
            standing.enabled = false;
            walking.flipX = Input.GetAxisRaw("Horizontal") < 0;
        }

        is_grounded = Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, ground);
        is_laddered = Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, ladder);
        if (!is_laddered)
        {
            is_laddered = gained_abilities.Contains("Climber") && Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, rough);
        }

        Vector3 saved_vel = Vector3.zero;

        if (gained_abilities.Contains("Hack") && Input.GetKeyDown(KeyCode.H))
        {
            wearing_hackvision = !wearing_hackvision;
        }

        if (dash_time > -2f)
        {
            dash_time -= Time.deltaTime;

        } else
        {
            if (gained_abilities.Contains("Dash") && Input.GetKeyDown(KeyCode.LeftShift))
            {
                saved_vel = rb.velocity; saved_vel.x += dash_direction * dashing_speed.x;
                if (is_grounded)
                {
                    saved_vel.y = dashing_speed.y;
                } else
                {
                    saved_vel.y = 0f;
                }
                rb.velocity = saved_vel;
                dash_time = 0f;
                dashing = true;
            }
        }

        my_col.enabled = true;

        if (Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, checkpoint))
        {
            new_checkpoint = gameObject.transform.position;
        }


        if (Vector3.zero != new_checkpoint && Physics2D.OverlapCircle(groundchecker.transform.position, 0.1f, oob))
        {
            checkpoint_time = 3f;
        }

        drone.SetActive(checkpoint_time > 0f);

        if (checkpoint_time < 0f)
        {
            if (!dashing)
            {
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

                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    dash_direction = Input.GetAxisRaw("Horizontal");
                }
            } else
            {
                if (is_grounded && dash_time < -0.5f)
                {
                    dashing = false;
                }
            }
        } else
        {
            my_col.enabled = false;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new_checkpoint, float_speed * Time.deltaTime);
            rb.velocity = Vector2.zero;
            my_col.enabled = false;
            /*
            saved_vel = Vector2.zero;
            saved_vel.y += float_speed;
            rb.velocity = saved_vel;
            if (checkpoint_time < 0.5f)
            {
                gameObject.transform.position = new_checkpoint;
                checkpoint_time = -1f;
                rb.velocity = Vector2.zero;
            }*/
            if (Vector3.Distance(gameObject.transform.position, new_checkpoint) < 0.1f && checkpoint_time > 0.5f)
            {
                checkpoint_time = -1f; 
            }
        }

    }
}