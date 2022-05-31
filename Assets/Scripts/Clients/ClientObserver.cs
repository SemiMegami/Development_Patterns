using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientObserver : MonoBehaviour
{
    private BikeController _bikeController;
    // Start is called before the first frame update
    void Start()
    {
        _bikeController = FindObjectOfType<BikeController>();
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUILayout.Button("Start Bike"))
        {
            if (_bikeController)
            {
                _bikeController.StartBike();
            }

        }
        if (GUILayout.Button("Damage Bike"))
        {
            if (_bikeController)
            {
                _bikeController.TakeDamage(15);
            }
           
        }
        if(GUILayout.Button("Toggle Turbo"))
        {
            if (_bikeController)
            {
                _bikeController.ToggleTurbo();
            }
        }
    }
}
