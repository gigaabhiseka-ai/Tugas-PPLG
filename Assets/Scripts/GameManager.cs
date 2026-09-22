using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState { get; private set; }

    // PEMANCAR EVENT (Delegate & Events)
    public static event Action<GameState> OnStateChanged;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Mulai game dengan state Playing
        ChangeState(GameState.Playing);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log("State Game Berubah Menjadi: " + newState);

        // Memancarkan Event ke semua script yang mendengarkan/menerima
        OnStateChanged?.Invoke(newState);
    }
}
