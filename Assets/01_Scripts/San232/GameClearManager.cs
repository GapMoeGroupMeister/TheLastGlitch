using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private Image fadeImage; // �Ͼ�� �̹���
    [SerializeField] private float fadeDuration = 1f; // ���̵� �ƿ� �ð�

    private void Start()
    {
        // FadeOut �ʱ�ȭ: ���İ��� 0���� ���� (���� ����)
        fadeImage.color = new Color(1, 1, 1, 0);
    }

    public void GameClear()
    {
        // ���� �ð� ���߱�
        Time.timeScale = 0f;

        // ���̵� �ƿ� Ʈ��: ���İ��� 1�� (������ ����)�� �ٲٱ�
        fadeImage.DOFade(1f, fadeDuration).SetUpdate(true).OnComplete(() =>
        {
            // ���̵� �ƿ� �Ϸ� �� ���ϴ� �߰� �ൿ
            Debug.Log("Fade out complete");
            LoadingSceneManager.LoadScene("EndingScene");
        });
    }
}
