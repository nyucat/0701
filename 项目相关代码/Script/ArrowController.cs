using player_control;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArrowController : MonoBehaviour

{
    public float Speed;
    public float Distance;
    private Rigidbody2D rb;
    private Vector3 direction;
    private GameObject Parent_ref;
    private GameObject Player_ref;
    private SpriteRenderer sp;
    private float attackTimer;
    private void OnEnable()
    {
        Parent_ref = this.transform.parent.gameObject;
        Player_ref = GameObject.Find("Player").gameObject;
        direction = (Player_ref.transform.position - Parent_ref.transform.position);
      
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player_ref.transform.position, this.transform.position);
        if (this.gameObject.activeSelf)
        {
            rb.velocity = direction * Speed/2;
            selfDestroy();
        }
        ArrowDamage();
    }
    void selfDestroy()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 5.0f)
        {
            this.transform.position = Parent_ref.transform.position;
            this.gameObject.SetActive(false);
            attackTimer = 0;
        }
    }
    void enemy_flip_controller()
    {
        if (this.transform.position.x > Player_ref.transform.position.x)
        {
            sp.flipX = true;

        }
        else
        {
            sp.flipX = false;
        }
    }

    public bool is_immuse()
    {
        return Player_ref.GetComponent<PlayerController>().miss_control || Player_ref.GetComponent<PlayerController>().is_bigskill_start;
    }
    public void ArrowDamage()
    {
        if (Distance < 5.0f && !is_immuse())
        {
            Player_ref.GetComponent<PlayerController>().currentHP -= 2;
        }
        else if (Distance < 5.0f && Player_ref.GetComponent<PlayerController>().miss_control == true)
        {
            if (Player_ref.GetComponent<PlayerController>().currentHP <= 100)
            {
                Player_ref.GetComponent<PlayerController>().currentHP += 5;
            }
        }
    }
}
