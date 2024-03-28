using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{

    public GameObject point_a;
    public GameObject point_b;

    public Transform player;

    public LayerMask player_mask;

    public bool was_in_range;
    public float range;

    public bool requires_activation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void UseWarp(string dest)
    {
        if (dest == "b")
        {
            player.position = point_b.transform.position;
        } else if (dest == "a")
        {
            player.position = point_a.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!requires_activation && !was_in_range && (Physics2D.OverlapCircle(point_a.transform.position, range, player_mask)
        || Physics2D.OverlapCircle(point_b.transform.position, range, player_mask)))
        {
            was_in_range = true;
            if (Physics2D.OverlapCircle(point_a.transform.position, range, player_mask))
            {
                player.position = point_b.transform.position;
            } else if (Physics2D.OverlapCircle(point_b.transform.position, range, player_mask))
            {
                player.position = point_a.transform.position;
            }
        } else if (requires_activation && Input.GetKeyDown(KeyCode.Q) && !was_in_range && (Physics2D.OverlapCircle(point_a.transform.position, range, player_mask)
        || Physics2D.OverlapCircle(point_b.transform.position, range, player_mask)))
        {
            was_in_range = true;
            if (Physics2D.OverlapCircle(point_a.transform.position, range, player_mask))
            {
                player.position = point_b.transform.position;
            } else if (Physics2D.OverlapCircle(point_b.transform.position, range, player_mask))
            {
                player.position = point_a.transform.position;
            }
        }

        if (!requires_activation && was_in_range && !(Physics2D.OverlapCircle(point_a.transform.position, range, player_mask)
        || Physics2D.OverlapCircle(point_b.transform.position, range, player_mask)))
        {
            was_in_range = false;
        }

        if (requires_activation && was_in_range)
        {
            was_in_range = false;
        }
        */

        if (!requires_activation && was_in_range && !(Physics2D.OverlapCircle(point_a.transform.position, range, player_mask)
        || Physics2D.OverlapCircle(point_b.transform.position, range, player_mask)))
        {
            was_in_range = false;
        }

        if (!requires_activation && !was_in_range && (Physics2D.OverlapCircle(point_a.transform.position, range, player_mask)
        || Physics2D.OverlapCircle(point_b.transform.position, range, player_mask)))
        {
            if (Physics2D.OverlapCircle(point_a.transform.position, range, player_mask))
            {
                UseWarp("b");
            } else
            {
                UseWarp("a");
            }
            was_in_range = true;
        }
    }
}
