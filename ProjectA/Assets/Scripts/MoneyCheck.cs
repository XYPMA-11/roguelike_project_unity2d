using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCheck : MonoBehaviour
{
    public Player player;
    public Text countMoney;
    public Image coins;
    // Start is called before the first frame update
    void Start()
    {
        countMoney.text = player.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (countMoney.text != player.money.ToString())
        {
            coins.GetComponent<Animator>().SetTrigger("takesCoins");
            countMoney.text = player.money.ToString();
        }
    }
}
