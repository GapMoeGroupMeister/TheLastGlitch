using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;

    private void Awake()
    {
        Debug.Log("LoadScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("UITest");
    }


}
