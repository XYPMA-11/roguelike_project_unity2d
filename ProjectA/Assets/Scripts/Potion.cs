using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : ItemTypes
{
    public float heal = 3f;

    public override void Use(GameObject player)
    {
        player.GetComponent<Player>().hp += heal;
    }
}
