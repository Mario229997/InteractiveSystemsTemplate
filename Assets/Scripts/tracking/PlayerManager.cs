using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 init_pos;

    public string ability;
    //public string ability_red;

    public int idx;

    private int randomNumber;

    public PlayerMovement pm;
    public MainManager mm;

    private bool isAbility;
    private bool isAbility_on;
    private float init_time;
    private float duration_time = 10f;

    public GameObject cubePrefab;

    public GameObject extra_goal1;
    public GameObject extra_goal2;

    private GameObject instanced_cubePrefab;

    private GameObject instanced_extra_goal1;
    private GameObject instanced_extra_goal2;

    public AudioSource audio_double_blue;
    public AudioSource audio_reduce_blue;
    public AudioSource audio_obstacles_blue;
    public AudioSource audio_double_red;
    public AudioSource audio_reduce_red;
    public AudioSource audio_obstacles_red;

    public AudioSource audio_disable_ability;

    public bool is_box_on = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        init_pos = transform.position;
        
    }

    // Update is called once per frame
    public void Restart()
    {
        transform.position = init_pos;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isAbility && other.CompareTag(ability)){
            Destroy(other.gameObject);
            //is_box_on = false;
            return;

        }
        if(idx == 1){
            if(other.CompareTag(ability)){
                //mm.g_points_blue = 2;
                isAbility = true;
                Debug.Log("Collision 1");
                init_time = Time.time;

            }
        }
        if(idx == 2){
            if(other.CompareTag(ability)){
                //mm.g_points_red = 2;
                Debug.Log("Collision 2");
                isAbility = true;
                init_time = Time.time;
          
            }
        }
    }

    private void Update()
    {
        if (isAbility && Time.time - init_time >= 1f)
        {
            isAbility = false;
            isAbility_on = true;

            randomNumber = Random.Range(1, 4);
            //randomNumber = 2;

            if (randomNumber == 1)
            {
                if(idx == 1){
                    mm.g_points_blue = 2;
                    audio_double_blue.Play();
                }else{
                    mm.g_points_red = 2;
                    audio_double_red.Play();
                }
                Debug.Log("Double Goal");
                //audio_disable_ability.Play();

            }
            else if (randomNumber == 2)
            {
                instanced_cubePrefab = Instantiate(cubePrefab, cubePrefab.transform.position, Quaternion.identity);
                Debug.Log("New Block");

                if(idx == 1){
                    audio_obstacles_blue.Play();

                }else{
                    audio_obstacles_red.Play();

                }
                

            }else if(randomNumber == 3){
                Debug.Log("Smaller goal");
                instanced_extra_goal1 = Instantiate(extra_goal1, extra_goal1.transform.position, extra_goal1.transform.rotation);
                instanced_extra_goal2 = Instantiate(extra_goal2, extra_goal2.transform.position, extra_goal2.transform.rotation);
                if(idx == 1){
                    audio_reduce_blue.Play();

                }else{
                    audio_reduce_red.Play();

                }
                

            }
        }

        if(isAbility_on && duration_time - (Time.time - init_time) <= 0f){

             if (randomNumber == 1)
            {
                if(idx == 1){
                    mm.g_points_blue = 1;
                }else{
                    mm.g_points_red = 1;
                }
                Debug.Log("Double Goal Over");
                audio_disable_ability.Play();

            }
            else if (randomNumber == 2)
            {
                DestroyImmediate(instanced_cubePrefab, true);
                Debug.Log("New Block Over");
                audio_disable_ability.Play();

            }else if(randomNumber == 3){
                Debug.Log("Smaller goal Over");
                DestroyImmediate(instanced_extra_goal1, true);
                DestroyImmediate(instanced_extra_goal2, true);
                audio_disable_ability.Play();

            }
            isAbility_on = false;
            mm.isAbOn = false;

        }
    }

    public bool isAbilityOn(){
        return isAbility_on;
    }

}
