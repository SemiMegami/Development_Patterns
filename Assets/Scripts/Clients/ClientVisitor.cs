using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientVisitor : MonoBehaviour
{
    public PowerUp engingPowerUp;
    public PowerUp shieldPowerUp;
    public PowerUp weaponPowerUp;
    private BikeController _bikeController;

    void Start()
    {
         _bikeController = FindObjectOfType<BikeController>();
        Invoke("StartBike", 0.5f);
    }
    void StartBike()
    {
        _bikeController.StartBike();
    }

    void OnGUI()
    {
        if(GUILayout.Button("PowerUp Shield"))
        {
            _bikeController.Accept(shieldPowerUp);
        }
        if (GUILayout.Button("PowerUp Engine"))
        {
            _bikeController.Accept(engingPowerUp);
        }
        if (GUILayout.Button("PowerUp Weapon"))
        {
            _bikeController.Accept(weaponPowerUp);
        }
    }
}
