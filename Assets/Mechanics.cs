using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mechanics : MonoBehaviour
{

    public void Event_ChangeScene(int input)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(input);
    }
    public void Event_ChangeScene(string input)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(input);
    }

}
