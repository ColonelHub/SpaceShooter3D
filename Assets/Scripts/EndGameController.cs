using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private EndgameSO winConfiguration;
    [SerializeField] private EndgameSO loseConfiguration;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text subtitleText;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button quitGame;

    public Levels TargetLevel { get; set; } = Levels.Invalid;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(LoadNextLevel);
        quitGame.onClick.AddListener(Application.Quit);
    }

    private void ToggleUI(bool status)
    {
        canvas.SetActive(status);
    }

    public void ToggleNextLevelButtonUI(bool status)
    {
        nextLevelButton.gameObject.SetActive(status);
    }

    private void LoadNextLevel()
    {
        if (TargetLevel == Levels.Invalid)
        {
            return;
        }

        SceneManager.LoadScene((int)TargetLevel, LoadSceneMode.Single);
    }

    private void Configure(EndgameSO configuration)
    {
        titleText.text = configuration.TitleText;
        subtitleText.text = configuration.SubtitleText;
    }

    public void TriggerWinUI()
    {
        Configure(winConfiguration);
        ToggleUI(true);
    }

    public void TriggerLoseUI()
    {
        Configure(loseConfiguration);
        ToggleUI(true);
    }
}
