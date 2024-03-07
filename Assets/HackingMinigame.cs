using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingMinigame : MonoBehaviour
{

    public float ringtime;
    public int current_ring;
    public Transform[] rings;

    public AnimationCurve my_curve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ringtime += Time.deltaTime * (1 + current_ring);
        if (current_ring < 3)
        {
            rings[current_ring].localEulerAngles = rings[current_ring].localEulerAngles + new Vector3(0f, 0f, my_curve.Evaluate(ringtime) * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                current_ring += 1;
                ringtime = 0f;
            }
        }
    }
}
