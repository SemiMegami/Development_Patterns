using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;
    public float CurrentSpeed { get; set; }
    public Direction CurrentTurnDirection { get; private set; }
    private IBikeState _startState, _stopState, _turnState;
    private BikeStateContext _bikeStateContext;
    // Start is called before the first frame update
    void Start()
    {
        _bikeStateContext = new BikeStateContext(this);
        _startState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTurnState>();
        _bikeStateContext.Transtiion(_stopState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBike()
    {
        _bikeStateContext.Transtiion(_startState);
    }
    public void Stopike()
    {
        _bikeStateContext.Transtiion(_stopState);
    }

    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;
        _bikeStateContext.Transtiion(_turnState);
    }
}
