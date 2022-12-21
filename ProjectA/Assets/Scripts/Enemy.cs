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
    private float delayAttack = 2.5f;
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

        if (agent.velocity == Vector3.zero)
        {
            anim.SetInteger("Moving", 0);
        }
        //Debug.Log(agent.remainingDistance);

        if (!getDamage && distanceAttack < vectorVelocity.magnitude)
        {
            agent.SetDestination(target.transform.position);
            anim.SetInteger("Moving", 1);
            delayAttack = 2.5f;
        }
            
        else if (distanceAttack > vectorVelocity.magnitude)
        {
            delayAttack -= Time.deltaTime;
            agent.velocity = Vector2.zero;
            

            if (delayAttack <= 0)
            {
                Debug.Log("attack");
                target.GetComponent<PlayerController>().TakeDamage();
                delayAttack = 2.5f;
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
