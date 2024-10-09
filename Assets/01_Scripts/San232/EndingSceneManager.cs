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
    [SerializeField] private Image _fadeImage; // �Ͼ�� �̹���
    [SerializeField] private float _fadeDuration = 0.5f; // ���̵� �� �ð�

    private void Awake()
    {
        _fadeImage.color = new Color(1, 1, 1, 1);

        // ���� �ؽ�Ʈ ���� �� �ʱ� ����� �� ���ڿ��� ����
        _endingTitleText = _targetText.text.ToString();
        _targetText.text = "";

        
    }

    public void EnterEndingScene()
    {
        // ���� �ð� ���߱�
        Time.timeScale = 0f;

        // ���̵� �ƿ� Ʈ��: ���İ��� 1�� (������ ����)�� �ٲٱ�
        _fadeImage.DOFade(1f, _fadeDuration).SetUpdate(true).OnComplete(() =>
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
    }
}
