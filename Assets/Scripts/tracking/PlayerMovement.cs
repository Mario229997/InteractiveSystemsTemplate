using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPosition(Vector3 pos)
    {
        //swith playerIndex
        Vector3 newPos;
        switch (playerIndex)
        {
            case 1:
                newPos = new Vector3(Mathf.Clamp(pos.x,0,50), pos.y, pos.z);
            break;

            case 2:
                newPos = new Vector3(Mathf.Clamp(pos.x,50,100), pos.y, pos.z);
            break;

            default:
                newPos = pos;
            break;
        }
        transform.position = pos;
    }
    
    public bool isGround(){
        
        if(transform.position.y < 2){
            return true;
        }else{
            return false;
        }
    } 
}
