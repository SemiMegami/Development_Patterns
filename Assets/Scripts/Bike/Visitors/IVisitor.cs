using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor
{
    void Visit(BikeShield bikeShield);
    void Visit(BikeWeapon bikeWeapon);
    void Visit(BikeEngine bikeEngine);


}
