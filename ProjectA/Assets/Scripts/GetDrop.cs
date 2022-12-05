using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDrop : MonoBehaviour
{
    
    public GameObject drop;

    private Color visability;

    private void Start()
    {
        visability = GetComponent<SpriteRenderer>().color;
    }
    public void TakeDrop(Vector2 vector)
    {
        if (visability.a > 0.5f)
        {
            Instantiate(drop, vector, Quaternion.identity);
            visability.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = visability;
        }
        
    }
}
