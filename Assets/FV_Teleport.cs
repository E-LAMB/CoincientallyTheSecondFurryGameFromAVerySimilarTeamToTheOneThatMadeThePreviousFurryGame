using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FV_Teleport : MonoBehaviour
{

    public Transform output_location;

    public bool proximity_activated;
    public LayerMask player_layer;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (proximity_activated) 
        {
            if (Physics2D.OverlapCircle(gameObject.transform.position, 0.5f, player_layer))
            {
                player.position = output_location.position;
            }
        }
    }
}
