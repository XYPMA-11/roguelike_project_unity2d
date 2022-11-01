using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : ItemTypes
{
    public int armor;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().armor += armor;
            Destroy(gameObject);
            
        }
    }
}
