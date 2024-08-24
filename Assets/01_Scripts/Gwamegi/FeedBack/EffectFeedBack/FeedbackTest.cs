using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;

public class FeedbackTest : MonoBehaviour
{
    public UnityEvent OnFeedbackEvent;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            OnFeedbackEvent?.Invoke();
        }
    }
}
