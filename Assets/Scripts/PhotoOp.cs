using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoOp : MonoBehaviour
{

    public string my_name;
    public bool avaliable;

    public void Capture()
    {
        if (avaliable)
        {
            Mind.all_photos += my_name;
            avaliable = false;
            this.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
