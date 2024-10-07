using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLaser : MonoBehaviour
{
    public LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLaserPositions(Vector3 startPosition, Vector3 endPosition)
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, startPosition);

        _lineRenderer.SetPosition(1, endPosition); // 목표 지점 대신 방향으로 길게 설정합니다.
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

        _lineRenderer.SetPosition(1, endPosition); // 마지막에 정확하게 목표 지점 설정
    }

    // 레이저를 일정 시간 유지 후 비활성화하는 함수
    public void ActivateLaser(Vector3 startPosition, Vector3 direction, float laserDuration, float laserLifetime)
    {
        // 이미 활성화된 경우 리턴
        if (gameObject.activeSelf) return;

        gameObject.SetActive(true);
        StartCoroutine(LaserRoutine(startPosition, direction, laserDuration, laserLifetime));
    }

    private IEnumerator LaserRoutine(Vector3 startPosition, Vector3 direction, float laserDuration, float laserLifetime)
    {

        // 서서히 그리기
        yield return StartCoroutine(DrawLaser(startPosition, direction, laserDuration));

        // 유지 시간 대기
        yield return new WaitForSeconds(laserLifetime);

        // 비활성화
        gameObject.SetActive(false);
    }
}
