using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideRobot : MonoBehaviour
{

    public bool has_small_eyes;
    public bool has_good_eyes;

    public bool has_leg;
    public bool has_arm;

    public DialougePlayer player;

    public DialougeScript dia_small_eyes;
    public DialougeScript dia_good_eyes;
    public DialougeScript dia_legs;
    public DialougeScript dia_arm;

    public Interactible my_int;

    public void ChooseDialouge()
    {
        
    }

    void EndDialouge(string fixed_part)
    {

    }

    private void Update()
    {
        my_int.can_interact_with = (has_small_eyes || has_good_eyes || has_leg || has_arm);
    }
}
