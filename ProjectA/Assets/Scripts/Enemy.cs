using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float hp;
    public GameObject target;

    [HideInInspector]
    public bool activate = false;
    [HideInInspector]
    public bool getDamage = false;
    private float delayAttack = 1.5f;
    private float distanceAttack = 1.5f;

    private bool faceRight = true;


    //Rigidbody2D rb;
    Animator anim;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {


            
    }

    private void FixedUpdate()
    {
        if (!activate)
            return;

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

        //agent.remainingDistance можно использовать вместо вектора, но он крашит, так как находится в fixed
        if (vectorVelocity.magnitude < 1.5f && anim.GetInteger("Moving") != 2)
        {
            anim.SetInteger("Moving", 0); 
        }

        if (!getDamage && distanceAttack < vectorVelocity.magnitude)
        {
            agent.SetDestination(target.transform.position);
            anim.SetInteger("Moving", 1);
            delayAttack = 1.5f;
        }
            
        else if (distanceAttack > vectorVelocity.magnitude)
        {
            delayAttack -= Time.deltaTime;
           
            if (delayAttack <= 0)
            {
                Debug.Log("attack");
                anim.SetInteger("Moving", 2);
                delayAttack = 1.5f;

            }

        }

        //переделать 
        if (getDamage)
        {
            Vector2 vec = new Vector2(deltaX, deltaY).normalized;
            agent.velocity = vec * -4f;
            StartCoroutine(ResetDamage());
        }
    }

    void Attack()
    {
        if (distanceAttack > agent.remainingDistance)
            target.GetComponent<PlayerController>().TakeDamage();
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        anim.SetInteger("Moving", 0);
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
