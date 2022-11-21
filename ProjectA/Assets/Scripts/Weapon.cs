using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float delayAttack;
    public Vector2 zoneAttack;
    public int damage;
    public GameObject animAttack;

    public void Use()
    {
        Destroy(gameObject);
    }

}
