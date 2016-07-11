using UnityEngine;
using System.Collections;

public class SpaceCollisionCheck : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Space_OnCollisionEnter");
    }


    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Space_OnTriggerEnter\t"+ other.name);
        if (other.name != "Ship")
        {
            GameManager.Instance().spaceCollision = true;
            transform.position = new Vector3(0, 0, 350);
        }
    }

}
