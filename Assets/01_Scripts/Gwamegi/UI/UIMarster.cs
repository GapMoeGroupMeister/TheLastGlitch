using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIMarster : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float startScail, endScail, time;
    [SerializeField] private GameObject[] cross;
    [SerializeField] private RectTransform _trm;

    [SerializeField] private string _sceneName;

    [SerializeField] private bool _isShow;


    public void EnterUI()
    {
        foreach (var item in cross)
        {
            item.SetActive(true);
        }
    }

    public void ExitUI()
    {
        foreach (var item in cross)
        {
            item.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isShow)
            EnterUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isShow)
            ExitUI();
    }

    public void ChangeScene()
    {
        LoadingSceneManager.LoadScene(_sceneName);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
