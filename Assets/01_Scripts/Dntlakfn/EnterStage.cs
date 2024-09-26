using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour
{
    public static string map;
    [SerializeField] protected EventBox eb;
    public Action OnEnter;
    


    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (map != null)
        {
            OnEnter += Exit;
            Time.timeScale = 0;
            eb.SetEvent(OnEnter, "�̵��Ͻðڽ��ϱ�?");
            Time.timeScale = 1;


        }
        else
        {
            OnEnter -= Exit;
            Time.timeScale = 0;
            eb.SetEvent(OnEnter, "������ �ӹ��� �����ϴ�.");
            Time.timeScale = 1;

        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(map);

    }
}
