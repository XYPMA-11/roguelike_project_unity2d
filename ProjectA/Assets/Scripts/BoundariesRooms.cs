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
    private Vector3 position;
    private List<Collider2D> result = new List<Collider2D>();

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

    void Update()
    {
        if (position != transform.position)
        {
            col.OverlapCollider(filter, result);
            countEnemy = result.Count;
            foreach (var enemy in result)
                enemy.GetComponent<Enemy>().activate = true;
        }

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
