using UnityEngine;
using System.Collections;

public class PlanetCollisionCheck : MonoBehaviour {

    
    void  OnCollisionEnter (Collision collision)
    {
        Debug.Log("Planet_OnCollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Planet_OnTriggerEnter");

        //충돌 행성 위치 저장
        GameManager.Instance().planetSpawnPoint = other.gameObject.GetComponent<Transform>().position;

        //탐사 UI 활성화
        GameManager.Instance().exploreUi.SetActive(true);

        //게임 시간 정지
        Time.timeScale = 0;

        //행성 생성(ButtonController.cs에 'explore()'로 이동)
        
        //물음표 행성 오브젝트 임시 저장
        GameManager.Instance().tempPlanet = other.gameObject;
        
    }

}
