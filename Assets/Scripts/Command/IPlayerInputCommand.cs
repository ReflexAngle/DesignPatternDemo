using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInputCommand 
{
    void Execute(PlayerControllerRefactored player); // This method will be called to execute the command


}
