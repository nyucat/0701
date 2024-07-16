using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS2HPChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider BOSS1hp;
    public GameObject BOSS1_ref;
    void Start()
    {
        BOSS1hp=GetComponent<Slider>();
        BOSS1_ref = GameObject.Find("BOSS1");
        BOSS1hp.maxValue = 1200;
        BOSS1hp.value = 1200;
    }

    // Update is called once per frame
    void Update()
    {
        BOSS1hp.value = BOSS1_ref.GetComponent<BOSS1Controller>().currentHP;
    }
}
