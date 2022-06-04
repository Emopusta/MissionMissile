using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerHandler : CollisionHandler
{
   
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Star":
                Debug.Log("Star");
                starCounter++;
                DisappearStar(other);
                break;
            
            default:
                Debug.Log("do nothing");
                break;
        }
     }

    void DisappearStar(Collider other)
    {
        other.gameObject.SetActive(false);
        other.GetComponent<MeshRenderer>().enabled = false;
        other.GetComponent<SphereCollider>().enabled = false;
    }
}
