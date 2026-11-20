using UnityEngine;
using UnityEngine.InputSystem; 

public class Controller : GlobalControler
{


    public void OnMovement(InputAction.CallbackContext context)
    {
        move.Move(context.ReadValue<Vector2>());
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");

        if (context.performed)
        {
            interact.Interact();
        }
    }
}
