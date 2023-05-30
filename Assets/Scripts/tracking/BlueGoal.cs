using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueGoal : MonoBehaviour
{
    public string tagFilter;
    public Rigidbody Prefab;
    public Transform Spawnpoint;

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
            GoalBlue();
            Destroy(gameObject);
            Rigidbody Disk;
            Disk = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation)as Rigidbody;
        }
    }

}