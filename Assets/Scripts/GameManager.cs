using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemiesHandler enemiesHandler;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private EndGameController endGameController;

    private void Awake()
    {
        enemiesHandler.OnEnemyKilledEvent += scoreController.AddScore;
        enemiesHandler.OnAllEnemiesKilledEvent += TriggerWin;
        player.OnKilled += TriggerLose;
    }

    private void TriggerLose()
    {
        enemiesHandler.CanMove = false;
        endGameController.TriggerLoseUI();
    }

    private void TriggerWin()
    {
        player.CanMove = false;
        endGameController.TriggerWinUI();
    }
}