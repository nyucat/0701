using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalWinController : MonoBehaviour
{
    private GameObject BOSS1_ref;
    private GameObject BOSS2_ref;
    // Start is called before the first frame update
    void Start()
    {
        BOSS1_ref = GameObject.Find("BOSS1");
        BOSS2_ref = GameObject.Find("BOSS2");
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!BOSS1_ref.activeSelf && !BOSS2_ref.activeSelf)
        {
            this.gameObject.SetActive(true);
        }
    }
}
