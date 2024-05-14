using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{

    public bool can_interact_with;
    public UnityEvent my_event;
    public bool look_useless;

    public void AppearUseful()
    {
        look_useless = false;
    }

    public void InteractionState(bool new_state)
    {
        /*
        if (Mind.player_has_control && !DialougePlayer.in_dialouge)
        {
        */
        can_interact_with = new_state;

    }

}
