using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private EndgameSO winConfiguration;
    [SerializeField] private EndgameSO loseConfiguration;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text subtitleText;
    [SerializeField] private Button quitGame;

    private void Awake()
    {
        quitGame.onClick.AddListener(Application.Quit);
    }
    private void ToggleUI(bool status)
    {
        canvas.SetActive(status);
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
