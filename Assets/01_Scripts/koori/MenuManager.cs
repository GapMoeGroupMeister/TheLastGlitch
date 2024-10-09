using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _craftUI;
    [SerializeField] private GameObject _storeUI;
    [SerializeField] private GameObject _gadgetEquipUI;
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private CraftUI _craft;
    [SerializeField] private float _moveY;
    [SerializeField] private Vector3 _ori;

    private void Start()
    {
        _ori = _mainUI.GetComponent<RectTransform>().position;
        _mainUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void CraftBtn()
    {
        _craft.ReloadItemCount();
        _mainUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _craftUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void StoreBtn()
    {
        _mainUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _storeUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void GadgetEquipBtn()
    {
        _gadgetEquipUI.GetComponent<GadgetEquip>().InitializeButtons();
        _mainUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _gadgetEquipUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void CraftExit()
    {
        PlayerItemData.Instance.SaveGadgetDataToJson();
        _craftUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _mainUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void StoreExit()
    {
        _storeUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _mainUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void GadgetEquipExit()
    {
        PlayerItemData.Instance.SaveGadgetDataToJson();
        _gadgetEquipUI.GetComponent<RectTransform>().DOMoveY(_ori.y, 0.5f);
        _mainUI.GetComponent<RectTransform>().DOMoveY(_moveY, 0.5f);
    }

    public void GoToBossScene()
    {
        PlayerItemData.Instance.SaveGadgetDataToJson();
        LoadingSceneManager.LoadScene("BossScene");
    }

    public void GoToBattle()
    {
        PlayerItemData.Instance.SaveGadgetDataToJson();
        GameManager.Instance.Player.IsDie = false;
        GameManager.Instance.Player._isDead = false;
        LoadingSceneManager.LoadScene("Stage1");
    }
}