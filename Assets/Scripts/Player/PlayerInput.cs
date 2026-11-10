using UnityEngine;
using UnityEngine.InputSystem; 

public class Controller : GlobalControler
{


    public void OnMovement(InputAction.CallbackContext context)
    {
        move.Move(context.ReadValue<Vector2>());
    }
}
