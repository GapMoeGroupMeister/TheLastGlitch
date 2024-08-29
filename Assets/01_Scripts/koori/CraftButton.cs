                                                                                                  using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CraftButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private RectTransform _shortCut;
    [SerializeField] private RequireItemType _item1Type, _item2Type;
    
    [SerializeField] private Sprite _item1, _item2;
    [SerializeField] private int _price1, price2;
    [SerializeField] private RequestItemInfo _info;
    [SerializeField] private GadgetType _type;
    [SerializeField] private TMP_Text _cnt;

    private void Start()
    {
        ReloadHaveCnt();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _shortCut.gameObject.SetActive(true);
        _shortCut.position = eventData.position;
        _info.ReloadData(_price1, price2, _item1, _item2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _shortCut.gameObject.SetActive(false);
    }

    public void OnClicked()
    {
        
    }

    private void ReloadHaveCnt()
    {
        switch (_type)
        {
            case GadgetType.gatlingDrone:
                _cnt.text = _info._item.gatlingDrone.ToString();
                break;
            case GadgetType.selfDestructDrone:
                _cnt.text = _info._item.selfDestructDrone.ToString();
                break;
            case GadgetType.portalGun:
                _cnt.text = _info._item.portalGun.ToString();
                break;
            case GadgetType.hackPulse:
                _cnt.text = _info._item.hackPulse.ToString();
                break;
            case GadgetType.aed:
                _cnt.text = _info._item.aed.ToString();
                break;
            case GadgetType.doping:
                _cnt.text = _info._item.doping.ToString();
                break;
            case GadgetType.shield:
                _cnt.text = _info._item.shield.ToString();
                break;
        }
    }
}
