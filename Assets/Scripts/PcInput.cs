using UnityEngine;

public sealed class PcInput : BaseInputManager
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.X))
            actions?.Invoke();
    }
}