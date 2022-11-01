using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    public GameObject point;
    public LayerMask collisionLayer;
    Rigidbody2D rb;

    private bool faceRight = true;

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
        Collider2D[] hit = Physics2D.OverlapBoxAll(new Vector2(point.transform.position.x, point.transform.position.y), weapon.zoneAttack, 0f, collisionLayer);

        if (hit.Length > 0)
            Debug.Log(hit[0].gameObject.layer);

        if (Input.GetButtonDown("Fire1") && hit.Length > 0)
        {
            hit[0].GetComponent<Enemy>().TakeDamage(weapon.damage);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        faceRight = !faceRight;

    }

    void CollectItem(ItemTypes item)
    {
        Debug.Log(item.type);

        Destroy(item.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3(point.transform.position.x, point.transform.position.y, 0);
        var x = weapon.zoneAttack.x;
        var y = weapon.zoneAttack.y;
        Vector3 size = new Vector3(x, y, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
