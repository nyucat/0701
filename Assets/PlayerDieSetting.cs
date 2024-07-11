using player_control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDieSetting : MonoBehaviour
{
    private PlayerController playerController;

    private GameObject playerDieUI;
    private GameObject GamePauseUI;
    private GameObject PlayerWinUI;
    private GameObject Player_ref;
    private GameObject PauseBtn;
    private void Awake()
    {
    }
    void Start()
    {
        // ������Ҷ���������������
        PauseBtn = transform.GetChild(4).gameObject;
        GamePauseUI = transform.GetChild(3).gameObject;
        PlayerWinUI = transform.GetChild(2).gameObject;
        playerDieUI = transform.GetChild(1).gameObject;
        GameObject playerObject = GameObject.Find("Player");
        playerController = playerObject.GetComponent<PlayerController>();
        playerDieUI.SetActive(false);
        GamePauseUI.SetActive(false);
        PlayerWinUI.SetActive(false);
        PauseBtn.SetActive(true);

    }
    void Update()
    {
        // �������Ƿ�����Լ�����ֵ�Ƿ�Ϊ��
        if (playerController != null && playerController.currentHP <= 0)
        {
            if (!playerDieUI.activeSelf)
            {
                playerDieUI.SetActive(true);
                Time.timeScale = 0;
            }
            Debug.Log("�����������Ϸ��������");
        }
        //�����ͣ
        if ( Time.timeScale == 0.0f && playerController.currentHP > 0)
        {
            Debug.Log("������ͣ");
            GamePauseUI.SetActive(true);
        }
        else if (Time.timeScale != 0.0f)
        {
            GamePauseUI.SetActive(false);
        }
    }
}