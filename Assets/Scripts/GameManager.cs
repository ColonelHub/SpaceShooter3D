using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemiesHandler enemiesHandler;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private EndGameController endGameController;
    [SerializeField] private Levels nextLevel;

    private void Awake()
    {
        enemiesHandler.OnEnemyKilledEvent += scoreController.AddScore;
        enemiesHandler.OnAllEnemiesKilledEvent += TriggerWin;
        player.OnKilled += TriggerLose;

        endGameController.ToggleNextLevelButtonUI(nextLevel != Levels.Invalid);
        endGameController.TargetLevel = nextLevel;
    }

    private void TriggerLose()
    {
        enemiesHandler.CanFire = false;
        enemiesHandler.CanMove = false;
        endGameController.TriggerLoseUI();
    }

    private void TriggerWin()
    {
        player.CanMove = false;
        endGameController.TriggerWinUI();
    }
}