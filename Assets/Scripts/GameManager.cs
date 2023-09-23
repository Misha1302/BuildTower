using Cinemachine;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;

    public BaseInputManager Input { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public GameDataManager GameDataManager { get; private set; }
    public LevelGenerator LevelGenerator => levelGenerator;
    public CameraPositioner CameraPositioner { get; private set; }
    public CinemachineVirtualCamera CinemachineVirtualCamera { get; private set; }

    private void Awake()
    {
        CinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        Input = gameObject.AddComponent<InputFabric>().CreateInputManager();
        StateMachine = gameObject.AddComponent<StateMachine>();
        CameraPositioner = new GameObject().AddComponent<CameraPositioner>();
        GameDataManager = new GameDataManager();

        CameraPositioner.Initialize(this);
        StateMachine.Initialize(this);
        LevelGenerator.Initialize(this);
    }
}