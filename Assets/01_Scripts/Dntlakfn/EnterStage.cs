using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour, IInteractive
{
    public static string map;
    [SerializeField] protected EventBox eb;

    

    public void OnDisconnect()
    {
        
    }

    public void OnInteract()
    {
        if (map != null)
        {
            SceneManager.LoadScene(map);
        }
    }

    
    
}
