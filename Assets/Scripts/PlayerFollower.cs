using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    Transform _bikeTransform;
    Vector3 _distance;
    // Start is called before the first frame update
    void Start()
    {
        _bikeTransform = FindObjectOfType<BikeController>().transform;
        _distance = transform.position - _bikeTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 V = _distance+ _bikeTransform.position;
        transform.position = new Vector3(0, V.y,V.z);
    }
}
