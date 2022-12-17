using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : ItemTypes
{
    public float heal = 3f;

    public override void Use(GameObject player)
    {
        var p = player.GetComponent<Player>();
        p.hp = p.hp + heal > p.maxhp ? p.maxhp : p.hp + heal;
        Destroy(gameObject);
    }
}
