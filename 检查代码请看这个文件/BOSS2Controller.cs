using player_control;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BOSS2Controller : MonoBehaviour
{
    #region 变量声明
    public float maxHP;
    public float currentHP;
    public float Speed;
    public Rigidbody2D rb;
    public float distanceBOSS2;
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
    #endregion
    // Start is called before the first frame update
    #region 变量的初始化
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
    #endregion
    // Update is called once per frame
    void Update()
    {
        distanceBOSS2 = Vector3.Distance(player_ref.transform.position, this.transform.position);
        enemy_flip_controller();
        BOSS2Change();
        Debug.Log(currentHP);
        Die();
    }
    #region 镜像反转管理
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
    #endregion

    #region BOSS2血条管理
    public void BOSS2Change()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (distanceBOSS2 < 4 && player_ref.GetComponent<PlayerController>().attack_control&&Time.timeScale!=0)
            {
                currentHP -= 10;
            }
        }
    }
    #endregion

    #region BOSS2异步计时器
    IEnumerator BOSS2Timer(float t)
    {
        yield return new WaitForSeconds(t);
    }
    #endregion


    #region BOSS2死亡判定
    public void Die()
    {
        if (this.currentHP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    #endregion

    #region 用携程实现移动到检查点
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
    #endregion
}