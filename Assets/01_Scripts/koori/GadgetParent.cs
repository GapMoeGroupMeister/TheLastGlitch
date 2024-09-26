using System;
using UnityEngine;

public class GadgetParent : MonoBehaviour
{
    [SerializeField] protected Player _player;
    protected Action _isUse;
    [field : SerializeField]protected InputReader _input;
    protected GadgetType _type;
    private void Start()
    {
        Init();
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
        this.gameObject.SetActive(true);
        DataManager.Instance.SelectedGadget = GadgetType.None;
        _isUse.Invoke();
    }
}
