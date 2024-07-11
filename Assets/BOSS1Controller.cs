using player_control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS1Controller : MonoBehaviour
{
    public float damage;
    public float maxHP;
    public float currentHP;
    public float Speed;
    public Rigidbody2D rb;
    public float distanceBOSS1;
    public bool is_chase;
    public bool is_attack;
    public bool is_skill;
    public bool is_die;
    private SpriteRenderer sp;
    private Vector2 direction2;
    private Vector3 direction3;
    private GameObject temp_player;
    private GameObject temp_boss1;
    private GameObject BOSS1HP_ref;
    private Transform player_ref;
    private Transform boss1_ref;
    private Animator boss1_animator;


    // Start is called before the first frame update
    void Start()
    {
        damage = 0.7f;
        maxHP = 1200;
        currentHP = maxHP;
        Speed = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        temp_player = GameObject.Find("Player").gameObject;
        temp_boss1 = GameObject.Find("BOSS1").gameObject;
        player_ref = temp_player.transform;
        boss1_ref = temp_boss1.transform;
        boss1_animator = this.GetComponent<Animator>();
        boss1_animator.SetBool("WillChase", false);
        boss1_animator.SetBool("WillAttack", false);
        boss1_animator.SetBool("WillSkill", false);
    }

    // Update is called once per frame
    void Update()
    {
        distanceBOSS1 = Vector3.Distance(player_ref.transform.position, this.transform.position);
        Debug.Log(currentHP);
        enemy_flip_controller();
        BOSS1Move();
        BOSS1Attack();
        BOSS1Change();
        Die();
    }
    void enemy_flip_controller()
    {
        if (boss1_ref.position.x > player_ref.position.x)
        {
            sp.flipX = true;

        }
        else
        {
            sp.flipX = false;
        }
    }
    public void BOSS1Move()
    {
        direction3 = player_ref.position - boss1_ref.position;
        direction2.x = direction3.x;
        direction2.y = direction3.y;
        distanceBOSS1 = Vector3.Distance(player_ref.position, boss1_ref.position);
        //Debug.LogWarning("玩家与BOSS1的距离是：" + distance);
        if (distanceBOSS1 < 13.0f && distanceBOSS1 >7.0f)
        {
            is_attack = false;
            boss1_animator.SetBool("WillChase", true);
            boss1_animator.SetBool("WillAttack", false);
            boss1_animator.SetBool("WillSkill", false);
            rb.velocity = direction2 * Speed;
        }
        else if (distanceBOSS1 < 7.0f && distanceBOSS1 > 0.0f)
        {
            is_attack = true;
            boss1_animator.SetBool("WillChase", false);
            boss1_animator.SetBool("WillAttack", is_attack);
            rb.velocity = direction2 * Speed * 0.1f;
        }
        else
        {
            boss1_animator.SetBool("WillChase", false);
            boss1_animator.SetBool("WillAttack", false);
            boss1_animator.SetBool("WillSkill", false);
            rb.velocity = Vector2.zero;
        }
    }
    public  bool is_immuse()
    {
        return player_ref.GetComponent<PlayerController>().miss_control || player_ref.GetComponent<PlayerController>().is_bigskill_start;
    }
    public void BOSS1Attack()
    {
        if (is_attack && distanceBOSS1 < 5.0f && !is_immuse() && Time.timeScale != 0)
        {
            player_ref.GetComponent<PlayerController>().currentHP -= damage/2;

        }
        else if (is_attack&&player_ref.GetComponent<PlayerController>().is_miss_start)
        {
            if (player_ref.GetComponent<PlayerController>().currentHP <= 100)
            {
                player_ref.GetComponent<PlayerController>().currentHP += 1;
            }
        }
       
    }
    public void BOSS1Change()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (distanceBOSS1 < 8 && player_ref.GetComponent<PlayerController>().attack_control)
            {
                this.currentHP -= 8;
            }
        }
        else if (distanceBOSS1 < 8 && player_ref.GetComponent<PlayerController>().is_bigskill_start)
        {
            this.currentHP -= 3;
        }
    }
    public void Die()
    {
        if (currentHP <= 0)
        {
            Debug.Log("BOSS1已死亡");
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator BOSS1Timer(float t)
    {
        yield return new WaitForSeconds(t);
    }
}
