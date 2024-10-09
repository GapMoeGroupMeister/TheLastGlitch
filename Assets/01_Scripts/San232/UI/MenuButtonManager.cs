using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI 요소에 대한 참조 필요

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _goToBossButton;
    [SerializeField] private PlayerItemData _playerItemData;
    [SerializeField] private TextMeshProUGUI _buttonText;
    private Button _button; // Button 컴포넌트
    private Image _buttonImage; // 버튼의 이미지
    private Color _activeColor; // 버튼의 활성화 색상
    private Color _textActiveColor; // 버튼의 활성화 색상

    private Color _inactiveColor = Color.gray; // 버튼 비활성화 색상

    private void Awake()
    {
        _button = _goToBossButton.GetComponent<Button>();
        _buttonImage = _goToBossButton.GetComponent<Image>();

        if (_button == null || _buttonImage == null)
        {
            Debug.LogError("Button 또는 Image 컴포넌트가 존재하지 않습니다.");
            return;
        }

        // 현재 버튼의 색상을 activeColor로 저장
        _activeColor = _buttonImage.color;
        _textActiveColor = _buttonText.color;

        SetButtonState(false); // 초기 상태에서 회색으로 설정하고 상호작용 막기
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
                    SetButtonState(false); // 비활성화 (회색 + 상호작용 막기)
                    return;
                }
            }
        }

        SetButtonState(true); // 활성화 (원래 색상 + 상호작용 허용)
    }

    private void SetButtonState(bool isActive)
    {
        if (isActive)
        {
            _buttonImage.color = _activeColor; // 원래 색상으로 설정
            _buttonText.color = _textActiveColor;
            _button.interactable = true; // 상호작용 가능
        }
        else
        {
            _buttonImage.color = _inactiveColor; // 회색으로 설정
            _buttonText.color = _inactiveColor;
            _button.interactable = false; // 상호작용 불가
        }
    }
}
