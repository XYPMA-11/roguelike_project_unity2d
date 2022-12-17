using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : Player
{
    public GameObject point;
    public LayerMask enemyLayer;
    public LayerMask itemLayer;
    public LayerMask placeLayer;
    public GameObject checkItem;
    public ArmorItem currentArmor;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    Rigidbody2D rb;
    Animator anim;

    private float angleAttack = 0f;
    private Weapon currentWeapon;
    private SpriteRenderer spriteCurrent;

    [HideInInspector]
    public bool canDash = false;
    private bool isDashing = false;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;
    private float dashingPower = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentWeapon = Instantiate(weapon);
        currentWeapon.gameObject.SetActive(false);
        spriteCurrent = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Debug.Log(canDash);
        if (isDashing)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attacks();
        }

        if (activeItem != null && Input.GetButtonDown("Jump"))
        {
            //StartCoroutine(Dash());
            activeItem.GetComponent<ItemTypes>().Use(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<Collider2D>().IsTouchingLayers(itemLayer))
        {
            Vector3 vector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            var filter = new ContactFilter2D
            {
                useTriggers = true,
                layerMask = itemLayer,
                useLayerMask = true
            };
            Collider2D[] hit = new Collider2D[1];
            gameObject.GetComponent<Collider2D>().OverlapCollider(filter, hit);

            if (hit[0].CompareTag("Weapon"))
            {
                currentWeapon.transform.position = vector;
                currentWeapon.gameObject.SetActive(true);
                weapon = hit[0].GetComponent<Weapon>();
                hit[0].gameObject.SetActive(false);
                currentWeapon = weapon;
            }

            else
            {
                //доделать
                if (hit[0].GetComponent<ItemTypes>().type == ItemTypes.ItemType.active)
                {
                    if (activeItem == null)
                    {
                        hit[0].gameObject.SetActive(false);
                        activeItem = hit[0].gameObject;
                    }
                    else
                    {
                        activeItem.transform.position = point.transform.position;
                        activeItem.GetComponent<ItemTypes>().Drop();
                        activeItem.gameObject.SetActive(true);

                        hit[0].gameObject.SetActive(false);
                        activeItem = hit[0].gameObject;

                    }
                }

                else
                {
                    if (passiveItem == null)
                    {
                        hit[0].gameObject.SetActive(false);
                        passiveItem = hit[0].gameObject;
                    }
                    else
                    {
                        passiveItem.transform.position = point.transform.position;
                        passiveItem.GetComponent<ItemTypes>().Drop();
                        passiveItem.gameObject.SetActive(true);

                        hit[0].gameObject.SetActive(false);
                        passiveItem = hit[0].gameObject;

                    }
                }


            }
        }

        if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<Collider2D>().IsTouchingLayers(placeLayer))
        {
            Vector3 vec = new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x, gameObject.transform.position.y, 0);
            
            //переместить в start (или в отдельную функию скорее всего)
            var filter = new ContactFilter2D
            {
                useTriggers = true,
                layerMask = placeLayer,
                useLayerMask = true
            };
            Collider2D[] hit = new Collider2D[1];
            gameObject.GetComponent<Collider2D>().OverlapCollider(filter, hit);
            hit[0].GetComponent<GetDrop>().TakeDrop(vec);
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        var deltaX = Input.GetAxis("Horizontal") * speed;
        var deltaY = Input.GetAxis("Vertical") * speed;
        var move = new Vector2(deltaX, deltaY);

 
        rb.velocity = Vector2.ClampMagnitude(move, speed) * Time.deltaTime;

        if (deltaX > 0)
        {
            Flipe(rightSprite, 0.8f, 0f, 0f, 1, 3);
        }

        if (deltaX < 0)
        {
            Flipe(leftSprite, -0.8f, 0f, 0f, -1, 1);
        }

        if (deltaY > 0)
        {
            Flipe(upSprite, 0f, 0.8f, 90f, 1, 2);
        }

        if (deltaY < 0)
        {
            Flipe(downSprite, 0f, -0.8f, 90f, -1, 0);
        }

        if (deltaX == 0 && deltaY == 0)
        {
            anim.enabled = false;
        }



    }

    void Attacks()
    {
        Debug.Log("ata");
        Instantiate(weapon.animAttack, point.transform.position, weapon.animAttack.transform.rotation);
        Collider2D[] hit = Physics2D.OverlapBoxAll(new Vector2(point.transform.position.x, point.transform.position.y), weapon.zoneAttack, angleAttack, enemyLayer);
        if (hit.Length > 0)
        {
            hit[0].GetComponent<Enemy>().TakeDamage(weapon.damage);
        }
    }

    public void ActivateDash()
    {
        if (canDash)
        StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        canDash = false;
        var vectorDash = new Vector2(point.transform.position.x - gameObject.transform.position.x, point.transform.position.y - gameObject.transform.position.y);
        rb.velocity = vectorDash * dashingPower;
        isDashing = true;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void TakeDamage()
    {
        var damage = 1 - armor;
        hp -= damage;
        rb.AddForce(Vector2.left * 1f, ForceMode2D.Impulse);
    }

    // поворот спрайта, анимации атаки и запуск анимации движения: x, y - координаты персонажа; angle - необходимый уровень поворота; scaleX - направление игрока; move - запуск анимации
    void Flipe(Sprite sprite, float x, float y, float angle, int scaleX, int move)
    {
        spriteCurrent.sprite = sprite;
        point.transform.localPosition = new Vector3(x, y, 0f);
        angleAttack = angle;
        weapon.animAttack.transform.rotation = Quaternion.Euler(0, 0, angle);
        weapon.animAttack.transform.localScale = new Vector3(scaleX, 1, 1);
        anim.enabled = true;
        anim.SetInteger("Moving", move);
    }

    // костыль, переделать на overlap
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Weapon"))
    //        item = collision.gameObject;
    //}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3(point.transform.position.x, point.transform.position.y, 0);
        var x = weapon.zoneAttack.x;
        var y = weapon.zoneAttack.y;
        Vector3 size = new Vector3(x, y, 0);
        size = Quaternion.Euler(0, 0, angleAttack) * size;
 
        Gizmos.DrawWireCube(center, size);
    }
}
