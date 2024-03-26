using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMole : MonoBehaviour
{

    public float time_since_burrow;

    public bool is_burrowed;
    public Transform self;

    public Animator my_anim;

    public CursorControl cursor;
    public PhotoOp photo;

    public float check_distance;
    public LayerMask playerLayer;

    void Start()
    {
        cursor = Object.FindObjectOfType<CursorControl>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(self.position, check_distance, playerLayer)) 
        {
            time_since_burrow = 6f; 
        }

        if (time_since_burrow > 0f) { time_since_burrow -= Time.deltaTime; }
        is_burrowed = (time_since_burrow > 1f);

        my_anim.SetBool("Burrowed", is_burrowed);
        photo.blocked = is_burrowed;
    }
}
