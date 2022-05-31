using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PowerUp powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BikeController>())
        {
            other.GetComponent<BikeController>().Accept(powerUp);
            Destroy(gameObject);
        }
    }
}
