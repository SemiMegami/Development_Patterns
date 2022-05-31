using UnityEngine;
public class BikeEngine: MonoBehaviour, IBikeElement
{
    public float turboBoost = 25; // mph
    public float maxTurboBoost = 200;

    private bool _isTurboOn;
    private float _defaultSpeed = 300;

    public float CurrentSpeed
    {
        get
        {
            if (_isTurboOn)
            {
                return _defaultSpeed + turboBoost;
            }
            else
            {
                return _defaultSpeed;
            }
        }
    }

    public void ToggleTurbo()
    {
        _isTurboOn = !_isTurboOn;
    }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(125, 20, 200, 20), "Turbo Boost: " + turboBoost);
    }
}
