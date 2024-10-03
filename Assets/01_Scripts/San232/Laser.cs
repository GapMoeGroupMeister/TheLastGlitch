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
        _lineRenderer.SetPosition(1, startPosition); // ó���� ���� ��ġ������ �׷�����
    }

    // �������� ������ �׷����� �Լ�
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
        _lineRenderer.SetPosition(1, endPosition); // �������� ��Ȯ�ϰ� ��ǥ ���� ����
    }

    // �������� ���� �ð� ���� �� ��Ȱ��ȭ�ϴ� �Լ�
    public void ActivateLaser(Vector3 startPosition, Vector3 endPosition, float laserDuration, float laserLifetime)
    {
        gameObject.SetActive(true);
        StartCoroutine(LaserRoutine(startPosition, endPosition, laserDuration, laserLifetime));
    }

    private IEnumerator LaserRoutine(Vector3 startPosition, Vector3 endPosition, float laserDuration, float laserLifetime)
    {
        yield return StartCoroutine(DrawLaser(startPosition, endPosition, laserDuration)); // ������ �׸���
        yield return new WaitForSeconds(laserLifetime); // ���� �ð�
        gameObject.SetActive(false); // ��Ȱ��ȭ
    }
}
