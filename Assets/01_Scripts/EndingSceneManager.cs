using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class EndingSceneManager : MonoBehaviour
{
    private string _endingTitleText;
    [SerializeField] private TMP_Text _targetText;
    [SerializeField] private float _delay = 0.125f;
    [SerializeField] private Image _fadeImage; // �Ͼ�� Panel
    [SerializeField] private float _fadeDuration = 0.5f; // ���̵� �� �ð�

    private float waitingTime = 5f;

    private void Awake()
    {
        DOTween.Init();
        _fadeImage.color = new Color(1, 1, 1, 1);

        // ���� �ؽ�Ʈ ���� �� �ʱ� ����� �� ���ڿ��� ����
        _endingTitleText = _targetText.text.ToString();
        _targetText.text = "";

        EnterEndingScene();
    }

    private void EnterEndingScene()
    {
        // ���̵� �ƿ� Ʈ��: ���İ��� 0���� (���� ����)�� �ٲٱ�
        _fadeImage.DOFade(0f, _fadeDuration).SetUpdate(true).OnComplete(() =>
        {
            // ���̵� �ƿ� �Ϸ� �� ���ϴ� �߰� �ൿ
            Debug.Log("Fade out complete");
            // �ڷ�ƾ ����
            StartCoroutine(TextPrint(_delay));
        });
    }

    private IEnumerator TextPrint(float d)
    {
        int count = 0;

        while (count <= _endingTitleText.Length)
        {
            if (count < _endingTitleText.Length)
            {
                // ������� ��µ� ���ڿ� �������� _ �߰�
                _targetText.text = _endingTitleText.Substring(0, count) + "_";
            }
            else
            {
                // ������ ���ڱ��� ��µ� ��� _ ���� ���
                _targetText.text = _endingTitleText;
            }

            count++;

            // ������ ������ ���� ���
            yield return new WaitForSeconds(_delay);
        }

        yield return new WaitForSeconds(waitingTime);

        LoadingSceneManager.LoadScene("Title");
    }
}
