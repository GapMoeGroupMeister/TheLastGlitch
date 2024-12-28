using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage; // �Ͼ�� �̹���
    [SerializeField] private float _fadeDuration = 1f; // ���̵� �ƿ� �ð�

    private void Start()
    {
        DOTween.Init();
        // FadeOut �ʱ�ȭ: ���İ��� 0���� ���� (���� ����)
        
    }

    public void GameClear()
    {
        //�̹��� ����
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.color = new Color(1, 1, 1, 0);

        // ���� �ð� ���߱�
        Time.timeScale = 0f;

        // ���̵� �ƿ� Ʈ��: ���İ��� 1�� (������ ����)�� �ٲٱ�
        _fadeImage.DOFade(1f, _fadeDuration).SetUpdate(true).OnComplete(() =>
        {
            // ���̵� �ƿ� �Ϸ� �� ���ϴ� �߰� �ൿ
            Debug.Log("Fade out complete");
            SceneManager.LoadScene("EndingScene");
        });
    }
}
