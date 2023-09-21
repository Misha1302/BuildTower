using UnityEngine;

public abstract class StateEventListener : MonoBehaviour
{
    protected virtual void OnGame()
    {
    }

    protected virtual void OnLose()
    {
    }
}