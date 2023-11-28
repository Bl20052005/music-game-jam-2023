using UnityEngine;

public class PuzzleSolver : MonoBehaviour
{
    // Enum to represent different states of the puzzle solver
    public enum PuzzleState
    {
        Initial,
        Signal1Received,
        Signal0Received,
        PuzzleSolved // Removed Goal if not needed
    }

    private PuzzleState currentState = PuzzleState.Initial;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Door door;
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        InitializeReferences();
    }

    private void Update()
    {
        int receivedSignal = GetReceivedSignal();
        UpdateStateMachine(receivedSignal);
    }

    // Initialize references to components
    private void InitializeReferences()
    {
        inventory = GetComponent<Inventory>();
        door = FindObjectOfType<Door>();
        uiManager = FindObjectOfType<UIManager>();

        LogComponentNotFound(inventory, "Inventory");
        LogComponentNotFound(door, "Door");
        LogComponentNotFound(uiManager, "UIManager");
    }

    // Log an error if a required component is not found
    private void LogComponentNotFound(UnityEngine.Object component, string componentName)
    {
        if (component == null)
        {
            Debug.LogError($"[{gameObject.name}] PuzzleSolver: {componentName} component not found.");
        }
    }

    // Update the state machine based on the received signal
    private void UpdateStateMachine(int receivedSignal)
    {
        switch (currentState)
        {
            case PuzzleState.Initial:
                HandleInitial(receivedSignal);
                break;

            case PuzzleState.Signal1Received:
            case PuzzleState.Signal0Received:
                HandleSignalReceived(receivedSignal);
                break;

            case PuzzleState.PuzzleSolved:
                // Optional: Add additional logic for PuzzleSolved state
                break;
        }
    }

    // Handle the Initial state of the puzzle
    private void HandleInitial(int receivedSignal)
    {
        if (receivedSignal == 1)
        {
            currentState = PuzzleState.Signal1Received;
            uiManager?.DisplayMessage("Signal 1 received!");
        }
        else if (receivedSignal == 0)
        {
            currentState = PuzzleState.Signal0Received;
            uiManager?.DisplayMessage("Signal 0 received!");
        }
    }

    // Handle actions when a signal is received
    private void HandleSignalReceived(int receivedSignal)
    {
        // Perform actions for SignalReceived state
        // ...

        // Transition to the next state if needed
        if (CheckPuzzleSolved())
        {
            currentState = PuzzleState.PuzzleSolved;
            uiManager?.DisplayMessage("Puzzle solved!");
        }
    }

    // Simulate receiving signals (1 or 0) based on some conditions
    private int GetReceivedSignal()
    {
        // For example, check player input or other game events
        return UnityEngine.Random.Range(0, 2); // Simulate a random signal (1 or 0)
    }

    // Check if the puzzle is solved by checking the door state
    private bool CheckPuzzleSolved()
    {
        return door != null && !door.IsLocked();
    }
}
