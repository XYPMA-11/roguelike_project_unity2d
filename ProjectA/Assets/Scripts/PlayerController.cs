using UnityEngine;

public class PlayerController : Player
{
    public GameObject point;
    public LayerMask enemyLayer;
    public LayerMask itemLayer;
    Rigidbody2D rb;

    private bool faceRight = true;

    private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attacks();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Dash();
        }

        if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<Collider2D>().IsTouchingLayers(itemLayer))
        {
            Vector3 vector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            Instantiate(weapon, vector, Quaternion.identity);
            weapon = item.GetComponent<Weapon>();
            item.SetActive(false);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var deltaX = Input.GetAxis("Horizontal") * speed;
        var deltaY = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector2(deltaX, deltaY) * Time.deltaTime;

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
        Collider2D[] hit = Physics2D.OverlapBoxAll(new Vector2(point.transform.position.x, point.transform.position.y), weapon.zoneAttack, 0f, enemyLayer);

        if (hit.Length > 0)
        {
            hit[0].GetComponent<Enemy>().TakeDamage(weapon.damage);
        }
    }

    void Dash()
    {
        Vector2 force = new Vector2(transform.localScale.x, 0);
        rb.velocity += force * 10f;
    }

    public void TakeDamage()
    {
        var damage = 1 - armor;
        hp -= damage;
        rb.AddForce(Vector2.left * 1f, ForceMode2D.Impulse);
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
        if (collision.CompareTag("Weapon"))
            item = collision.gameObject;
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
