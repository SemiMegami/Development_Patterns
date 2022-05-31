using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : Subject,IBikeElement
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
    public float turnDistance = 2.0f;
    public float CurrentSpeed { get; set; }
    public Direction CurrentTurnDirection { get; private set; }
    private IBikeState _startState, _stopState, _turnState;
    private BikeStateContext _bikeStateContext;
    public List<IBikeElement> _bikeElements = new List<IBikeElement>();
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

        
        _bikeStateContext.Transtiion(_stopState);

        _bikeElements.Add(gameObject.AddComponent<BikeShield>());
        _bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
        _bikeElements.Add(gameObject.AddComponent<BikeEngine>());

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
        _status = "Started";
        _bikeStateContext.Transtiion(_startState);
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
        NotifyObservers();
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
  
    private void OnGUI()
    {

        GUI.color = Color.green;
        GUI.Label(new Rect(10, 160, 200, 20), "BIKE STATUS: " + _status);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (IBikeElement element in _bikeElements)
        {
            element.Accept(visitor);
        }
    }
}
