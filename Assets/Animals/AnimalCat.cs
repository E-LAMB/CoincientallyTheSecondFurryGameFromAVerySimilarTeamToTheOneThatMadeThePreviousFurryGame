using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCat : MonoBehaviour
{

    public GameObject left_bound;
    public GameObject right_bound;

    public GameObject[] burrows;

    public float time_since_burrow;
    public int state;
    /*
    0 = idle
    1 = walk
    2 = burrow
    */

    public float idle_time;

    public Vector3 ideal_position;
    public Transform self;

    public Animator my_anim;

    public float movement_speed;

    public SpriteRenderer my_flipper;

    // Start is called before the first frame update
    void Start()
    {
        ideal_position = self.position;
    }

    public void WarpToIdeal()
    {
        self.position = ideal_position;
        // Debug.Log("Did it");
    }

    // Update is called once per frame
    void Update()
    {
        time_since_burrow = -20f;
        time_since_burrow += Time.deltaTime;
        my_anim.SetInteger("Current State", state);

        if (state == 0)
        {
            idle_time += Time.deltaTime;
            if (idle_time > Random.Range(1f, 200f))
            {
                state = 1;
                ideal_position.x = Random.Range(left_bound.transform.position.x, right_bound.transform.position.x);
                if (time_since_burrow > 15f)
                {
                    state = 2;
                    time_since_burrow = 0f;
                    idle_time = -5f;

                    float dist = 99999f;

                    for (int i = 0; i < burrows.Length; i++)
                    {
                        if (Vector3.Distance(burrows[i].transform.position, self.position) < dist)
                        {
                            ideal_position.x = burrows[i].transform.position.x;
                            dist = Vector3.Distance(burrows[i].transform.position, self.position);
                        }
                    }

                } else
                {
                    state = 1;
                }
            }
        }
        if (state == 1) 
        {
            self.position = Vector3.MoveTowards(self.position, ideal_position, Time.deltaTime * movement_speed);
            if (Vector3.Distance(self.position, ideal_position) < 0.2f)
            {
                state = 0;
                idle_time = 0;
            }
        }
        if (state == 2)
        {
            self.position = Vector3.MoveTowards(self.position, ideal_position, Time.deltaTime * movement_speed);
            if (Vector3.Distance(self.position, ideal_position) < 0.2f)
            {
                int heat = 0;
                bool found = false;

                while (!found && heat < 99)
                {
                    heat += 1;
                    ideal_position.x = burrows[Random.Range(0, burrows.Length)].transform.position.x;
                    if (Vector3.Distance(self.position, ideal_position) > 0.3f)
                    {
                        found = true;
                    }
                }

                state = 0;
                time_since_burrow = 0f;
                idle_time = -5f;
                my_anim.SetTrigger("Burrow");
            }
        }
    }
}
