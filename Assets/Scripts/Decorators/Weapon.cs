using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IWeapon
{
    public float Range { get { return _confiq.Range; } }
    public float Strength { get { return _confiq.Strength; } }
    public float Cooldown { get { return _confiq.Cooldown; } }
    public float Rate { get { return _confiq.Rate; } }

    private readonly WeaponConfiq _confiq;
    public Weapon(WeaponConfiq weaponConfiq)
    {
        _confiq = weaponConfiq;
    }
   
}
