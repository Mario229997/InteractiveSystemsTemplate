using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueGoal : MonoBehaviour
{
    public string tagFilter;
    public Rigidbody Prefab;
    public Transform Spawnpoint;
    public AudioSource audio1;
    public AudioSource audio2;

    private int goals_blue;

    void Start()
    {
        goals_blue = 0;   
    }

    void GoalBlue()
    {
        goals_blue += 1;
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag (tagFilter))
        {
            audio1.Play();
            audio2.Play();
            GoalBlue();
            Destroy(gameObject);
            Rigidbody Disk;
            Disk = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation)as Rigidbody;
        }
    }

}