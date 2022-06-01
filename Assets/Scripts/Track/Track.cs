using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Track", menuName = "Track")]
public class Track : ScriptableObject
{
    [Tooltip("The expected length of segments")]
    public float segmentLength;
    [Tooltip("Add segments in expected loading order")]
    public List<GameObject> segment = new List<GameObject>();
}
