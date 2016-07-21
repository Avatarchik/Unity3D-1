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
        if (other.name != "Ship" && other.name != "ShipCollider_1" && other.name != "ShipCollider_2" && other.name != "ShipCollider_3")
        {
            GameManager.Instance().scInit = true;
            GameManager.Instance().spaceCollision = true;
            transform.position = new Vector3(0, 0, 350);
        }
    }

}
