using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Observer
{
    // Start is called before the first frame update
    private bool _isDisplayOn;
    private bool _isTurboOn;
    private BikeController _bikeController;
    private float _currentHealth;
    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
    }
    void OnDisable()
    {
        RaceEventBus.UnSubscribe(RaceEventType.START, DisplayHUD);
    }

    void DisplayHUD()
    {
        _isDisplayOn = true;
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 100, 100, 200));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Health: " + _currentHealth);
        GUILayout.EndHorizontal();
        if (_isTurboOn)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Turbo Activated!");
            GUILayout.EndHorizontal();
        }
        if(_currentHealth < 50)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("WORNING: Low Health");
            GUILayout.EndHorizontal();
        }
        GUILayout.EndArea();
        if (_isDisplayOn)
        {
            if (GUILayout.Button("Stop Race"))
            {
                _isDisplayOn = false;
                RaceEventBus.Publish(RaceEventType.STOP);
            }
        }
    }

    public override void Notify(Subject subject)
    {
        if (!_bikeController)
        {
            _bikeController = subject.GetComponent<BikeController>();
        }
        if (_bikeController)
        {
            _isTurboOn = _bikeController.IsTurboOn;
            _currentHealth = _bikeController.CurrentHealth;
        }
    }
}
