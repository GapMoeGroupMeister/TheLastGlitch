using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI ��ҿ� ���� ���� �ʿ�

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _goToBossButton;
    [SerializeField] private PlayerItemData _playerItemData;
    [SerializeField] private TextMeshProUGUI _buttonText;
    private Button _button; // Button ������Ʈ
    private Image _buttonImage; // ��ư�� �̹���
    private Color _activeColor; // ��ư�� Ȱ��ȭ ����
    private Color _textActiveColor; // ��ư�� Ȱ��ȭ ����

    private Color _inactiveColor = Color.gray; // ��ư ��Ȱ��ȭ ����

    private void Awake()
    {
        _button = _goToBossButton.GetComponent<Button>();
        _buttonImage = _goToBossButton.GetComponent<Image>();

        if (_button == null || _buttonImage == null)
        {
            Debug.LogError("Button �Ǵ� Image ������Ʈ�� �������� �ʽ��ϴ�.");
            return;
        }

        // ���� ��ư�� ������ activeColor�� ����
        _activeColor = _buttonImage.color;
        _textActiveColor = _buttonText.color;

        SetButtonState(false); // �ʱ� ���¿��� ȸ������ �����ϰ� ��ȣ�ۿ� ����
    }

    private void OnEnable()
    {
        CheckHaveAllGadgets();
    }

    private void Update()
    {
        CheckHaveAllGadgets();
    }

    private void CheckHaveAllGadgets()
    {
        foreach (var data in _playerItemData.havingGadgetDic)
        {
            if (data.Key != GadgetType.None || data.Key == GadgetType.shield)
            {
                if (data.Value == 0)
                {
                    SetButtonState(false); // ��Ȱ��ȭ (ȸ�� + ��ȣ�ۿ� ����)
                    return;
                }
            }
        }

        SetButtonState(true); // Ȱ��ȭ (���� ���� + ��ȣ�ۿ� ���)
    }

    private void SetButtonState(bool isActive)
    {
        if (isActive)
        {
            _buttonImage.color = _activeColor; // ���� �������� ����
            _buttonText.color = _textActiveColor;
            _button.interactable = true; // ��ȣ�ۿ� ����
        }
        else
        {
            _buttonImage.color = _inactiveColor; // ȸ������ ����
            _buttonText.color = _inactiveColor;
            _button.interactable = false; // ��ȣ�ۿ� �Ұ�
        }
    }
}
