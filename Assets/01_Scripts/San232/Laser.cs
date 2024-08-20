using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLaserPositions(Vector3 startPosition, Vector3 endPosition)
    {
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);
    }

    public void ActivateLaser(float delay)
    {
        gameObject.SetActive(true);
        StartCoroutine(LaserDelayRoutine(delay));
        gameObject.SetActive(false);
    }

    public IEnumerator LaserDelayRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
