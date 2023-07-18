using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Space(10)]
    public Text HighScore; 

    [Space(10)]
    [Header("Statistics")]
    public Text BestScore;
    public Text GamesPlayed;
    string highscore;

    void Awake()
    {

        RefreshAllInfo();
    }
    public void LoadGame(){
        
        AddPlayCounts();
        SceneManager.LoadScene(1);   
    }

    void UpdateStats(){

        highscore = PlayerPrefs.GetInt("SCORE").ToString();
        string gamesPlayed = PlayerPrefs.GetInt("PLAYED").ToString();

        HighScore.text = $"BEST SCORE: {highscore}";
        BestScore.text = highscore;
        GamesPlayed.text = gamesPlayed;
    }

    void AddPlayCounts(){

        int temp = PlayerPrefs.GetInt("PLAYED");
        temp++;
        PlayerPrefs.SetInt("PLAYED", temp);
    }

    void RefreshAllInfo(){

        UpdateStats();
    }
    
    void OnEnable()
    {
        
        RefreshAllInfo();
    }


}
