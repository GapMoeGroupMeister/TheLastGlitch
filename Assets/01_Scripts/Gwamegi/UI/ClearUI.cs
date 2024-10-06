using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private RectTransform _clearPanel;
    [SerializeField] private RectTransform _itemPanel;

    public void Clear()
    {
        _clearPanel.gameObject.SetActive(true);

        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.75f);
        _itemPanel.gameObject.SetActive(true);

        while (true)
        {
            yield return null;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                LoadingSceneManager.LoadScene("MenuScene");
            }
        }
    }
}
