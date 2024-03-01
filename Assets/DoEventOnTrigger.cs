using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoEventOnTrigger : MonoBehaviour
{

    public UnityEvent on_enter;
    public string filter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerAttempt");
        if (other.tag == filter)
        {
            Debug.Log("Succeed");
            on_enter.Invoke();
        }
    }
    
}
