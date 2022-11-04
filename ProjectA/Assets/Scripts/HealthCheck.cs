using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCheck : MonoBehaviour
{
    public GameObject health;
    public GameObject hp;
    public Player player;

    private GameObject[] arrayHp = new GameObject[5];
    private List<GameObject> listHp = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < player.hp; i++)
        {
            var point = hp.transform.position;
            var vector = new Vector3(point.x + i * 100f, point.y, point.z);
            var newHp = Instantiate(hp, vector, Quaternion.identity, health.transform);
            listHp.Add(newHp);
        }

        Debug.Log(listHp.Count);
    }

    // Update is called once per frame
    void Update()
    {
         if (listHp.Count > player.hp)
         {
            Destroy(listHp[listHp.Count - 1]);
            listHp.RemoveAt(listHp.Count - 1);
         }
         if (listHp.Count < player.hp)
         {
            var i = listHp.Count - 1;
            var point = listHp[i].transform.position;
            var vector = new Vector3(point.x + i * 100f, point.y, point.z);
            var newHp = Instantiate(hp, vector, Quaternion.identity, health.transform);
            listHp.Add(newHp);
        }
    }
}
