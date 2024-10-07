using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPlayerSelectBtn : MonoBehaviour
{
    [SerializeField] private Image playerImage;
    private PlayerTypeEnum _playerType;
    private PlayerInfoSO _playerInfo;

    public string sceneName;

    public void Initialize(PlayerTypeEnum playerType, PlayerInfoSO sO)
    {
        _playerType = playerType;
        _playerInfo = sO;
        playerImage.sprite = sO.playerSpreite;
    }

    public void BtnYes()
    {
        DataManager.Instance.PlayerType = _playerType;
        DataManager.Instance.PlayerInfo = _playerInfo;

        LoadingSceneManager.LoadScene(sceneName);
    }

    public void BtnNo()
    {
        gameObject.SetActive(false);

        foreach (PlayerChoiseBtn item in PlayerChoiseBtn._btnList)
        {
            item.GetComponent<Button>().interactable = true;
        }
    }
}
