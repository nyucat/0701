using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : CharacterData
{

    public UnityEvent<float, float> HP_change; 
    // Start is called before the first frame update
    void Start()
    {
        HP_change?.Invoke(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        HP_change?.Invoke(maxHealth, currentHealth);
    }
}
