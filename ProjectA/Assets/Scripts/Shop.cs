using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Item;
    public int price;

    private Sprite spriteItem;
    private Sprite spriteShop;
    // Start is called before the first frame update
    void Start()
    {
        spriteItem = Item.GetComponent<SpriteRenderer>().sprite;
        GetComponentInChildren<SpriteRenderer>().sprite = spriteItem;
    }

    public void Buy()
    {
        //додумать
        GetComponentInChildren<SpriteRenderer>().sprite = null;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Instantiate(Item, gameObject.transform);
    }
}
