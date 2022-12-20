using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public Sprite smallCoin;
    public Sprite mediumCoin;
    public Sprite bigCoin;

    private int count;

    void Start()
    {
        var i = Random.Range(0, 15);

        if (i < 6)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = smallCoin;
            count = 5;
        }
        else if (i < 11)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = mediumCoin;
            count = 10;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bigCoin;
            count = 15;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().money += count;
            Destroy(gameObject);
        }
    }
}
