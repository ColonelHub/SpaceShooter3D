using TMPro;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private EndgameSO winConfiguration;
    [SerializeField] private EndgameSO loseConfiguration;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text subtitleText;

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
