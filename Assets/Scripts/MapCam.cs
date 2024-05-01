using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCam : MonoBehaviour
{

    public Transform player_pos;
    public Transform my_pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp_standin = my_pos.position;
        temp_standin.y = player_pos.position.y;
        my_pos.position = temp_standin;
    }
}
