using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : ItemTypes
{
    public float boostHp;
    public override void Use(GameObject player)
    {
        player.GetComponent<Player>().maxhp += boostHp;
        Destroy(gameObject);
    }
}
