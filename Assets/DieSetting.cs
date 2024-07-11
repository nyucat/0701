using player_control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSetting : MonoBehaviour
{
    private GameObject UIManager;
    private GameObject playerDieUI;
    private GameObject GamePauseUI;
    private GameObject PlayerWinUI;
    private GameObject Player_ref;
    private GameObject SmallEnemy_ref;
    private GameObject Enemy_ref;
    private GameObject PauseBtn;
    public GameObject BOSS1_ref;
    public GameObject BOSS2_ref;

    // Start is called before the first frame update
      void Awake()
    {
      
    }
    void Start()
    {
        UIManager = GameObject.Find("UI_manager");
        SmallEnemy_ref = GameObject.Find("SmallEnemy");
        Player_ref = GameObject.Find("Player");
        Enemy_ref = GameObject.FindGameObjectWithTag("Enemy");
        BOSS1_ref = GameObject.Find("BOSS1");
        BOSS2_ref = GameObject.Find("BOSS2");
        PauseBtn = UIManager.transform.GetChild(4).gameObject;
        GamePauseUI = UIManager.transform.GetChild(3).gameObject;
        PlayerWinUI = UIManager.transform.GetChild(2).gameObject;
        playerDieUI = UIManager.transform.GetChild(1).gameObject;
        playerDieUI.SetActive(false);
        GamePauseUI.SetActive(false);
        PlayerWinUI.SetActive(false);
        PauseBtn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_ref.GetComponent<PlayerController>().currentHP <= 0)
        {
            if (!playerDieUI.activeSelf)
            {
                playerDieUI.SetActive(true);
                Time.timeScale = 0;
            }
            Debug.Log("玩家死亡，游戏结束！！");
        }
        if (Time.timeScale == 0.0f && this.GetComponent<PlayerController>().currentHP >0)
        {
            Debug.Log("正常暂停");
            GamePauseUI.SetActive(true);
        }
        else if (Time.timeScale != 0.0f)
        {
            GamePauseUI.SetActive(false);
        }
        if (Enemy_ref!=null&&!Enemy_ref.activeSelf)
        {
            PlayerWinUI.gameObject.SetActive(true);
        }
    }

}
