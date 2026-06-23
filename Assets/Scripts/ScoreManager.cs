using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score1Text;
    [SerializeField] private TextMeshProUGUI score2Text;

    private void Start()
    {
        int score1 = PlayerPrefs.GetInt("Game1Score", 0);
        int score2 = PlayerPrefs.GetInt("Game2Score", 0);
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }
}
