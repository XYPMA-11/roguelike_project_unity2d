using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICooldown : MonoBehaviour
{
    public PlayerController pc;
    
    Image item;
    private float coefficient;
    void Start()
    {
        item = GetComponent<Image>();
        item.type = Image.Type.Filled;
        item.fillMethod = Image.FillMethod.Vertical;
        item.fillOrigin = (int)Image.OriginVertical.Top;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pc.cooldownWeapon > 0 && item.fillAmount == 1)
        {
            item.fillAmount = 0;
            coefficient = 1/ pc.cooldownWeapon;
        }
        if (item.fillAmount != 1)
        {
            item.fillAmount += Time.deltaTime * coefficient;
        }
    }
}
