using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
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
        _lineRenderer.SetPosition(1, startPosition); // 처음엔 시작 위치에서만 그려지게
    }

    // 레이저가 서서히 그려지는 함수
    public IEnumerator DrawLaser(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            Vector3 currentPos = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            _lineRenderer.SetPosition(1, currentPos);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _lineRenderer.SetPosition(1, endPosition); // 마지막에 정확하게 목표 지점 설정
    }

    // 레이저를 일정 시간 유지 후 비활성화하는 함수
    public void ActivateLaser(Vector3 startPosition, Vector3 endPosition, float laserDuration, float laserLifetime)
    {
        gameObject.SetActive(true);
        StartCoroutine(LaserRoutine(startPosition, endPosition, laserDuration, laserLifetime));
    }

    private IEnumerator LaserRoutine(Vector3 startPosition, Vector3 endPosition, float laserDuration, float laserLifetime)
    {
        yield return StartCoroutine(DrawLaser(startPosition, endPosition, laserDuration)); // 서서히 그리기
        yield return new WaitForSeconds(laserLifetime); // 유지 시간
        gameObject.SetActive(false); // 비활성화
    }
}
