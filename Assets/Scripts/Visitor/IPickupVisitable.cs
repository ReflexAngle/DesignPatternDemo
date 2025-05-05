using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupVisitable 
{
    void AcceptPickup(IPickupVisitor visitor); // Method to accept a pickup visitor
    
}
