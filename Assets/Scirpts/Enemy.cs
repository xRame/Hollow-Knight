using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
            
    }
    void Die()
    {
        anim.SetBool("isDead", true);
        Debug.Log("Enemy died");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
