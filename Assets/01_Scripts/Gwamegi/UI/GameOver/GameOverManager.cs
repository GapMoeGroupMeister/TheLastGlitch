using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using static System.Net.Mime.MediaTypeNames;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI GameText;
    [SerializeField] private TextMeshProUGUI OverText;

    [SerializeField] private List<GameObject> _allSetPanel;

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
        foreach (GameObject item in _allSetPanel) 
        {
            item.SetActive(false);
        }
        GameOverUI.SetActive(true);
        GameTextPrint();
        OverText.enabled = false;
    }

    private void GameTextPrint()
    {
        GameText.maxVisibleCharacters = 0;
        DOTween.To(x => GameText.maxVisibleCharacters = (int)x, 0f, GameText.text.Length, 1f).OnComplete(() => { OverTextPrint(); });
    }

    public void OverTextPrint()
    {
        OverText.enabled = true;

        OverText.maxVisibleCharacters = 0;
        DOTween.To(x => OverText.maxVisibleCharacters = (int)x, 0f, OverText.text.Length, 0.7f);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("UITest");
    }


}
