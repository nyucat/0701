using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UI_setting;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace player_control
{
    
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        public float maxHP;
        public float currentHP;
        public float speed;
        public float moveX;
        public float moveY;
        public float bigskill_cooldown;
        public float bigskill_timer;
        public float miss_timer;
        public float miss_cooldown;
        public bool attack_control;
        public bool miss_control;
        public bool is_miss_cooldown;
        public bool is_miss_start;
        public bool is_bigskill_start;
        public bool is_bigskill_cooldown;
        public Image attack_png;
        public Image bigskill_png;
        public Image SkillCoolDown;
        public Vector2 Direction;
        public Vector2 MissDirection;
        public InputAction ia;
        private Rigidbody2D rb;
        private Animator player_animator;
        private SpriteRenderer sp;
        private Slider MissSlider;
        private Slider HPSlider;
        private GameObject temp_HP;
        private GameObject temp_miss;
        private GameObject enemy_ref;
        private GameObject temp_bigskill;
        private GameObject temp_attack;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            player_animator = GetComponent<Animator>();
            sp = GetComponent<SpriteRenderer>();
            is_miss_start = false;
            speed = 6.0f;
            bigskill_cooldown = 15.0f;
            bigskill_timer = 0.0f;
            miss_timer = 0.0f;
            miss_cooldown = 2.0f;
            maxHP = 100;
            temp_miss = GameObject.Find("miss");
            temp_HP = GameObject.Find("hp");
            temp_attack = GameObject.Find("NormalAttack");
            temp_bigskill = GameObject.Find("BigSkill");
            enemy_ref = GameObject.Find("SmallEnemy");
            MissSlider=temp_miss.GetComponent<Slider>();
            HPSlider=temp_HP.GetComponent<Slider>();
            attack_png = temp_attack.gameObject.GetComponent<Image>();
            bigskill_png=temp_bigskill.gameObject.GetComponent<Image>();
            MissSlider.maxValue = miss_cooldown;
            HPSlider.maxValue = maxHP;
            HPSlider.minValue=0.0f;
            currentHP = maxHP;
            
        }
        private void Awake()
        {
        }
        // Update is called once per frame
        void Update()
        {
            move();
            FlipController();
            attack();
            Miss();
            bigskill();
            ImageController();
            HPSlider.value = currentHP;
            
        }
        private void OnEnable()
        {
            ia.Enable();
        }
        private void OnDisable()
        {
            ia.Disable();
        }

        public void move()
        {
            
            //获取水平轴垂直轴输入
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");
            //计算二维向量获取方向
            Direction = new Vector2(moveX, moveY);
            //获取速度
            rb.velocity = Direction * speed;
            //动画获取
            player_animator.SetFloat("Horizontal", moveX);
            player_animator.SetFloat("Vertical", moveY);
            player_animator.SetFloat("Speed", Direction.sqrMagnitude);
        }

        public void attack()
        {
            
            player_animator.SetBool("is_always_attack", attack_control);
            if (Input.GetMouseButtonDown(0))
            {
                attack_control = true;
                player_animator.SetBool("is_always_attack", attack_control);
                if (enemy_ref.GetComponent<EnemyController>().distance < 5.0f)
                {
                    Debug.Log("成功造成伤害！！！");
                    enemy_ref.GetComponent<EnemyController>().currentHP -= 5;
                }
            }
        }
        public void Miss()
        {
            MissSlider.value = miss_timer;
            player_animator.SetBool("is_miss", miss_control);
            if (Input.GetMouseButtonDown(1)&&is_miss_cooldown)
            {
                miss_control = true;
                player_animator.SetBool("is_miss", miss_control);
                if (is_miss_start == true)
                {
                    if (moveX == 0)
                    {
                        moveX = 1;
                    }
                    MissDirection.x = moveX;
                    MissDirection.y = moveY;
                    transform.Translate(MissDirection * 3);
                }
            }
           
            if (Input.GetMouseButtonDown(1) && !is_miss_cooldown){
                Debug.LogWarning("闪避正在冷却");
            }
            if (miss_timer <= miss_cooldown)
            {
                miss_timer += Time.deltaTime;
            }
            if (miss_timer >= miss_cooldown)
            {
                miss_timer = 2.0f;
                is_miss_cooldown = true;
            }
        }
        public void bigskill()
        {
            player_animator.SetBool("is_bigskill", is_bigskill_start);
            if (Input.GetKeyDown(KeyCode.Q) && is_bigskill_cooldown == true)
            {
                is_bigskill_start = true;
                player_animator.SetBool("is_bigskill", is_bigskill_start);
                bigskill_timer = 0;
            }
            if (Input.GetKeyDown(KeyCode.Q) && is_bigskill_cooldown == false)
            {
                Debug.LogWarning("释放失败，技能正在冷却");
            }
            if (bigskill_timer <= bigskill_cooldown)
            {
                bigskill_timer += Time.deltaTime;    
            }
            if (bigskill_timer >= bigskill_cooldown)
            {
                bigskill_timer = bigskill_cooldown;
                is_bigskill_cooldown = true;

            }
        }
        void FlipController()
        {
            if (moveX < 0)
            {
                sp.flipX = true;
            }
            else
            {
                sp.flipX = false;
            }
        }
        void ImageController()
        {
            float fill_time = bigskill_timer / bigskill_cooldown;
            Color begin=Color.black;
            Color end = Color.white;
            bigskill_png.color = Color.Lerp(begin, end, fill_time);
        }
    }

}
