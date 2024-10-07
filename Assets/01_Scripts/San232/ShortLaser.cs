using System.Collections;
using UnityEngine;

public class ShortLaser : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    private bool isDrawing = false; // 중복 실행 방지를 위한 플래그

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // 레이저의 시작 지점과 끝 지점을 설정
    public void SetLaserPositions(Vector3 startPosition, Vector3 endPosition)
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition); // 끝 지점 설정
    }

    // 레이저가 서서히 그려지는 함수
    public IEnumerator DrawLaser(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        float elapsedTime = 0f;

        // 시작 위치 설정
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, startPosition); // 끝 위치 초기화

        while (elapsedTime < duration)
        {
            // 선형 보간을 통해 레이저를 그려주기
            Vector3 currentPos = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            _lineRenderer.SetPosition(1, currentPos); // 현재 위치 업데이트
            elapsedTime += Time.deltaTime;
            yield return null; // 매 프레임 대기
        }

        // 마지막에 정확하게 끝 위치 설정
        _lineRenderer.SetPosition(1, endPosition);
    }

    // 레이저를 일정 시간 유지 후 비활성화하는 함수
    public void ActivateLaser(Vector3 startPosition, Vector3 targetPosition, float laserDuration, float laserLifetime)
    {
        if (isDrawing) return; // 이미 실행 중인 경우 리턴
        isDrawing = true;

        // 레이저의 방향을 계산
        Vector3 direction = targetPosition - startPosition;
        Vector3 endPosition = startPosition + direction.normalized * direction.magnitude;

        // 레이저 시작
        gameObject.SetActive(true); // 오브젝트 활성화
        _lineRenderer.enabled = true; // LineRenderer 활성화
        StartCoroutine(LaserRoutine(startPosition, endPosition, laserDuration, laserLifetime));
    }

    private IEnumerator LaserRoutine(Vector3 startPosition, Vector3 endPosition, float laserDuration, float laserLifetime)
    {
        // 서서히 그리기
        yield return StartCoroutine(DrawLaser(startPosition, endPosition, laserDuration));

        // 유지 시간 대기
        yield return new WaitForSeconds(laserLifetime);

        // 비활성화
        _lineRenderer.enabled = false; // LineRenderer 비활성화
        gameObject.SetActive(false); // GameObject 비활성화
        isDrawing = false; // 다시 실행 가능하도록 플래그 초기화
    }
}
