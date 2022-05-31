using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp",menuName = "PowerUp")]
public class PowerUp : ScriptableObject, IVisitor
{
    public string powerUpName;
    public GameObject powerupPrefab;
    public string powerupDescription;

    [Tooltip("Fully heal shield")]
    public bool healShield;

    [Range(0,50)]
    [Tooltip("Boost turbo setting up to increments of 50/mph")]
    public float turboBoost;

    [Range(0, 25)]
    [Tooltip("Boost weapon range up to increments of 25 units")]
    public int weaponRange;

    [Range(0, 50)]
    [Tooltip("Boost weapon strength up to increments of 50%")]
    public float weaponStrength;

    public void Visit(BikeShield bikeShield)
    {
        if (healShield)
        {
            bikeShield.health = 100;
        }
    }
    public void Visit(BikeWeapon bikeWeapon)
    {
        int range = bikeWeapon.range += weaponRange;
        if (range >= bikeWeapon.maxRange)
        {
            bikeWeapon.range = bikeWeapon.maxRange;
        }
        else
        {
            bikeWeapon.range = range;
        }
        float strength = bikeWeapon.strength += Mathf.Round(bikeWeapon.strength * weaponStrength / 100);
        if (strength >= bikeWeapon.maxStrength)
        {
            bikeWeapon.strength = bikeWeapon.maxStrength;
        }
        else
        {
            bikeWeapon.strength = strength;
        }
    }
    public void Visit(BikeEngine bikeEngine)
    {
        float boost = bikeEngine.turboBoost += turboBoost;
        if(boost < 0)
        {
            bikeEngine.turboBoost = 0;
        }
        if(boost >= bikeEngine.maxTurboBoost)
        {
            bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
        }
    }

    
}
