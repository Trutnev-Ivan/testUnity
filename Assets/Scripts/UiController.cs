using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; 
    
    void Start()
    {
        if (scoreText == null)
        {
            throw new System.Exception("scoreText is null");
        }

        scoreText.text = "0";
        Statistics.OnChangeScore += changeScoreText;
    }

    private void changeScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
