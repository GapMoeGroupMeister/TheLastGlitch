using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour, IInteractive
{
    public static string map;

    private bool a;

    public void OnInteract()
    {
        if (map != null)
        {
            SceneManager.LoadScene(map);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        a = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        a = false;
    }
}
