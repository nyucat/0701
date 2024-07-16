using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SearchManagement : MonoBehaviour
{
    public GameObject PlayerPanel;
    public GameObject SmallEnemyPanel;
    public GameObject BossPanel;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayerClicked()
    {
        PlayerPanel?.SetActive(true);
        BossPanel?.SetActive(false);
        SmallEnemyPanel?.SetActive(false);
    }
    public void BossClicked() { 
        BossPanel?.SetActive(true);
        PlayerPanel?.SetActive(false);
        SmallEnemyPanel?.SetActive(false);
    }
    public void SmallEnemyClicked()
    {
        SmallEnemyPanel?.SetActive(true);
        PlayerPanel?.SetActive(false);
        BossPanel?.SetActive(false);
    }
    public void GotoMain()
    {
        SceneManager.LoadScene(0);
    }
}
