using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupVisitor 
{
    void Visit(SpeedBoostPickup pickup);
    void Visit(HealthPickup pickup);

}
