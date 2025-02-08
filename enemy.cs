using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Transform target;
    private float dist;
    public float moveSpeed;
    public float howClose;

    [Header("Enemy Combat Stats")]
    public int attack;
    public int health;
    
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Agent").transform;
       
    }

   
    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);

        if(dist <= howClose)
        {
            transform.LookAt(target);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
       
        //for attack
        if (dist <= 1.5f)
        {
            
            //do damage
            Attack(target.GetComponent<Unit>()); //novoooooooooooooooo

           
        }

    }
    public void Attack(Unit unitTarget) //Unit target
    {
        unitTarget.TakeDamage(attack);

    }

    public void TakeDamage(int damage) //novoooooooooooooo
    {
        health -= damage;

        // Check if the unit has been defeated
        if (health <= 0)
        {
            Die();
        }
    }

    // Called when the unit's health drops to or below zero
    public void Die()
    {
        // Destroy the unit game object
        Destroy(gameObject);
    }
}
