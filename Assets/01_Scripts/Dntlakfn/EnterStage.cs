using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour
{
    public static string map;

    private bool a;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        a = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        a = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && a)
        {
            if(map != null)
            {
                SceneManager.LoadScene(map);
            }

            
        }
    }
}