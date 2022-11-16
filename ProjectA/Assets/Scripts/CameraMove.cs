using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    private BoxCollider2D borderScreen;
    // Start is called before the first frame update
    void Start()
    {
        borderScreen = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.transform.position.x - gameObject.transform.position.x > (borderScreen.size.x / 2))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 18, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            else if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) > (borderScreen.size.x / 2))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 18, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            else if (player.transform.position.y > gameObject.transform.position.y)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z);
            }

            else if (player.transform.position.y < gameObject.transform.position.y)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 10, gameObject.transform.position.z);
            }
        }
    }
}
