using Cinemachine;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private UiManager uiManager;

    public BaseInputManager Input { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public MoneyRepository MoneyRepository { get; private set; }
    public GameDataManager GameDataManager { get; private set; }
    public DataStorage DataStorage { get; private set; }
    public LevelGenerator LevelGenerator => levelGenerator;
    public UiManager UiManager => uiManager;
    public CameraPositioner CameraPositioner { get; private set; }
    public CinemachineVirtualCamera CinemachineVirtualCamera { get; private set; }

    private void Awake()
    {
        CinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        Input = gameObject.AddComponent<InputFabric>().CreateInputManager();
        StateMachine = gameObject.AddComponent<StateMachine>();
        CameraPositioner = new GameObject().AddComponent<CameraPositioner>();
        GameDataManager = new GameDataManager();
        MoneyRepository = new MoneyRepository();
        DataStorage = new DataStorage();

        MoneyRepository.Initialize(this);
        CameraPositioner.Initialize(this);
        StateMachine.Initialize(this);
        LevelGenerator.Initialize(this);
        UiManager.Initialize(this);
    }
}