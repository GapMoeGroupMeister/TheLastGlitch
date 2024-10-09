using UnityEngine;
using TMPro;
using System.Collections;

public class EndingSceneManager : MonoBehaviour
{
    private string _endingTitleText;
    [SerializeField] private TMP_Text _targetText;
    [SerializeField] private float _delay = 0.125f;

    private void Awake()
    {
        // ���� �ؽ�Ʈ ���� �� �ʱ� ����� �� ���ڿ��� ����
        _endingTitleText = _targetText.text.ToString();
        _targetText.text = "";

        // �ڷ�ƾ ����
        StartCoroutine(TextPrint(_delay));
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
