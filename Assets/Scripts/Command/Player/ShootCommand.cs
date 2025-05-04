using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : IPlayerInputCommand
{
    public void Execute(PlayerControllerRefactored  player)
    {
        // Call the Shoot method on the player controller
        player.Shoot();
    }

}
