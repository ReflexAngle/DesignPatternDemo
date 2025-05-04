using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : IPlayerInputCommand
{
    private Vector2 direction;
    // constructor to initialize the direction of the move command
    public MoveCommand(Vector2 direction)
    {
        this.direction = direction;
    }
    // execute the command to move the player in the given direction
    public void Execute(PlayerControllerRefactored  player)
    {
        player.Move(direction);
    }
}
