using System.Collections;
using UnityEngine;
public class BikeWeapon:MonoBehaviour, IBikeElement
{
    [Header("Range")]
    public int range = 5;
    public int maxRange = 25;
    [Header("Strength")]
    public float strength = 25;
    public float maxStrength = 50;

    public WeaponConfiq weaponConfiq;
    public WeaponAttachment mainAttachment;
    public WeaponAttachment secondaryAttachment;

    private bool _isFiring;
    private IWeapon _weapon;
    private bool _isDecorated;

    private void Start()
    {
        _weapon = new Weapon(weaponConfiq);
    }
    public void Fire()
    {
        Debug.Log("Weapon Fired!");
    }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    void OnGUI()
    {
        GUI.color = Color.green;
        if (_weapon == null)
        {
            // for visitor pattern
            GUI.Label(new Rect(125, 40, 200, 20), "Weapon Range: " + range);
            GUI.Label(new Rect(125, 60, 200, 20), "Weapon Strength: " + strength);
        }
        else
        {
            // for decorator pattern
            GUI.Label(new Rect(125, 40, 200, 20), "Range: " + _weapon.Range);
            GUI.Label(new Rect(125, 60, 200, 20), "Strength: " + _weapon.Strength);
            GUI.Label(new Rect(125, 80, 200, 20), "Cooldown: " + _weapon.Cooldown);
            GUI.Label(new Rect(125, 100, 200, 20), "Firing Rate: " + _weapon.Rate);
            GUI.Label(new Rect(125, 120, 200, 20), "Firing: " + _isFiring);
            if (mainAttachment && _isDecorated)
            {
                GUI.Label(new Rect(125, 140, 200, 20), "Main Attachment: " + mainAttachment.name);
            }
            if (secondaryAttachment && _isDecorated)
            {
                GUI.Label(new Rect(125, 160, 200, 20), "Secondary Attachment: " + secondaryAttachment.name);
            }
        }
       
    }
    
    public void ToggleFire()
    {
        _isFiring = !_isFiring;
        StartCoroutine(FireWeapon());
    }

    IEnumerator FireWeapon()
    {
        float firingRate = 1 / _weapon.Rate;
        while (_isFiring)
        {
            yield return new WaitForSeconds(firingRate);
            Debug.Log("fire");  
        }
    }
    public void Reset()
    {
        _weapon = new Weapon(weaponConfiq);
        _isDecorated = !_isDecorated;
    }

    public void Decorate()
    {
        if(mainAttachment && !secondaryAttachment)
        {
            _weapon = new WeaponDecorator(_weapon, mainAttachment);
        }
        if(mainAttachment && secondaryAttachment)
        {
            _weapon = new WeaponDecorator(new WeaponDecorator(_weapon, mainAttachment), secondaryAttachment);
        }
        _isDecorated = !_isDecorated;
    }
}
