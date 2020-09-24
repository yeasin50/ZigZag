﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance ;
    public GameObject zigzagPanel;
    public GameObject gameoverPanel;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public GameObject tapText;
    // Start is called before the first frame update

    void Awake() {
        if(instance==null){
            instance = this;
        }    
    }
    void Start()
    {
       highScore1.text = "High Score: "+ PlayerPrefs.GetInt("highScore").ToString();
    }

    public void gameStart(){
        
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUp");
        
    }

    public void gameover(){

        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameoverPanel.SetActive(true);
       
    }

    public void Reset(){
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
