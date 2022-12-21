using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesRooms : MonoBehaviour
{
    public LayerMask layer;
    public int countEnemy;
    private Collider2D[] borders;
    private Collider2D col;
    private ContactFilter2D filter;
    void Start()
    {
        borders = GetComponentsInChildren<Collider2D>();
        col = GetComponentInParent<Collider2D>();
        filter = new ContactFilter2D
        {
            useTriggers = false,
            layerMask = layer,
            useLayerMask = true
        };
    }

    //додумать
    void Update()
    {
        var result = new List<Collider2D>();
        col.OverlapCollider(filter, result);
        Debug.Log(result.Count);
        countEnemy = result.Count;
        foreach (var enemy in result)
            enemy.GetComponent<Enemy>().activate = true;
        if (countEnemy == 0)
        {
            foreach (var b in borders)
                b.enabled = false;
        }
        else
        {
            foreach (var b in borders)
                b.enabled = true;
        }
    }
}
