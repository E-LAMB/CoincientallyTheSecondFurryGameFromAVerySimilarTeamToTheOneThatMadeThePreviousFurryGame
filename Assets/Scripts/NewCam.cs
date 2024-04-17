using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class NewCam : MonoBehaviour
{
    public Transform player;

    public Collider2D boundaries;
    public Vector3 rep;
    public Transform showoff;

    public float my_size;

    public static string taken_cam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (gameObject.name == "Starter Bound")
        {
            BecomeChosen();
        }
    }

    public void BecomeChosen()
    {
        taken_cam = gameObject.name;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = my_size;
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        rep = player.position;

        if (rep.x > gameObject.transform.position.x + (boundaries.offset.x + (boundaries.bounds.extents.x)))
        {
            rep.x = gameObject.transform.position.x + (boundaries.offset.x + (boundaries.bounds.extents.x));
        }
        if (rep.x < gameObject.transform.position.x - (boundaries.offset.x + (boundaries.bounds.extents.x)))
        {
            rep.x = gameObject.transform.position.x - (boundaries.offset.x + (boundaries.bounds.extents.x));
        }
        rep.y = gameObject.transform.position.y;

        rep.z = -10f;

        if (gameObject.name == taken_cam)
        {
            showoff.position = rep;
        }

    }
}
