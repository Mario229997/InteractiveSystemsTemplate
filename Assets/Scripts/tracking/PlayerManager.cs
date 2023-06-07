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

    public PlayerMovement pm;
    public MainManager mm;

    private bool isAbility;
    private float init_time;
    private float duration_time = 2f;

    public GameObject cubePrefab;


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
        if (isAbility && Time.time - init_time >= 3f)
        {
            isAbility = false;

            int randomNumber = Random.Range(1, 3);

            if (randomNumber == 1)
            {
                if(idx == 1){
                    mm.g_points_blue = 2;
                }else{
                    mm.g_points_red = 2;
                }
                Debug.Log("Double Goal");
            }
            else if (randomNumber == 2)
            {
                CreateCube();
                Debug.Log("New Block");
            }
        }
    }

    private void CreateCube()
    {
        Vector3 spawnPosition = cubePrefab.transform.position; // Adjust the spawn position as needed

        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
    }

    /*
    public IEnumerator HandleTriggerCollision()
    {
        Debug.Log("Here");
        while (isAbility)
        {
            Debug.Log("Here1");
            if (Time.time - init_time >= duration_time)
            {
                Debug.Log("Here2");

                int randomNumber = Random.Range(1, 3);
                if (randomNumber == 1)
                {
                    if(idx == 1){
                        mm.g_points_blue = 2;
                    }else{
                        mm.g_points_red = 2;
                    }
                }
                else if (randomNumber == 2)
                {
                    // Create a 3D cube
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = transform.position + Vector3.up; // Adjust the position of the cube as needed
                }
            }

            yield return null;
        }
    }
    */




}
