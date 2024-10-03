using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    [SerializeField] private RectTransform _gameOverPanel;

    private void Update()
    {
        if (GameManager.Instance.Player.IsDie)
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    }

    public IEnumerator ClickWating()
    {
        while (true)
        {
            yield return null;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                LoadingSceneManager.LoadScene("Title");
                break;
            }
        }
    }
}
