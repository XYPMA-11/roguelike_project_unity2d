using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : ItemTypes
{
    public int armor;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().armor += armor;
            Destroy(gameObject);
            
        }
    }
}
