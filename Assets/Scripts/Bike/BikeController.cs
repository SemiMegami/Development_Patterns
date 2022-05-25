using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    private Vector3 _originalPosition;
    private bool _isTurboOn;
    private string _status;
    public float maxSpeed = 2.0f;
    public float turboSpeed = 3.0f;
    public float turnDistance = 2.0f;
    public float CurrentSpeed { get; set; }
    public Direction CurrentTurnDirection { get; private set; }
    private IBikeState _startState, _stopState, _turnState, _turboState;
    private BikeStateContext _bikeStateContext;
    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.position;
        _bikeStateContext = new BikeStateContext(this);
        _startState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTurnState>();
        _turboState = gameObject.AddComponent<BikeTurboState>();
        _bikeStateContext.Transtiion(_stopState);
    }

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
    }
    private void OnDisable()
    {
        RaceEventBus.UnSubscribe(RaceEventType.START, StartBike);
        RaceEventBus.UnSubscribe(RaceEventType.STOP, StopBike);
    }

    public void StartBike()
    {
        _isTurboOn = false;
        _status = "Started";
        _bikeStateContext.Transtiion(_startState);
    }

    public void TurboBike()
    {
        _isTurboOn = true;
        _status = "Turbo";
        _bikeStateContext.Transtiion(_turboState);
    }
    public void StopBike()
    {
        _status = "Stoped";
        _bikeStateContext.Transtiion(_stopState);
    }

    public void ToggleTurbo()
    {
        if(_status == "Started" || _status == "Turbo")
        {
            _isTurboOn = !_isTurboOn;
            Debug.Log("Turbo Active: " + _isTurboOn.ToString());
            if (_isTurboOn)
            {
                TurboBike();
            }
            else
            {
                StartBike();
            }
        }
       
    }

    public void ResetPosition()
    {
        transform.position = _originalPosition;
    }

    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;
        _bikeStateContext.Transtiion(_turnState);
    }

    private void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS: " + _status);
    }
}
