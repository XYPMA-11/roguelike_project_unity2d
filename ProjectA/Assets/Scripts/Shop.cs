using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject Item;
    public int price;

    private Sprite spriteItem;
    private Text cost;
    private SpriteRenderer activeSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteItem = Item.GetComponent<SpriteRenderer>().sprite;
        activeSprite = GetComponentInChildren<SpriteRenderer>();
        activeSprite.sprite = spriteItem;
        cost = gameObject.GetComponentInChildren<Text>();
        cost.text = price.ToString();
    }

    public void Buy()
    {
        //додумать
        activeSprite.sprite = null;
        gameObject.GetComponent<Collider2D>().enabled = false;
        cost.gameObject.SetActive(false);
        Instantiate(Item, gameObject.transform);
    }
}
