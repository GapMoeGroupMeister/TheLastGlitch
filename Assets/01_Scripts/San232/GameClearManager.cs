using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage; // �Ͼ�� �̹���
    [SerializeField] private float _fadeDuration = 1f; // ���̵� �ƿ� �ð�

    private void Start()
    {
        // FadeOut �ʱ�ȭ: ���İ��� 0���� ���� (���� ����)
        _fadeImage.color = new Color(1, 1, 1, 0);
    }

    public void GameClear()
    {
        // ���� �ð� ���߱�
        Time.timeScale = 0f;

        // ���̵� �ƿ� Ʈ��: ���İ��� 1�� (������ ����)�� �ٲٱ�
        _fadeImage.DOFade(1f, _fadeDuration).SetUpdate(true).OnComplete(() =>
        {
            // ���̵� �ƿ� �Ϸ� �� ���ϴ� �߰� �ൿ
            Debug.Log("Fade out complete");
            LoadingSceneManager.LoadScene("EndingScene");
        });
    }
}
