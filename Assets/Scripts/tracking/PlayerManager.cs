using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 init_pos;

    public string ability;

    public int idx;

    private int randomNumber;

    public PlayerMovement pm;
    public MainManager mm;

    private bool isAbility;
    private bool isAbility_on;
    private float init_time;
    private float duration_time = 15f;

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

    public bool isA1on = false;
    public bool isA2on = false;
    public bool isA3on = false;


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
            return;
        }
        if(idx == 1){
            if(other.CompareTag(ability)){
                isAbility = true;
                Debug.Log("Collision 1");
                init_time = Time.time;
            }
        }
        if(idx == 2){
            if(other.CompareTag(ability)){
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
                isA1on = true;
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
                isA2on = true;
            }
            else if(randomNumber == 3){
                Debug.Log("Smaller goal");
                instanced_extra_goal1 = Instantiate(extra_goal1, extra_goal1.transform.position, extra_goal1.transform.rotation);
                instanced_extra_goal2 = Instantiate(extra_goal2, extra_goal2.transform.position, extra_goal2.transform.rotation);
                if(idx == 1){
                    audio_reduce_blue.Play();
                }else{
                    audio_reduce_red.Play();
                }
                isA3on = true;
            }
        }

        if(isAbility_on && duration_time - (Time.time - init_time) <= 0f){

            if (randomNumber == 1)
            {
                audio_disable_ability.Play();
                Ability1Over();
            }
            else if (randomNumber == 2)
            {
                audio_disable_ability.Play();
                Ability2Over();
            }
            else if(randomNumber == 3){
                audio_disable_ability.Play();
                Ability3Over();
            }
            isAbility_on = false;
            mm.isAbOn = false;
        }
    }

    public bool isAbilityOn(){
        return isAbility_on;
    }

    public void Ability1Over(){

        if(isA1on == true){
            if(idx == 1){
                mm.g_points_blue = 1;
            }
            else{
                mm.g_points_red = 1;
            }
            Debug.Log("Double Goal Over");

            isA1on = false;
            isAbility_on = false;
            mm.isAbOn = false;
        }
    }

    public void Ability2Over(){

        if(isA2on == true){
            DestroyImmediate(instanced_cubePrefab, true);
            Debug.Log("New Block Over");

            isA2on = false;

            isAbility_on = false;
            mm.isAbOn = false;
        }
    }

    public void Ability3Over(){

        if(isA3on == true){
            Debug.Log("Smaller goal Over");
            DestroyImmediate(instanced_extra_goal1, true);
            DestroyImmediate(instanced_extra_goal2, true);
            
            isA3on = false;

            isAbility_on = false;
            mm.isAbOn = false;
        }
    }

}
