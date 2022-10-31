using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int hp;
    public GameObject target;

    [HideInInspector]
    public bool getDamage = false;

    private bool faceRight = true;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


            
    }

    private void FixedUpdate()
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }

        var deltaX = target.transform.position.x - gameObject.transform.position.x;
        var deltaY = target.transform.position.y - gameObject.transform.position.y;

        if (deltaX > 0 && !faceRight)
        {
            Flip();
        }

        if (deltaX < 0 && faceRight)
        {
            Flip();
        }

        if (!getDamage)
            rb.velocity = new Vector2(deltaX, deltaY).normalized * speed;
        if (getDamage)
        {
            rb.velocity = new Vector2(gameObject.transform.localScale.x, 0f) * -4f;
            StartCoroutine(ResetDamage());
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        faceRight = !faceRight;

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        getDamage = true;
        
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        getDamage = false;

    }


}
