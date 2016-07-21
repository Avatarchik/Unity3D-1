using UnityEngine;
using System.Collections;

public class PlanetCollisionCheck : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Planet_OnCollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Planet_OnTriggerEnter");

        //충돌 오브젝트 종류 체크
        if (other.tag == "PlanetSpawn")
        {
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
        else if (other.name != "SpaceCheck")
        {
            int rotRand = 0;
            if (this.gameObject.name == "ShipCollider_1")
            {
                rotRand = Random.Range(1, 4);
                switch(rotRand)
                {
                    case 1:
                        GameManager.Instance().rotShip = Vector3.up;
                        break;
                    case 2:
                        GameManager.Instance().rotShip = Vector3.down;
                        break;
                    case 3:
                        GameManager.Instance().rotShip = Vector3.left;
                        break;
                    case 4:
                        GameManager.Instance().rotShip = Vector3.right;
                        break;
                }
                Vector3 rotShip = GameManager.Instance().rotShip;
                GameObject.Find("Player").transform.FindChild("Ship").transform.Rotate(rotShip * 20);
            }
            else if (this.gameObject.name == "ShipCollider_2")
            {
                Vector3 rotShip = GameManager.Instance().rotShip;
                GameObject.Find("Player").transform.FindChild("Ship").transform.Rotate(rotShip * 30);
            }
            else if (this.gameObject.name == "ShipCollider_3")
            {
                Vector3 rotShip = GameManager.Instance().rotShip;
                GameObject.Find("Player").transform.FindChild("Ship").transform.Rotate(rotShip * 40);
            }
        }
    }

}
