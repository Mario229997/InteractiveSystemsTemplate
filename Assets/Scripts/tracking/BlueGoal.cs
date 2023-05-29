using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueGoal : MonoBehaviour
{
    public string tagFilter;
    public Rigidbody Prefab;
    public Transform Spawnpoint;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag (tagFilter))
        {
            Destroy(gameObject);
            Rigidbody Disk;
            Disk = Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation)as Rigidbody;
            
        }
    }

}