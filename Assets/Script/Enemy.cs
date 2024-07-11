using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterData
{
    private Collider2D c2d; 
    // Start is called before the first frame update
    void Start()
    {
        c2d = GetComponent<Collider2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        is_next(c2d);
    }

    private void is_next(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("敌人已经触摸到玩家");
        }

    }

}
