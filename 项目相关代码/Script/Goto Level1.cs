using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject UI_ref;
    private GameObject Player_ref;
    private GameObject SmallEnemy_ref;
    private GameObject Music_ref;
    private GameObject Scene_ref;
    private GameObject Win_ref;
    private GameObject Virtual_ref;
    private GameObject EnemyHP_ref;
    private GameObject Pause_ref;
    private GameObject Event_ref;
    void Start()
    {
        UI_ref = GameObject.Find("UI_manager");
        Player_ref = GameObject.Find("Player");
        SmallEnemy_ref = GameObject.Find("SmallEnemy");
        Music_ref = GameObject.Find("MusicController");
        Scene_ref = GameObject.Find("SceneManager");
        Virtual_ref = GameObject.Find("PlayerCamera");
        EnemyHP_ref = GameObject.Find("EnemyHP");
        Pause_ref = GameObject.Find("Canvas");
        Event_ref = GameObject.Find("LevelEvent");
        Win_ref=UI_ref.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goto_level1()
    {
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    {
        Debug.LogWarning("游戏正在退出！");
        Application.Quit();
    }
    public void goto_level2()
    {
        DontDestroyOnLoad(UI_ref);
        DontDestroyOnLoad(Player_ref);
        DontDestroyOnLoad(Music_ref);
        DontDestroyOnLoad(Scene_ref);
        DontDestroyOnLoad (Virtual_ref);
        DontDestroyOnLoad(Event_ref);
        Destroy(Win_ref);
        Destroy(EnemyHP_ref);
        DontDestroyOnLoad(Pause_ref);
        SceneManager.LoadScene(2);
    }
    public void goto_mainmenu()
    {
        Destroy(UI_ref);
        Destroy(Player_ref);
        Destroy(SmallEnemy_ref);
        Destroy(Music_ref);
        Destroy(Scene_ref);
        SceneManager.LoadScene(0);  
    }
    public void gamePause()
    {
        Debug.Log("暂停键被点击了");
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0.0f;
        }
    }
    public void gameContinue()
    {
        if (Time.timeScale == 0)
        {
            Debug.LogWarning("游戏恢复进行！");
            Time.timeScale = 1;
        }
    }
}
