using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckManager : MonoBehaviour
{
    public MainManager Gm;

    public string tagFilter;
    public string tagFilter2;
    public string tagFilter3;
    public string tagFilter4;
    public AudioSource audio1;
    public AudioSource audio2;
    private Rigidbody rb;
    private Vector3 init_pos;

    public float impulseForce = 500f;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        init_pos = transform.position;
        
    }

    public void Restart()
    {
        rb.velocity = Vector3.zero;
        transform.position = init_pos;

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(tagFilter))  //if tagFilter = Blue goal tag
        {
            audio1.Play();
            audio2.Play();
            Gm.PlayerScored(1);
           
        }else if(other.CompareTag(tagFilter2)){
            audio1.Play();
            audio2.Play();
            Gm.PlayerScored(2);

        }else if(other.CompareTag(tagFilter3)){
            ApplyImpulseForce(other.transform);
            //rb.AddForce(transform.forward * impulseForce, ForceMode.Impulse);
    

        }else if(other.CompareTag(tagFilter4)){
            ApplyImpulseForce(other.transform);
            //rb.AddForce(transform.forward * impulseForce, ForceMode.Impulse);
    

        }
        //ApplyImpulseForce(other.transform);
        
    }

    private void ApplyImpulseForce(Transform stickTransform)
    {
        // Apply an impulse force to the disc in the forward direction
        //rb.AddForce(transform.forward * impulseForce, ForceMode.Impulse);

        Vector3 direction = (stickTransform.position - transform.position).normalized;

        // Apply an impulse force to the puck in the calculated direction
        rb.AddForce(direction * impulseForce, ForceMode.Impulse);
    }


}
