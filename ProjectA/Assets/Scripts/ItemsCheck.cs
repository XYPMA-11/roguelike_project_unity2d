using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCheck : MonoBehaviour
{

    public GameObject itemsPannel;
    public GameObject weaponPannel;
    public GameObject armorPannel;
    public GameObject activePannel;
    public GameObject passivePannel;
    public Player player;

    private Weapon weapon;
    private float armor;
    // Start is called before the first frame update
    void Start()
    {
        weapon = player.weapon.GetComponent<Weapon>();
        armor = player.armor;
        weaponPannel.GetComponentInChildren<Text>().text = weapon.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (armor != player.armor)
        {
            armor = player.armor;
            armorPannel.transform.GetChild(0).GetComponent<Image>().sprite = player.GetComponent<PlayerController>().currentArmor.item;
            armorPannel.transform.GetChild(0).gameObject.SetActive(true);


        }

        if (weapon != null && weapon != player.weapon.GetComponent<Weapon>())
        {
            weapon = player.weapon.GetComponent<Weapon>();
            weaponPannel.GetComponentInChildren<Text>().text = weapon.name;
        }
    }
}
