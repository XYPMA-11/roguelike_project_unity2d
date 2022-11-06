using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCheck : MonoBehaviour
{
    public Player player;

    private Text countMoney;
    // Start is called before the first frame update
    void Start()
    {
        countMoney = gameObject.GetComponent<Text>();
        countMoney.text = player.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (countMoney.text != player.money.ToString())
            countMoney.text = player.money.ToString();
    }
}
