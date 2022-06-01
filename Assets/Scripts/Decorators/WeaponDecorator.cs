using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDecorator:IWeapon
{
    public float Range { get { return _decoratedWeapon.Range + _attachment.Range; } }
    public float Strength { get { return _decoratedWeapon.Strength + _attachment.Strength; } }
    public float Cooldown { get { return _decoratedWeapon.Cooldown + _attachment.Cooldown; } }
    public float Rate { get { return _decoratedWeapon.Rate + _attachment.Rate; } }

    private readonly IWeapon _decoratedWeapon;
    private readonly WeaponAttachment _attachment;
    public WeaponDecorator(IWeapon weapon, WeaponAttachment attachment)
    {
        _attachment = attachment;
        _decoratedWeapon = weapon;
    }
    
}
