using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedGoal : MonoBehaviour
{
    public string tagFilter;
    public Rigidbody Prefab;
    public Transform Spawnpoint;
    public AudioSource audio1;
    public AudioSource audio2;

    private int goals_red;

    void Start()
    {
        goals_red = 0;   
    }

    void GoalRed()
    {
        goals_red += 1;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag (tagFilter))
        {
            audio1.Play();
            audio2.Play();
            GoalRed();
            Destroy(gameObject);
            Rigidbody Disk;
            Disk = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation)as Rigidbody;
            
        }
    }
    

}
