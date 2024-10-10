using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoodsControl : MonoBehaviour
{
    public Action OnBuy;

    [SerializeField] protected Button buyBtn;
    public TestItemSO item { get; set; }
    [SerializeField] protected PassiveSO passive;
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _toolTip;
    [SerializeField] protected TextMeshProUGUI _price;
    public EventBox _eb;
    public MessageBox mb;
    public RectTransform canvas;
    




    public void UpdateItem()
    {
        buyBtn.
        gameObject.SetActive(true);
        // 아이탬 셋팅
        _icon.sprite = item._icon;
        _name.text = item._name;
        if (_name.text != "매진")
        {
            passive = item.passiveSO;
            _toolTip.text = (passive.addPlayerAtkPower != 0 ? $"공격력  +{passive.addPlayerAtkPower}\n" : "") + (passive.addPlayerCritDamage != 0f ? $"치명타 피해  +{passive.addPlayerCritDamage}\n" : "") + (passive.addPlayerCritProbability != 0f ? $"치명타 확률  +{passive.addPlayerCritProbability}%\n" : "") + (passive.addPlayerHealth != 0f ? $"채력  +{passive.addPlayerHealth}\n" : "") + (passive.addPlayerMoveSpeed != 0f ? $"이동속도  +{passive.addPlayerMoveSpeed}\n" : "") + $"\n{item._toolTip}";
        }
        else
        {
            _toolTip.text = item._toolTip;
        }
        _price.text = item._price + " Coin";



    }

    public void BuyItem()
    {
        PlayerItemData.Instance.gadgetData.Gold -= item._price;
        gameObject.SetActive(false);
        Debug.Log(item);
        //인벤토리 리스트에 구매한 아이탬 넣어줌
        PassiveManager passiveManager = GameManager.Instance.Player.GetComponentInChildren<PassiveManager>();
        passiveManager.HavePassiveList.Add(item.passiveSO);
        passiveManager.AddPassive();
        GameManager.Instance.Player.GetComponent<PlayerStat>().StatSet(item.passiveSO);
    }

    public void Click()
    {
        if(FindAnyObjectByType<EventBox>() != null || FindAnyObjectByType<MessageBox>() != null)
        {
            return;
        }
        if (Money.money >= item._price)
        {
            if (_name.text == "매진")
            {
                MessageBox m = Instantiate(mb, canvas);

                m.SetMessage("매진이라고 임마 뭐 간판이라도 가져가게?");
            }
            OnBuy = BuyItem;
            EventBox e = Instantiate(_eb, canvas);
            e.SetEvent(OnBuy, "구매하시겠습니까?");
        }
        else
        {
            MessageBox m = Instantiate(mb, canvas);

            m.SetMessage("돈이 부족합니다.");
        }
    }


}
