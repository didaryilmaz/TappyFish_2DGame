using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    public Text panelScore;
    public Text panelHighScore;
    Text scoreText;
    public GameObject New;
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScore.text = highScore.ToString();
    }
    public void Scored(){
        score ++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        if(score > highScore){
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            New.SetActive(true);
        }
    }
     public int GetScore(){
        return score;
     }

}
