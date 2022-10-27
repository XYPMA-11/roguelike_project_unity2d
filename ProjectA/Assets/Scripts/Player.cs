using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public int damage;
    public int hp;
    public GameObject point;
    public LayerMask collisionLayer;
    Rigidbody2D rb;


    private bool faceRight = true;


    private Vector2 size = new Vector2(0.3f, 0.3f);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Attacks();        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb.velocity = new Vector2(deltaX, deltaY);

        if (deltaX > 0 && !faceRight)
        {
            Flip();
        }
        
        if (deltaX < 0 && faceRight)
        {
            Flip();
        }
    }

    void Attacks()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(new Vector2(point.transform.position.x, point.transform.position.y), size, 0f, collisionLayer);

        if (hit.Length > 0)
            Debug.Log(hit[0].gameObject.layer);

        if (Input.GetButtonDown("Fire1") && hit.Length > 0)
        {
            hit[0].GetComponent<Enemy>().GetDamage(damage);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        faceRight = !faceRight;

    }

}
