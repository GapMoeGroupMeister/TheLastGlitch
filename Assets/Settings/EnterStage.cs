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
            
            eb.SetEvent(OnEnter, "이동하시겠습니까?");



        }
        else
        {
            OnEnter = OnDisconnect;
            eb.SetEvent(OnEnter, "수락한 임무가 없습니다.");

            
        }
    }

    public void OnDisconnect()
    {
        
    }
}
