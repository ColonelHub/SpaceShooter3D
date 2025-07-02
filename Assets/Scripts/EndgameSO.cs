using UnityEngine;

[CreateAssetMenu(fileName = "EndgameSO_", menuName = "ScriptableObjects/Endgame")]
public class EndgameSO : ScriptableObject
{
    [SerializeField] private string titleText;
    [SerializeField] private string subtitleText;

    public string TitleText { get => titleText; }
    public string SubtitleText { get => subtitleText; }
}
