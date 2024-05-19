using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideRobot : MonoBehaviour
{

    public bool has_eyes;
    public bool has_leg;
    public bool has_arm;
    public bool has_heart;
    public string next_part;

    public DialougePlayer player;

    public DialougeScript dia_rejection;
    public DialougeScript dia_eyes;
    public DialougeScript dia_legs;
    public DialougeScript dia_arm;
    public DialougeScript dia_heart;

    public Interactible my_int;

    public TalosCalled talos;

    public Animator credit_anim;

    public void ChooseDialouge()
    {
        if (has_arm)
        {
            player.StealFrom(dia_arm);
            has_arm = false;
            next_part = "arm";
        }
        else if (has_leg && next_part == "arm")
        {
            player.StealFrom(dia_legs);
            has_leg = false;
            next_part = "leg";
        }
        else if (has_eyes && next_part == "leg")
        {
            player.StealFrom(dia_eyes);
            has_eyes = false;
            next_part = "heart";
        }
        else if (has_heart && next_part == "heart")
        {
            player.StealFrom(dia_heart);
            has_heart = false;
        }
        else
        {
            player.StealFrom(dia_rejection);
        }
    }

    public void RepairObjectives()
    {
        talos.ClearTask("Repair your robot");
        if (has_eyes || has_arm || has_heart || has_leg)
        {
            talos.StackObjective("Repair your robot");
        }
    }

    public void LoadCredits()
    {
        credit_anim.SetTrigger("play_anim");
    }

    public void CollectPart(string fixed_part)
    {
        if (fixed_part == "eye") { has_eyes = true; }
        if (fixed_part == "leg") { has_leg = true; }
        if (fixed_part == "arm") { has_arm = true; }
        if (fixed_part == "heart") { has_heart = true; Debug.Log("got heart");}
    }

    private void Update()
    {
        //my_int.can_interact_with = (has_eyes || has_leg || has_arm);
    }
}
