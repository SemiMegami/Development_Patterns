using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientEventBus : MonoBehaviour
{
    private bool _isButtonEnabled;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<HUDController>();

        gameObject.AddComponent<CountdownTimer>();
    
        _isButtonEnabled = true;
    }

     void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.STOP, Restart);
    }
     void OnDisable()
    {
        RaceEventBus.UnSubscribe(RaceEventType.STOP, Restart);
    }
    // Update is called once per frame
    private void Restart()
    {
        _isButtonEnabled = true;
    }
    private void OnGUI()
    {
        if (_isButtonEnabled)
        {
            if(GUILayout.Button("Start Countdown"))
            {
                _isButtonEnabled = false;
                RaceEventBus.Publish(RaceEventType.COUNTDOWN);
            }
        }
    }
}
