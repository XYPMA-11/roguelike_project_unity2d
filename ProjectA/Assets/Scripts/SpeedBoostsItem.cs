using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostsItem : ItemTypes
{
    //додумать
    private GameObject player;
    public override void Use(GameObject player)
    {
        player.GetComponent<PlayerController>().canDash = true;
        this.player = player;
    }
    public override void Drop()
    {
        player.GetComponent<PlayerController>().canDash = false;
    }

}
