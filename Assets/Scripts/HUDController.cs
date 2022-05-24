using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isDisplayOn;
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
     
        if (_isDisplayOn)
        {
            if (GUILayout.Button("Stop Race"))
            {
                _isDisplayOn = false;
                RaceEventBus.Publish(RaceEventType.STOP);
            }
        }
    }
}
