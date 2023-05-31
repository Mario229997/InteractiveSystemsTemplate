using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    private int goals_red;
    private int goals_blue;

    public PuckManager puck;

    public PlayerManager p1;
    public PlayerManager p2;

    public Text ScoreTextBlue;
    public Text ScoreTextRed;


    // Start is called before the first frame update
    void Start()
    {
        goals_red = 0;
        goals_blue = 0;
        DisplayScore();
    }

    public void PlayerScored(int num_player){

        if(num_player == 2){
            goals_blue++;
        }else{
            goals_red++;
        }

        puck.Restart();
        p1.Restart();
        p2.Restart();

        DisplayScore();

    }

    void DisplayScore(){
        ScoreTextBlue.text = "Blue: " + goals_blue;
        ScoreTextRed.text = "Red: " + goals_red;
    }
}