using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public string tagFilter;

public class BlueGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

private void OnTriggerEnter (Collider other)
{
    if (other.CompareTag (tagFilter))
    {
        Destroy(gameObject);
    }
}