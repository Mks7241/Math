using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
   public int score = 0;
    int highScore = 0;
    

    private void Awake()
    {
       instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore",0);
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();
        
    }
    public void AddScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
       
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "HighScore" + highScore.ToString();
        }
    }
    
    
}
