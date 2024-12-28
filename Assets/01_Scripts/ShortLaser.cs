using System.Collections;
using UnityEngine;

public class ShortLaser : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    private bool isDrawing = false; // �ߺ� ���� ������ ���� �÷���

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // �������� ���� ������ �� ������ ����
    public void SetLaserPositions(Vector3 startPosition, Vector3 endPosition)
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition); // �� ���� ����
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

        // �������� ��Ȯ�ϰ� �� ��ġ ����
        _lineRenderer.SetPosition(1, endPosition);
    }

    // �������� ���� �ð� ���� �� ��Ȱ��ȭ�ϴ� �Լ�
    public void ActivateLaser(Vector3 startPosition, Vector3 targetPosition, float laserDuration, float laserLifetime)
    {
        if (isDrawing) return; // �̹� ���� ���� ��� ����
        isDrawing = true;

        // �������� ������ ���
        Vector3 direction = targetPosition - startPosition;
        Vector3 endPosition = startPosition + direction.normalized * direction.magnitude;

        // ������ ����
        gameObject.SetActive(true); // ������Ʈ Ȱ��ȭ
        _lineRenderer.enabled = true; // LineRenderer Ȱ��ȭ
        StartCoroutine(LaserRoutine(startPosition, endPosition, laserDuration, laserLifetime));
    }

    private IEnumerator LaserRoutine(Vector3 startPosition, Vector3 endPosition, float laserDuration, float laserLifetime)
    {
        // ������ �׸���
        yield return StartCoroutine(DrawLaser(startPosition, endPosition, laserDuration));

        // ���� �ð� ���
        yield return new WaitForSeconds(laserLifetime);

        // ��Ȱ��ȭ
        _lineRenderer.enabled = false; // LineRenderer ��Ȱ��ȭ
        gameObject.SetActive(false); // GameObject ��Ȱ��ȭ
        isDrawing = false; // �ٽ� ���� �����ϵ��� �÷��� �ʱ�ȭ
    }
}
