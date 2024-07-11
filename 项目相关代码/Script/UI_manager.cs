using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using player_control;

namespace UI_setting
{
    public class UI_manager : MonoBehaviour
    {
        public Slider HP_slider;//Ѫ��
        public Slider miss_slider;//������
        public GameObject PlayerDie;
        public GameObject PlayerWin;

        private void Awake()
        {
        }
        // Start is called before the first frame update
        void Start()
        {
            miss_slider = GetComponent<Slider>();
            HP_slider = GetComponent<Slider>();
          
        }

        // Update is called once per frame
        void Update()
        {
        }

        //Ѫ��������
        public void HP_manager(int max_hp, int current_hp)
        {
            HP_slider.maxValue = max_hp;
            HP_slider.value = current_hp;
            HP_slider.minValue = 0;
        }
        public void miss_manager()
        {
            miss_slider.maxValue = GetComponent<PlayerController>().miss_cooldown;
            miss_slider.value = GetComponent<PlayerController>().miss_timer;
        }
    }
}