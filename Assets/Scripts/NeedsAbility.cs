using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsAbility : MonoBehaviour
{
    public Interactible inter;
    public Player player;
    public string req;

    private void Update()
    {
        inter.can_interact_with = (player.gained_abilities.Contains(req));
    }
}
