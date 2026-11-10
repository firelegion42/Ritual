using UnityEngine;

public abstract class GlobalControler : MonoBehaviour
{
    protected IMoveable move;


    protected virtual void Awake()
    {
        if(TryGetComponent<IMoveable>(out var moveComponent))
        {
            move = moveComponent;
        }
    }
}
