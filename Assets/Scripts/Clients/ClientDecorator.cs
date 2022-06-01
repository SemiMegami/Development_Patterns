using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDecorator : MonoBehaviour
{
    private BikeWeapon _bikeWeapon;
    private bool _isWeaponDecorated;
    // Start is called before the first frame update
    void Start()
    {
        _bikeWeapon = FindObjectOfType<BikeWeapon>();
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (!_isWeaponDecorated)
        {
            if(GUILayout.Button("Decorate Weapon"))
            {
                _bikeWeapon.Decorate();
                _isWeaponDecorated = !_isWeaponDecorated;
            }
           
        }
        if (_isWeaponDecorated)
        {
            if (GUILayout.Button("Reset Weapon"))
            {
                _bikeWeapon.Reset();
                _isWeaponDecorated = !_isWeaponDecorated;

            }
        }
        if(GUILayout.Button("Toggle Fire"))
        {
            _bikeWeapon.ToggleFire();
        }
    }
}
