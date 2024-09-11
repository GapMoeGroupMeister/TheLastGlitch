using System;
using UnityEngine;

public class GadgetParent : MonoBehaviour
{
    [SerializeField] protected Player _player;
    protected Action _isUse;
    [field : SerializeField]protected InputReader _input;
    private void Start()
    {
        Init();
        _input.OnUseGadgetEvent += UseGadget;
    }

    public void Init()
    {
        if (_player.ItemSO.CurrentGadget == null)
        {
            this.gameObject.transform.SetParent(_player.transform, false);
            this.gameObject.transform.position = Vector3.zero;
            ChangeGadget(this);
            this.gameObject.SetActive(false);
        }
        else 
            Destroy(this.gameObject);
    }
    public void UseGadget()
    {
        this.gameObject.SetActive(true);
        _player.ItemSO.CurrentGadget = null;
        _isUse.Invoke();
    }
    public void ChangeGadget(GadgetParent target)
    {
        _player.ItemSO.CurrentGadget = target;
    }
}
