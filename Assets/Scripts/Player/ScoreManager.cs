using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
   public int score = 0;
    int highScore = 0;
    //Playerpref key
    private string highScoreKeyPrefix = "HighScore_Level_";



    private void Awake()
    {
       instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();
        
    }
    public void AddScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
       
        if (highScore < score)
        {
            highScore = score;
            SaveHighScore();
            highScoreText.text = "HighScore" + highScore.ToString();
        }
    }
    private void SaveHighScore()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        string highScoreKey = highScoreKeyPrefix + sceneIndex;
        PlayerPrefs.SetInt(highScoreKey, highScore);
    }
    private void LoadHighScore()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        string highScoreKey = highScoreKeyPrefix+sceneIndex;
        highScore=PlayerPrefs.GetInt(highScoreKey, 0);
    }
    
    
}
