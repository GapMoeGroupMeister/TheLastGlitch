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
        // 원본 텍스트 저장 후 초기 출력은 빈 문자열로 설정
        _endingTitleText = _targetText.text.ToString();
        _targetText.text = "";

        // 코루틴 실행
        StartCoroutine(TextPrint(_delay));
    }

    private IEnumerator TextPrint(float d)
    {
        int count = 0;

        while (count <= _endingTitleText.Length)
        {
            if (count < _endingTitleText.Length)
            {
                // 현재까지 출력된 문자와 마지막에 _ 추가
                _targetText.text = _endingTitleText.Substring(0, count) + "_";
            }
            else
            {
                // 마지막 문자까지 출력된 경우 _ 없이 출력
                _targetText.text = _endingTitleText;
            }

            count++;

            // 설정한 딜레이 동안 대기
            yield return new WaitForSeconds(_delay);
        }
    }
}
