using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FeedBackTester : MonoBehaviour
{
    public UnityEvent OnFeedBackTesterEvent;

    private void Start()
    {
        OnFeedBackTesterEvent?.Invoke();
    }
}
