using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostsItem : ItemTypes
{
    //додумать
    private GameObject player;
    public override void Use(GameObject player)
    {
        if (this.player == null)
            player.GetComponent<PlayerController>().canDash = true;
        this.player = player;
        player.GetComponent<PlayerController>().ActivateDash();
    }
    public override void Drop()
    {
        if (player != null)
            player.GetComponent<PlayerController>().canDash = false;
        player = null;
    }

}
