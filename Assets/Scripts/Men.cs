using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Men : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void LoadScene(int number)
    {
        SceneManager.LoadScene(number);
    }

    public void LoadSceneExit()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
