using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    protected float maxHealth;
    protected float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
    }

    protected virtual void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
