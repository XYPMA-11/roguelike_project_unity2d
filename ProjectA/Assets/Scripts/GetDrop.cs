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
            var check = Random.Range(0, 2);
            for (int i = 0; i < check; i++)
            {
                Debug.Log(check);
                Instantiate(drop, vector, Quaternion.identity);
            }

            visability.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = visability;
        }
        
    }
}
