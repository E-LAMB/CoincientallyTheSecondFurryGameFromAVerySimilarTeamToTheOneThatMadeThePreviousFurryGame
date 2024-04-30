using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalosCalled : MonoBehaviour
{

    public TextMeshProUGUI objective;
    public Animator anim;

    public void NewTask(string new_objective)
    {
        objective.text = new_objective; 
        anim.SetTrigger("PlayObjective");
    }

    public void ClearTask()
    {

    }

    public void ResetTasks()
    {

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
