using System;
using UnityEngine;

public class GadgetParent : MonoBehaviour
{
    [SerializeField]protected Player _player;
    protected Action _isUse;
    [field : SerializeField]protected InputReader _input;
    private void Awake()
    {
        Init();
    }
    private void Start()
    {
    }
    private void OnEnable()
    {
        _input.OnUseGadgetEvent += UseGadget;
        
    }

    public void Init()
    {
        if (DataManager.Instance.SelectedGadget == GadgetType.None)
        {
            this.gameObject.transform.SetParent(_player.transform, false);
            this.gameObject.transform.position = Vector3.zero;
            GadgetManager.Instance.GadgetChange(_type);
            this.gameObject.SetActive(false);
        }
        else 
            Destroy(this.gameObject);
    }
    public void UseGadget()
    {
        Debug.Log("¾Ó ³ª´Â ¹Î¼ö°¡ ÁÁ¾Æ~");
        this.gameObject.SetActive(true);
        DataManager.Instance.SelectedGadget = GadgetType.None;
        _isUse.Invoke();

    }
}
