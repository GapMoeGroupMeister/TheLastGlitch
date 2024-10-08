                                                                                                  using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CraftButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RequireItemType _item1Type, _item2Type;
    [SerializeField] private GadgetType _type;
    [SerializeField] private TMP_Text _cnt;
    [SerializeField] private Sprite _item1, _item2;
    [SerializeField] private int _price1, _price2;
    [SerializeField] private RequestItemInfo _info;
    [SerializeField]private RectTransform _shortCut;

    private CraftUI _craftUI;

    private void Awake()
    {
        _craftUI = GetComponentInParent<CraftUI>();
    }
    private void Start()
    {
        ReloadHaveCnt();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _shortCut.gameObject.SetActive(true);
        _shortCut.position = eventData.position;
        _info.ReloadData(_price1, _price2, _item1, _item2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _shortCut.gameObject.SetActive(false);
    }

    public void OnClicked()
    {
        if (_price1 <= PlayerItemData.Instance.requireItemDic[_item1Type] && _price2 <= PlayerItemData.Instance.requireItemDic[_item2Type])
        {
            PlayerItemData.Instance.requireItemDic[_item1Type] -= _price1;
            PlayerItemData.Instance.requireItemDic[_item2Type] -= _price2;
            PlayerItemData.Instance.havingGadgetDic[_type] += 1;
            ReloadHaveCnt();
            _craftUI.ReloadItemCount();
        }
    }

    private void ReloadHaveCnt()
    {
        _cnt.text = $"{PlayerItemData.Instance.havingGadgetDic[_type]} º¸À¯";
    }
}
