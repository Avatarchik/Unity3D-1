using UnityEngine;
using System.Collections;

public class csCollisionCheck : MonoBehaviour {

    public GameObject pmObj;
    public Vector3 spawnPoint;
    void  OnCollisionEnter (Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        spawnPoint = other.gameObject.GetComponent<Transform>().position;
        Debug.Log(spawnPoint);

        PlanetManager script = pmObj.GetComponent<PlanetManager>();
        script.planetChange(spawnPoint);

        GameManager.Instance().exploreUi.SetActive(true);
        Destroy(other.gameObject);
        
        Time.timeScale = 0;
    }

}
