using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public TrackController trackController;

    private void OnDestroy()
    {
        if (trackController)
        {
            trackController.LoadNextSegments();
        }
    }
}
