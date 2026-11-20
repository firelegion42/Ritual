using UnityEngine;

public abstract class GlobalControler : MonoBehaviour
{
    protected IMoveable move;
    protected IInteractable interact;


    protected virtual void Awake()
    {
        if(TryGetComponent<IMoveable>(out var moveComponent))
        {
            move = moveComponent;
        }

        if(TryGetComponent<IInteractable>(out var interactableComponent))
        {
            interact = interactableComponent;
        }
    }
}
