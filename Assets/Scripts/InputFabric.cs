using UnityEngine;

public sealed class InputFabric : BaseSingleton<InputFabric>
{
    public BaseInputManager CreateInputManager() =>
        Input.touchSupported
            ? Instance.gameObject.AddComponent<TouchInput>()
            : Instance.gameObject.AddComponent<PcInput>();
}