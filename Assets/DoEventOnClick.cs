using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoEventOnClick : MonoBehaviour
{

    public UnityEvent on_click;

    private void OnMouseDown()
    {
        on_click.Invoke();
    }
}
