using UnityEngine;

public sealed class TouchInput : BaseInputManager
{
    private void Update()
    {
        if (Input.touchCount != 0)
            actions?.Invoke();
    }
}