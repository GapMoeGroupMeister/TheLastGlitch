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
        // ������ ����
        _icon.sprite = item._icon;
        _name.text = item._name;
        if (_name.text != "����")
        {
            passive = item.passiveSO;
            _toolTip.text = (passive.addPlayerAtkPower != 0 ? $"���ݷ�  +{passive.addPlayerAtkPower}\n" : "") + (passive.addPlayerCritDamage != 0f ? $"ġ��Ÿ ����  +{passive.addPlayerCritDamage}\n" : "") + (passive.addPlayerCritProbability != 0f ? $"ġ��Ÿ Ȯ��  +{passive.addPlayerCritProbability}%\n" : "") + (passive.addPlayerHealth != 0f ? $"ä��  +{passive.addPlayerHealth}\n" : "") + (passive.addPlayerMoveSpeed != 0f ? $"�̵��ӵ�  +{passive.addPlayerMoveSpeed}\n" : "") + $"\n{item._toolTip}";
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
        //�κ��丮 ����Ʈ�� ������ ������ �־���
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
            if (_name.text == "����")
            {
                MessageBox m = Instantiate(mb, canvas);

                m.SetMessage("�����̶�� �Ӹ� �� �����̶� ��������?");
            }
            OnBuy = BuyItem;
            EventBox e = Instantiate(_eb, canvas);
            e.SetEvent(OnBuy, "�����Ͻðڽ��ϱ�?");
        }
        else
        {
            MessageBox m = Instantiate(mb, canvas);

            m.SetMessage("���� �����մϴ�.");
        }
    }


}
