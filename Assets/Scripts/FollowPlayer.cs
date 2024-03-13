using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform my_pos;
    public Transform my_tar;
    public Transform alt_tar;

    public float speed;
    public float checkpoint_speed;
    public float the_div;
    public bool moving;
    public float current_speed;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float calc = (my_pos.position.x - my_tar.position.x);
        if (0f > calc) { calc = calc * -1f; }
        difference.x = 0f;
        if (calc > 0.5f) 
        { 
            if (my_pos.position.x < my_tar.position.x) { difference.x = 1f; } else { difference.x = -1f; } 
        }

        calc = (my_pos.position.y - my_tar.position.y);
        if (0f > calc) { calc = calc * -1f; }
        difference.y = 0f;
        if (calc > 0.5f)
        {
            if (my_pos.position.y < my_tar.position.y) { difference.y = 1f; } else { difference.y = -1f; }
        }

        my_body.velocity = difference * Time.deltaTime * speed;
        */

        /*
        if (Vector3.Distance(my_pos.position, my_tar.position) > 3f && !moving)
        {
            moving = true;
        }
        if (Vector3.Distance(my_pos.position, my_tar.position) < 0.5f && moving)
        {
            moving = false;
        }
        */

        if (moving) //(Vector3.Distance(my_pos.position, my_tar.position) / speed)
        {
            if (player.checkpoint_time > 0f)
            {
                my_pos.position = Vector3.MoveTowards(my_pos.position, alt_tar.position, (Vector3.Distance(my_pos.position, alt_tar.position) / checkpoint_speed));
            }
            else
            {
                speed = (Vector3.Distance(my_pos.position, my_tar.position) / the_div);
                if (speed < current_speed) { current_speed -= Time.deltaTime; } else { current_speed += Time.deltaTime; }
                if (speed < 0.0001f && speed > -0.0001) { current_speed = 0f; }
                my_pos.position = Vector3.MoveTowards(my_pos.position, my_tar.position, current_speed);
            }
        }

    }
}
