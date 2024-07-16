using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLevel1 : MonoBehaviour
{
    #region 初始变量声明
    // Start is called before the first frame update
    private GameObject Map;
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
    private GameObject MusicPlayer_ref;
    //已经存在的各项游戏物体的获取，用来选取是否保存删除
    #endregion
    #region 初始化各个场景的游戏物体
    void Start()
    {
        Map = GameObject.Find("Grid");
        UI_ref = GameObject.Find("UI_manager");
        Player_ref = GameObject.Find("Player");
        SmallEnemy_ref = GameObject.Find("SmallEnemy");
        Music_ref = GameObject.Find("MusicController");
        Scene_ref = GameObject.Find("SceneManager");
        Virtual_ref = GameObject.Find("PlayerCamera");
        EnemyHP_ref = GameObject.Find("EnemyHP");
        Pause_ref = GameObject.Find("Canvas");
        Event_ref = GameObject.Find("LevelEvent");
        MusicPlayer_ref = GameObject.Find("MusicPlayer");
        Win_ref=UI_ref.transform.GetChild(2).gameObject;
    }
    #endregion

    // Update is called once per frame
    private void Awake()
    {
    }
    void Update()
    {

    }
    //前往第一关
    public void goto_level1()
    {
        SceneManager.LoadScene(1);
    }
    //前往图鉴界面
    public void goto_level3()
    {
        DontDestroyOnLoad(MusicPlayer_ref);
        SceneManager.LoadScene(3);
    }
    //退出游戏
    public void exitGame()
    {
        Application.Quit();
    }
    //前往第二关
    public void goto_level2()
    {
        DontDestroyOnLoad(UI_ref);
        DontDestroyOnLoad(Player_ref);
        DontDestroyOnLoad(Music_ref);
        DontDestroyOnLoad(Scene_ref);
        DontDestroyOnLoad (Virtual_ref);
        DontDestroyOnLoad(Event_ref);
        DontDestroyOnLoad(Map);
        Destroy(Win_ref);
        Destroy(EnemyHP_ref);
        DontDestroyOnLoad(Pause_ref);
        SceneManager.LoadScene(2);
        //有些保留，有些删除
    }
    
    //前往主菜单
    public void goto_mainmenu()
    {
        Destroy(UI_ref);
        Destroy(Player_ref);
        Destroy(SmallEnemy_ref);
        Destroy(Music_ref);
        Destroy(Scene_ref);
        DontDestroyOnLoad(Virtual_ref);
        SceneManager.LoadScene(0);  
    }

    //游戏暂停
    public void gamePause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0.0f;
        }
    }
    //游戏继续
    public void gameContinue()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
