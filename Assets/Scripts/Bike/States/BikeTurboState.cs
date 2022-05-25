using UnityEngine;

public class BikeTurboState : MonoBehaviour,IBikeState
{

    private BikeController _bikeController;
    public void Handle(BikeController bikeController)
    {
        if (!_bikeController)
        {
            _bikeController = bikeController;
        }
        _bikeController.CurrentSpeed = _bikeController.turboSpeed;
    }
}
