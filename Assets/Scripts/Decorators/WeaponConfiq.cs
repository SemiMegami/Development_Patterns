using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewWeaponAttachment", menuName = "Weapon/Confiq", order = 1)]
public class WeaponConfiq :ScriptableObject , IWeapon
{
    [Range(0, 50)]
    [Tooltip("Increase rate of firing per second")]
    [SerializeField] public float rate;

    [Range(0, 50)]
    [Tooltip("Increase weapon range")]
    [SerializeField] public float range;

    [Range(0, 100)]
    [Tooltip("Increase weapon strength")]
    [SerializeField] public float strength;

    [Range(0, -5)]
    [Tooltip("Reduce cooldown duration")]
    [SerializeField] public float cooldown;

    public string weaponName;
    public GameObject weaponPrefab;
    public string weaponDescription;
    public float Range { get { return range; } }

    public float Strength { get { return strength; } }

    public float Cooldown { get { return cooldown; } }

    public float Rate { get { return rate; } }

}
