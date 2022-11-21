using System.Collections;
using UnityEngine;

public class AnimAttack : MonoBehaviour
{
    public float delayDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAnim());
    }

    IEnumerator DestroyAnim()
    {
        yield return new WaitForSeconds(delayDestroy);
        Destroy(gameObject);
    }


}
