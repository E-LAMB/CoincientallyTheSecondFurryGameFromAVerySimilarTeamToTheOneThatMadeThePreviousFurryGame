using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspiration : MonoBehaviour
{
    public static int collected_cubes;

    public DialougeScript script_has_0;
    public DialougeScript script_has_1;
    public DialougeScript script_has_2;
    public DialougePlayer my_player;

    public void PickedUp()
    {
        if (collected_cubes == 0)
        {
            collected_cubes++;
            my_player.StealFrom(script_has_0);

        } else if (collected_cubes == 1)
        {
            collected_cubes++;
            my_player.StealFrom(script_has_1);
        }
        else if (collected_cubes == 2)
        {
            collected_cubes++;
            my_player.StealFrom(script_has_2);
        } 
    }
}
