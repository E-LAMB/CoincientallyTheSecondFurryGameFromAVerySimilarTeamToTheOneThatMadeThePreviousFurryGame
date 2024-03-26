using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoOp : MonoBehaviour
{

    public string my_name;
    public bool avaliable;
    public bool blocked;

    public void Capture()
    {
        if (avaliable && !blocked)
        {
            Mind.all_photos += my_name;
            avaliable = false;
            Debug.Log("Working!");
            Debug.Log(Mind.all_photos);
            this.enabled = false;
        }
    }
}
