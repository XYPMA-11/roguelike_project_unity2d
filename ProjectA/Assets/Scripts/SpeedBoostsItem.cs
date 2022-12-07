using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostsItem : ItemTypes
{
    //додумать
    public override void Use(bool activate)
    {
        activate = true;
        Debug.Log("yes");
    }

    public bool Check()
    {
        return true;
    }
}
