using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{

    public bool can_interact_with;
    public UnityEvent my_event;

    public void InteractionState(bool new_state)
    {
        can_interact_with = new_state;
    }

    private void Update()
    {
        
    }
}
