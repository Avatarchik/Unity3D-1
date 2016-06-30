using UnityEngine;
using System.Collections;

public class csCollisionCheck : MonoBehaviour {

    void  OnCollisionEnter (Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }
}
