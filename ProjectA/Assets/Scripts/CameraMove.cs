using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    private Vector3 startPoint;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(startPoint);
            Debug.Log(player.transform.position.x - startPoint.x);
            Debug.Log(player.transform.position.y - startPoint.y);
            if (Mathf.Abs(player.transform.position.x - startPoint.x) >= 13)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 18, gameObject.transform.position.y, gameObject.transform.position.z);
                startPoint = player.transform.position;
            }
            else if (Mathf.Abs(player.transform.position.x - startPoint.x) <= 2)
            {
                if (player.transform.position.x - startPoint.x < 0)
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - 18, gameObject.transform.position.y, gameObject.transform.position.z);
                else
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + 18, gameObject.transform.position.y, gameObject.transform.position.z);
                startPoint = player.transform.position;
            }
            else if (Mathf.Abs(player.transform.position.y - startPoint.y) >= 5)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z);
                startPoint = player.transform.position;
            }
            else if (Mathf.Abs(player.transform.position.y - startPoint.y) <= 4)
            {
                if (player.transform.position.y - startPoint.y < 0)
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 10, gameObject.transform.position.z);
                else
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z);
                startPoint = player.transform.position;
            }
        }
    }

}
