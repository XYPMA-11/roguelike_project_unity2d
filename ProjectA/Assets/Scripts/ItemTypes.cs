using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypes : MonoBehaviour
{
    public enum ItemType {heal, damage, armor}

    public ItemType type;

    public virtual void Use()
    {

    }
}
