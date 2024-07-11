using player_control;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private float maxHP;
    public float currentHP;
    private SpriteRenderer sp_e;
    private Transform player_trans;
    private Transform enemy_trans;
    private GameObject temp_player;
    private GameObject temp_enemy;
    private Rigidbody2D small_enemy_rb;
    private Animator enemy_animator;
    private Slider Enemy_HP;
    private GameObject temp_Enemy_HP;
    public Vector3 direction3;
    public Vector2 direction2;
    public bool is_chase;
    public bool is_attack;
    public bool is_die;
    public float distance;
    public float small_enemy_speed;
    public float small_enemy_damage;
    public GameObject Player_ref;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 400;
        currentHP = maxHP;
        small_enemy_rb =GetComponent<Rigidbody2D>();
        sp_e = GetComponent<SpriteRenderer>();
        temp_player = GameObject.Find("Player");
        temp_enemy = GameObject.Find("SmallEnemy");
        temp_Enemy_HP = GameObject.Find("EnemyHP");
        player_trans=temp_player.transform;
        enemy_trans=temp_enemy.transform;
        is_chase = false;
        is_attack = false;
        enemy_animator = GetComponent<Animator>();
        small_enemy_speed = 1.5f;
        small_enemy_damage = 10.0f;
        Player_ref = GameObject.Find("Player").gameObject;
        enemy_animator.SetBool("will_chase", false);
        enemy_animator.SetBool("will_attack", false);
        transform.gameObject.SetActive(true);
        Enemy_HP = temp_Enemy_HP.GetComponent<Slider>();
        Enemy_HP.maxValue = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_HP.value = this.GetComponent<EnemyController>().currentHP;
        SmallEnemyDie();
        enemy_animator.SetFloat("CurrentHP", currentHP);
        direction3 = player_trans.position - enemy_trans.position;
        direction2.x = direction3.x;
        direction2.y = direction3.y;
        enemy_animator.SetBool("will_chase", is_chase);
        enemy_animator.SetBool("will_attack", is_attack);
        enemy_animator.SetBool("WILL_DIE", is_die);
        attack();
        distance = Vector3.Distance(player_trans.position, enemy_trans.position);
            if (distance < 12.0f && distance > 4.0f)
            {
                small_enemy_speed = 1.0f;
                is_attack = false;
                is_chase = true;
                small_enemy_rb.velocity = small_enemy_speed * direction2;

            }
            else if (distance <= 4.0f && Player_ref.GetComponent<PlayerController>().currentHP >=0)
            {
                is_chase = false;
                small_enemy_speed = 0.0f;
                small_enemy_rb.velocity = Vector2.zero;
                is_attack = true;
            }
            else if (distance >= 12)
            {
                is_chase = false;
                is_attack = false;
                small_enemy_speed = 0;
                direction2 = Vector2.zero;
                small_enemy_rb.velocity = Vector2.zero;
            }
            if (distance < 10.0f && distance > 4.0f && this.GetComponent<EnemyController>().currentHP < 150)
            {
                small_enemy_speed = 5;
            }

                enemy_flip_controller();
        
        
    }

    void enemy_flip_controller()
    {
        if (enemy_trans.position.x > player_trans.position.x)
        {
            sp_e.flipX = true;
            
        }
        else
        {
            sp_e.flipX = false;
        }
    }
    void attack()
    {
        if (is_attack == true && Player_ref.GetComponent<PlayerController>().miss_control == true) 
        {
            Debug.Log(" ±ø’∂œ¡—£°£°…¡±‹≥…π¶£°£°");
            if (Player_ref.GetComponent<PlayerController>().currentHP < 100)
            {
                Player_ref.GetComponent<PlayerController>().currentHP += 1;
            }
        }
        else if(is_attack == true && Player_ref.GetComponent<PlayerController>().miss_control == false&& Player_ref.GetComponent<PlayerController>().is_bigskill_start == false&&Time.timeScale!=0)
        {
            Debug.Log("…¡±‹ ß∞‹£°£° ‹µΩ…À∫¶");
            Player_ref.GetComponent<PlayerController>().currentHP -= 0.5f;
        }
    }
    void SmallEnemyDie()
    {
        if (currentHP < 0||currentHP==0)
        {
            is_attack = false;
            is_chase = false;
            is_die = true;
            enemy_animator.SetBool("WILL_DIE", is_die);
            enemy_animator.SetFloat("CurrentHP", currentHP);
           transform.gameObject.SetActive(false);
            Debug.Log("πßœ≤≥…π¶ª˜∞‹µ–»À£°£°");
        }
    }
}
