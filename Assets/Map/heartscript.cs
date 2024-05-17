using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartscript : MonoBehaviour
{
    public static int collected_shards;

    public DialougeScript script_has_0;
    public DialougeScript script_has_1;
    public DialougeScript script_has_2;
    public DialougePlayer my_player;

    public void Start()
    {
        collected_shards = 0;
    }

    public void PickedUp()
    {
        if (collected_shards == 0)
        {
            collected_shards++;
            my_player.StealFrom(script_has_0);

        }
        else if (collected_shards == 1)
        {
            collected_shards++;
            my_player.StealFrom(script_has_1);
        }
        else if (collected_shards == 2)
        {
            collected_shards++;
            my_player.StealFrom(script_has_2);
        }
    }
}
