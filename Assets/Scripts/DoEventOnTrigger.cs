using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoEventOnTrigger : MonoBehaviour
{

    public UnityEvent on_enter;
    public UnityEvent on_leave;

    public string filter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == filter)
        {
            on_enter.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == filter)
        {
            on_leave.Invoke();
        }
    }
    
}
