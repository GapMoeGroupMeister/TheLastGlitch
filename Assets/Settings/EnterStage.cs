using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour, IInteractive
{
    public static string map;


    [SerializeField] protected EventBox eb;
    public Action OnEnter;
    


    private void Awake()
    {
        
    }

    public void Exit()
    {
        LoadingSceneManager.LoadScene(map);

    }

    public void OnInteract()
    {
        if (map != null)
        {
            OnEnter += Exit;
            
            eb.SetEvent(OnEnter, "�̵��Ͻðڽ��ϱ�?");



        }
        else
        {
            OnEnter = OnDisconnect;
            eb.SetEvent(OnEnter, "������ �ӹ��� �����ϴ�.");

            
        }
    }

    public void OnDisconnect()
    {
        
    }
}
