using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientState : MonoBehaviour
{
    private BikeController _bikeController;
    // Start is called before the first frame update
    void Start()
    {
        _bikeController = FindObjectOfType<BikeController>();
    }

    // Update is called once per frame
    private void OnGUI()
    {
        if(GUILayout.Button("Start Bike"))
        {
            _bikeController.StartBike();
        }
        if (GUILayout.Button("Turn Left"))
        {
            _bikeController.Turn(Direction.Left);
        }
        if (GUILayout.Button("Turn Right"))
        {
            _bikeController.Turn(Direction.Right);
        }
        if (GUILayout.Button("Stop Bike"))
        {
            _bikeController.StopBike();
        }
        if (GUILayout.Button("Toggle Turbo"))
        {
            _bikeController.ToggleTurbo();
        }
    }
}
