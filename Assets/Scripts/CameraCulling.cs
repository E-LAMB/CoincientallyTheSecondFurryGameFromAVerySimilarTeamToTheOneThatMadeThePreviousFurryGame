using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCulling : MonoBehaviour
{

    public LayerMask not_hack;
    public LayerMask hack;
    public Camera my_cam;

    public GameObject hack_ob;

    // Update is called once per frame
    void Update()
    {
        hack_ob.SetActive(Player.wearing_hackvision);
        if (Player.wearing_hackvision)
        {
            my_cam.cullingMask = hack;
        } else
        {
            my_cam.cullingMask = not_hack;
        }

    }
}
