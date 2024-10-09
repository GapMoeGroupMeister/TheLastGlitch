using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private Image fadeImage; // 하얀색 이미지
    [SerializeField] private float fadeDuration = 1f; // 페이드 아웃 시간

    private void Start()
    {
        // FadeOut 초기화: 알파값을 0으로 설정 (투명 상태)
        fadeImage.color = new Color(1, 1, 1, 0);
    }

    public void GameClear()
    {
        // 게임 시간 멈추기
        Time.timeScale = 0f;

        // 페이드 아웃 트윈: 알파값을 1로 (불투명 상태)로 바꾸기
        fadeImage.DOFade(1f, fadeDuration).SetUpdate(true).OnComplete(() =>
        {
            // 페이드 아웃 완료 후 원하는 추가 행동
            Debug.Log("Fade out complete");
            LoadingSceneManager.LoadScene("EndingScene");
        });
    }
}
