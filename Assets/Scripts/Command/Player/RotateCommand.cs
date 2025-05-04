using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : IPlayerInputCommand
{
    private Vector2 targetDirection;

    // Constructr for rotation
    public RotateCommand(Vector2 targetDirection)
    {
        this.targetDirection = targetDirection;
    }
    // Execute the command to rotate the player towards the target direction
    public void Execute(PlayerControllerRefactored player)
    {
        player.Rotate(targetDirection);
    }
    
}
