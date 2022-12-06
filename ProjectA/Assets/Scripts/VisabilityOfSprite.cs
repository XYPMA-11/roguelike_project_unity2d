using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisabilityOfSprite : MonoBehaviour
{

    private Color visability;

    // Start is called before the first frame update
    void Start()
    {
        visability = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visability.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = visability;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visability.a = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = visability;
        }
    }
}
