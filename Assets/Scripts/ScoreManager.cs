using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] scores;

    private void Start()
    {
        for (int i = 0; i < scores.Length; ++i)
        {
            scores[i].text = PlayerPrefs.GetInt($"Game{i + 1}Score", 0).ToString();        
        } 
    }
}
