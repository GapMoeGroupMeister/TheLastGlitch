using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RocketMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 controlPoint1;
    private Vector3 controlPoint2;
    private Vector3 targetPosition;
    private float duration;
    private float timeElapsed;

    public UnityEvent OnDestroyEvent;

    public void Initialize(Vector3 start, Vector3 cp1, Vector3 cp2, Vector3 target, float duration)
    {
        startPosition = start;
        controlPoint1 = cp1;
        controlPoint2 = cp2;
        targetPosition = target;
        this.duration = duration;
        timeElapsed = 0f;
    }

    private void Update()
    {
        if (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / duration;

            // Bezier Curve °è»ê
            Vector3 position = Mathf.Pow(1 - t, 3) * startPosition +
                               3 * Mathf.Pow(1 - t, 2) * t * controlPoint1 +
                               3 * (1 - t) * Mathf.Pow(t, 2) * controlPoint2 +
                               Mathf.Pow(t, 3) * targetPosition;

            transform.position = position;
        }
        else
        {
            Destroy(gameObject);
            OnDestroyEvent?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        OnDestroyEvent?.Invoke();
    }
}
