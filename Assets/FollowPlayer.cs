using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Rigidbody2D my_body;

    public Transform my_pos;
    public Transform my_tar;
    public Vector2 difference;

    public float speed;

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

        my_pos.position = Vector3.MoveTowards(my_pos.position, my_tar.position, (Vector3.Distance(my_pos.position, my_tar.position) / speed));
    }
}
