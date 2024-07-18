using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayFeedback : MonoBehaviour
{
    private List<Feedback> _feedbackToPlay;

    private void Awake()
    {
        _feedbackToPlay = GetComponents<Feedback>().ToList();
    }

    public void PlayFeedbacks()
    {
         StopFeedbacks();
        _feedbackToPlay.ForEach(f => f.PlayFeedback());
    }

    private void StopFeedbacks()
    {
        _feedbackToPlay.ForEach(f => f.StopFeedback());
    }
}
