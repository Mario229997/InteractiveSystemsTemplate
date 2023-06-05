using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckManager : MonoBehaviour
{
    public MainManager Gm;

    public string Goal1;
    public string Goal2;
    public string Player1;
    public string Player2;
    public string Wall;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
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

        if (other.CompareTag(Goal1))  //if tagFilter = Blue goal tag
        {
            audio1.Play();
            audio2.Play();
            Gm.PlayerScored(1);
           
        }else if(other.CompareTag(Goal2)){
            audio1.Play();
            audio2.Play();
            Gm.PlayerScored(2);

        }else if(other.CompareTag(Player1)){
            ApplyForce(other.transform);
            //rb.AddForce(transform.forward * impulseForce, ForceMode.Impulse);
    

        }else if(other.CompareTag(Player2)){
            ApplyForce(other.transform);
            //rb.AddForce(transform.forward * impulseForce, ForceMode.Impulse);

        }
        // Sound of the disk with sticks and walls
        if (other.CompareTag (Player1))
        {
            audio3.Play();
        }

        if (other.CompareTag (Player2))
        {
            audio3.Play();
        }

        if (other.CompareTag (Wall))
        {
            audio3.Play();
        }
        
    }

    private void ApplyForce(Transform stickTransform)
    {


        Vector3 direction = (stickTransform.position - transform.position).normalized;

        rb.AddForce(direction * impulseForce, ForceMode.Impulse);
    }


}
