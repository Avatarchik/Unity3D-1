using UnityEngine;
using System.Collections;

public class PlanetCollisionCheck : MonoBehaviour {

    public GameObject pmObj;
    public Vector3 spawnPoint;
    void  OnCollisionEnter (Collision collision)
    {
        Debug.Log("Planet_OnCollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Planet_OnTriggerEnter");
        //충돌 행성 위치 저장
        spawnPoint = other.gameObject.GetComponent<Transform>().position;
        Debug.Log("SpawnPoint "+spawnPoint);
        
        //물음표 행성 교체
        PlanetManager script = pmObj.GetComponent<PlanetManager>();
        script.planetChange(spawnPoint);

        //탐사 UI 활성화
        GameManager.Instance().exploreUi.SetActive(true);
        other.gameObject.SetActive(false);
        
        Time.timeScale = 0;
    }

}
