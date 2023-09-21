using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;

    public BaseInputManager Input { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public LevelGenerator LevelGenerator => levelGenerator;

    private void Awake()
    {
        Input = gameObject.AddComponent<InputFabric>().CreateInputManager();
        StateMachine = gameObject.AddComponent<StateMachine>();

        StateMachine.Initialize(this);
        LevelGenerator.Initialize(this);
    }
}