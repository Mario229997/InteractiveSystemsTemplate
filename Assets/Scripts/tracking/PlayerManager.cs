using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 init_pos;


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
}
