using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float gameend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameend > 0) { gameend += Time.deltaTime; }
        if (gameend > 10f) { Application.Quit(); }
    }
}
