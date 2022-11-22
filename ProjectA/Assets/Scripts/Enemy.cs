using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float hp;
    public GameObject target;

    [HideInInspector]
    public bool getDamage = false;
    private float delayAttack = 2.5f;
    private float distanceAttack = 1.5f;

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
        if (hp <= 0)
        {
            Destroy(gameObject);
        }


        var deltaX = target.transform.position.x - gameObject.transform.position.x;
        var deltaY = target.transform.position.y - gameObject.transform.position.y;

        Vector2 vectorVelocity = new Vector2(deltaX, deltaY);

        if (deltaX > 0 && !faceRight)
        {
            Flip();
        }

        if (deltaX < 0 && faceRight)
        {
            Flip();
        }

        if (!getDamage && distanceAttack < vectorVelocity.magnitude)
        {
            rb.velocity = new Vector2(deltaX, deltaY).normalized * speed;
            delayAttack = 2.5f;
        }
            
        else if (distanceAttack > vectorVelocity.magnitude)
        {
            delayAttack -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (delayAttack <= 0)
            {
                Debug.Log("attack");
                target.GetComponent<PlayerController>().TakeDamage();
                delayAttack = 2.5f;
            }

        }
        if (getDamage)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
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
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;

    }


}
