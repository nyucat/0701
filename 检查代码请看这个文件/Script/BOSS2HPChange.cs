using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS1HPChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider BOSS2hp;
    public GameObject BOSS2_ref;
    void Start()
    {
        BOSS2hp = GetComponent<Slider>();
        BOSS2_ref = GameObject.Find("BOSS2");
        BOSS2hp.maxValue = 1200;
        BOSS2hp.value = 1200;
    }

    // Update is called once per frame
    void Update()
    {
        BOSS2hp.value = BOSS2_ref.GetComponent<BOSS2Controller>().currentHP;
    }
}
