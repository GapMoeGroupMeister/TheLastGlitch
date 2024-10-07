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

        _lineRenderer.SetPosition(1, endPosition); // ��ǥ ���� ��� �������� ��� �����մϴ�.
    }

    // �������� ������ �׷����� �Լ�
    public IEnumerator DrawLaser(Vector3 startPosition, Vector3 endPosition, float duration)
    {

        float elapsedTime = 0f;
        // ���� ��ġ ����
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, startPosition); // �� ��ġ �ʱ�ȭ

        while (elapsedTime < duration)
        {
            // ���� ������ ���� �������� �׷��ֱ�
            Vector3 currentPos = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            _lineRenderer.SetPosition(1, currentPos); // ���� ��ġ ������Ʈ
            elapsedTime += Time.deltaTime;
            yield return null; // �� ������ ���
        }

        _lineRenderer.SetPosition(1, endPosition); // �������� ��Ȯ�ϰ� ��ǥ ���� ����
    }

    // �������� ���� �ð� ���� �� ��Ȱ��ȭ�ϴ� �Լ�
    public void ActivateLaser(Vector3 startPosition, Vector3 direction, float laserDuration, float laserLifetime)
    {
        // �̹� Ȱ��ȭ�� ��� ����
        if (gameObject.activeSelf) return;

        gameObject.SetActive(true);
        StartCoroutine(LaserRoutine(startPosition, direction, laserDuration, laserLifetime));
    }

    private IEnumerator LaserRoutine(Vector3 startPosition, Vector3 direction, float laserDuration, float laserLifetime)
    {

        // ������ �׸���
        yield return StartCoroutine(DrawLaser(startPosition, direction, laserDuration));

        // ���� �ð� ���
        yield return new WaitForSeconds(laserLifetime);

        // ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
