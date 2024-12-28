using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage; // 하얀색 이미지
    [SerializeField] private float _fadeDuration = 1f; // 페이드 아웃 시간

    private void Start()
    {
        DOTween.Init();
        // FadeOut 초기화: 알파값을 0으로 설정 (투명 상태)
        
    }

    public void GameClear()
    {
        //이미지 설정
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.color = new Color(1, 1, 1, 0);

        // 게임 시간 멈추기
        Time.timeScale = 0f;

        // 페이드 아웃 트윈: 알파값을 1로 (불투명 상태)로 바꾸기
        _fadeImage.DOFade(1f, _fadeDuration).SetUpdate(true).OnComplete(() =>
        {
            // 페이드 아웃 완료 후 원하는 추가 행동
            Debug.Log("Fade out complete");
            SceneManager.LoadScene("EndingScene");
        });
    }
}
