using player_control;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BOSS2Controller : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public float Speed;
    public Rigidbody2D rb;
    public float distance;
    public bool is_chase;
    public bool is_attack;
    public bool is_skill;
    public bool is_die;
    private Vector3 origin;
    private Vector3 key1;
    private Vector3 key2;
    private Vector3 key3;
    private Vector3 targetPosition;
    private SpriteRenderer sp;
    private Vector2 direction2;
    private Vector3 direction3;
    private GameObject temp_player;
    private GameObject temp_boss1;
    private Transform player_ref;
    private Transform boss2_ref;
    private Animator boss2_animator;
    private GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 1200;
        currentHP = maxHP;
        Speed = 2.0f;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        temp_player = GameObject.Find("Player").gameObject;
        temp_boss1 = GameObject.Find("BOSS1").gameObject;
        Arrow = this.transform.GetChild(0).gameObject;
        player_ref = temp_player.transform;
        boss2_ref = temp_boss1.transform;
        boss2_animator = this.GetComponent<Animator>();
        boss2_animator.SetBool("WillChase", false);
        boss2_animator.SetBool("WillAttack", false);
        boss2_animator.SetBool("WillSkill", false);
        origin = this.transform.position;
        key1 = origin;
        key2 = origin;
        key3 = origin;
        key1.y = origin.y - 20;
        key2.x = origin.x + 20;
        key3.x = origin.x + 20;
        key3.y = origin.y - 20;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        enemy_flip_controller();
        BOSS2Change();
        Debug.Log(currentHP);

    }
    void enemy_flip_controller()
    {
        if (this.rb.velocity.x > 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX=false;
        }
    }

    public void BOSS2Change()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (distance < 5 && player_ref.GetComponent<PlayerController>().attack_control)
            {
                currentHP -= 10;
            }
        }

        else if (distance < 8&&player_ref.GetComponent<PlayerController>().is_bigskill_start)
        {
            currentHP -= 3;
        }
    }
    IEnumerator Move()
    {
        while (true)
        {
            boss2_animator.SetBool("WillMove", true);
            targetPosition = key1;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime * 2);
                yield return null;
            }
            boss2_animator.SetBool("WillMove", false);
            yield return new WaitForSeconds(2);
            boss2_animator.SetBool("WillAttack", true);
            yield return new WaitForSeconds(0.8f);
            Arrow.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            boss2_animator.SetBool("WillAttack", false);

            boss2_animator.SetBool("WillMove", true);
            targetPosition = key3;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime*2);
                yield return null;
            }
            boss2_animator.SetBool("WillMove", false);
            yield return new WaitForSeconds(2);
            boss2_animator.SetBool("WillAttack", true);
            yield return new WaitForSeconds(0.8f);
            Arrow.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            boss2_animator.SetBool("WillAttack", false);

            boss2_animator.SetBool("WillMove", true);
            targetPosition = key2;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime*2);
                yield return null;
            }
            boss2_animator.SetBool("WillMove", false);
            yield return new WaitForSeconds(2);
            boss2_animator.SetBool("WillAttack", true);
            yield return new WaitForSeconds(0.8f);
            Arrow.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            boss2_animator.SetBool("WillAttack", false);

            boss2_animator.SetBool("WillMove", true);
            targetPosition = origin;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime*2);
                yield return null;
            }
            boss2_animator.SetBool("WillMove", false);
            yield return new WaitForSeconds(2);
            boss2_animator.SetBool("WillAttack", true);
            yield return new WaitForSeconds(0.8f);
            Arrow.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            boss2_animator.SetBool("WillAttack", false);
        }
    }
}