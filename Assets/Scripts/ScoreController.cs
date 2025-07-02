using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int defaultScorePerKill;

    private int currentScore = 0;

    private void Awake()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void AddScore()
    {
        AddScore(defaultScorePerKill);
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateUI();
    }
}
