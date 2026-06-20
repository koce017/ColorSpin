using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void UpdateScoreColor(Color color)
    {
        scoreText.color = color;
    }

    public void SetPlayButtonActive(bool isActive)
    {
        playButton.gameObject.SetActive(isActive);
    }
}
