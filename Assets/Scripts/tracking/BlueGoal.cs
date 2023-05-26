using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlueGoal : MonoBehaviour
{
    public string tagFilter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag (tagFilter))
        {
           //Destroy(gameObject);
           gameObject.transform.position = new Vector3(50, 1, 50);
           //Destroy(gameObject);

           //newObject = Instantiate(gameObject, Vector3(50, 1, 50));
           //Invoke("newObject", 2f);
        }
    }

    

}