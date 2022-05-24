using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeStartState : MonoBehaviour,IBikeState
{

    private BikeController _bikeController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_bikeController)
        {
            if(_bikeController.CurrentSpeed > 0)
            {
                _bikeController.transform.Translate(Vector3.forward * (_bikeController.CurrentSpeed * Time.deltaTime));
            }
        }
    }
    public void Handle(BikeController controller)
    {
        if (!_bikeController)
        {
            _bikeController = controller;
        }
        _bikeController.CurrentSpeed = _bikeController.maxSpeed;
    }
}
