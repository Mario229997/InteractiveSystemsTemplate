using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSound : MonoBehaviour
{
    public string player1;
    public string player2;
    public string wall;

    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag (player1))
        {
            audio.Play();
        }
        if (other.CompareTag (player2))
        {
            audio.Play();
        }
        if (other.CompareTag (wall))
        {
            audio.Play();
        }
    }

}
