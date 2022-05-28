using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : Subject
{

    [SerializeField]
    private float health = 100;
    public float CurrentHealth
    {
        get { return health; }
    }

    private Vector3 _originalPosition;
    public bool IsTurboOn
    {
        get;private set;
    }
    private bool _isEngineOn;
    private HUDController _hudController;
    private CameraController _cameraController;
    private string _status;
    public float maxSpeed = 2.0f;
    public float turboSpeed = 3.0f;
    public float turnDistance = 2.0f;
    public float CurrentSpeed { get; set; }
    public Direction CurrentTurnDirection { get; private set; }
    private IBikeState _startState, _stopState, _turnState, _turboState;
    private BikeStateContext _bikeStateContext;

    private void Awake()
    {
        _hudController = gameObject.AddComponent<HUDController>();
        _cameraController = FindObjectOfType<CameraController>();
    }

    void Start()
    {
        _originalPosition = transform.position;
        _bikeStateContext = new BikeStateContext(this);
        _startState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTurnState>();
        _turboState = gameObject.AddComponent<BikeTurboState>();
        _bikeStateContext.Transtiion(_stopState);
        StartEngine();
    }

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
        if (_hudController)
        {
            Attach(_hudController);
        }
        if (_cameraController) {
            Attach(_cameraController);
        }
    }
    private void OnDisable()
    {
        RaceEventBus.UnSubscribe(RaceEventType.START, StartBike);
        RaceEventBus.UnSubscribe(RaceEventType.STOP, StopBike);

        if (_hudController)
        {
            Detach(_hudController);
        }
        if (_cameraController)
        {
            Detach(_cameraController);
        }
    }

    private void StartEngine()
    {
        _isEngineOn = true;
        NotifyObservers();
    }

    public void StartBike()
    {
        IsTurboOn = false;
        _status = "Started";
        _bikeStateContext.Transtiion(_startState);
    }

    public void TurboBike()
    {
        IsTurboOn = true;
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
        if(_status == "Started" || _status == "Turbo" && _isEngineOn)
        {
            IsTurboOn = !IsTurboOn;
            Debug.Log("Turbo Active: " + IsTurboOn.ToString());
            if (IsTurboOn)
            {
                TurboBike();
            }
            else
            {
                StartBike();
            }
        }
        NotifyObservers();
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

    public void TakeDamage(float amount)
    {
        health -= amount;
        IsTurboOn = false;
        StartBike();
        NotifyObservers();
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
    private void NotifyObservers()
    {

    }

    private void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS: " + _status);
    }
}
