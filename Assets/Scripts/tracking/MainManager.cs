using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainManager : MonoBehaviour
{
    public bool isAbOn = false;

    public int goals_red;
    public int goals_blue;

    public int g_points_blue;
    public int g_points_red;

    public PuckManager puck;

    public PlayerManager p1;
    public PlayerManager p2;

    public Text ScoreTextBlue;
    public Text ScoreTextRed;
    public Text BlueWins;
    public Text RedWins;

    public AudioSource Victory;

    public GameObject ability_plate_prefab;

    private GameObject instanced_ability_plate;

    private float init_time = 0f;
    private float interval_time = 15f;

    //public Transform spawnInterval1;
    //public Transform spawnInterval2;


    // Start is called before the first frame update
    void Start()
    {
        goals_red = 0;
        goals_blue = 0;
        g_points_blue = 1;
        g_points_red = 1;
        DisplayScore();
    }

    void Update(){

        /*
        bool is_on = p1.isAbilityOn();
        bool is_on2 = p2.isAbilityOn();

        if(is_on == false && is_on2 == false && p1.is_box_on == false){
            Debug.Log("hola");
            init_time += Time.deltaTime;
        }

        //init_time += Time.deltaTime;
*/

        if(isAbOn == false){
            Debug.Log("hola");
            init_time += Time.deltaTime;
        }

        if(init_time >= interval_time){

            //Debug.Log("hola");
            //p1.is_box_on = true;
            //p2.is_box_on = true;
            isAbOn =  true;
            instanced_ability_plate = Instantiate(ability_plate_prefab, getRandomPosition(), Quaternion.identity);
            init_time = 0f;

        }


        

        
    }

    public void PlayerScored(int num_player){

        if(num_player == 1){
            goals_blue = goals_blue + g_points_blue;
        }else{
            goals_red = goals_red + g_points_red;
        }

        puck.Restart();
        p1.Restart();
        p2.Restart();

        DisplayScore();

        if(goals_blue >= 5){
            BlueWins.text = "Blue Wins!";
            Victory.Play();
            DisplayScore();
            RestartGame();
            DisplayScore();

        }
        if(goals_red >= 5){
            RedWins.text = "Red Wins!";
            Victory.Play();
            DisplayScore();
            RestartGame();
            DisplayScore();
        }

        //RestartGame();

    }

    void DisplayScore()
    {
        ScoreTextBlue.text = "Blue: " + goals_blue;
        ScoreTextRed.text = "Red: " + goals_red;
    }

    void DestroyScore()
    {
        ScoreTextBlue.text = "";
        ScoreTextRed.text = "";
    }

    void RestartGame(){
        goals_blue = 0;
        goals_red = 0;
        p1.Restart();
        p2.Restart();
        puck.Restart();
    }

    private Vector3 getRandomPosition(){
        float x = Random.Range(30.0f, 70.0f);
        float y = -1.2f;
        float z = Random.Range(35.0f, 65.0f);

        return new Vector3(x, y, z);

    }
}
