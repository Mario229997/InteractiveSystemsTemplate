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
                if(pm.isGround()){
                    mm.g_points_blue = 2;

                }
            }
        }
        if(idx == 2){
            if(other.CompareTag(ability)){
                if(pm.isGround()){
                    mm.g_points_red = 2;

                }
            }
        }
    }
}
