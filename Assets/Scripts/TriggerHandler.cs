using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerHandler : MonoBehaviour
{
    [SerializeField] CollisionHandler ch;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Star":
                Debug.Log("Star");
                ch.starCounter++;
                DisappearStar(other);
                break;
            
            default:
                Debug.Log("do nothing");
                break;
        }
     }

    void DisappearStar(Collider other)
    {
        Destroy(other.gameObject);
        /*other.gameObject.SetActive(false);
        other.GetComponent<MeshRenderer>().enabled = false;
        other.GetComponent<SphereCollider>().enabled = false;*/
    }
}
