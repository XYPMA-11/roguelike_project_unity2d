using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypes : MonoBehaviour
{
    public enum ItemType {active, passive}
    public ItemType type;
    public Sprite item;

    public virtual void Use(GameObject player)
    {

    }

    public virtual void Drop()
    {

    }
}
