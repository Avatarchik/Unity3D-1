using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetCollisionCheck : MonoBehaviour
{
    public GameObject obj;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Planet_OnCollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Planet_OnTriggerEnter");
        Debug.Log(other.tag);

        //충돌 오브젝트 종류 체크
        if (other.tag == "PlanetSpawn")
        {
            SelectDB.Instance().table = "managePlanetTable";
            SelectDB.Instance().column = "Count(*)";
            SelectDB.Instance().Select(0);

            SelectDB.Instance().table = "zodiacTable";
            SelectDB.Instance().column = "Count(*)";
            SelectDB.Instance().where = "WHERE \"open\" = 1 AND  \"find\" = 1 AND \"active\" = 0";
            SelectDB.Instance().Select(0);

            if (SelectDB.Instance().planetCount == 11 || SelectDB.Instance().starCount == 5)
            {
                GameManager.Instance().noMorePS.SetActive(true);
            } else {
                //충돌 행성 위치 저장
                GameManager.Instance().planetSpawnPoint = other.gameObject.GetComponent<Transform>().position;

                //탐사 UI 활성화
                SoundManager.Instance().PlaySfx(SoundManager.Instance().getFood);
                GameManager.Instance().exploreUi.transform.FindChild("Ok").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").gameObject.GetComponent<ButtonController>().explore(1));
                GameManager.Instance().exploreUi.SetActive(true);

                //물음표 행성 오브젝트 임시 저장
                GameManager.Instance().tempPlanet = other.gameObject;

                //행성 생성(ButtonController.cs에 'explore()'로 이동)
            }

            //게임 시간 정지
            Time.timeScale = 0;
            
        }
        else if(other.tag == "Stars")
        {
            SoundManager.Instance().PlaySfx(SoundManager.Instance().getFood);
            SelectDB.Instance().table = "zodiacTable";
            SelectDB.Instance().column = "Count(*)";
            SelectDB.Instance().where = "WHERE \"open\" = 1 AND  \"find\" = 1 AND \"active\" = 0";
            SelectDB.Instance().Select(0);
            if (SelectDB.Instance().starCount == 5)
            {
                GameManager.Instance().noMorePS.SetActive(true);
            }
            else
            {
                SelectDB.Instance().table = "zodiacTable";
                SelectDB.Instance().column = "rowid, open, find, active";
                SelectDB.Instance().where = "WHERE zID = " + "'" + other.name +"'";
                SelectDB.Instance().Select(4);
                if (SelectDB.Instance().starOpen == 0 && SelectDB.Instance().starFind == 0 && SelectDB.Instance().starActive == 0)
                {
                    GameManager.Instance().exploreUi_star.SetActive(true);
                    GameManager.Instance().exploreUi_star.transform.FindChild("Ok").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<ButtonController>().explore(2));
                }else
                {
                    turnShip();
                }
            }
            //게임 시간 정지
            Time.timeScale = 0;

        }
        else if (other.name != "SpaceCheck" && other.tag != "Missile")
        {
            turnShip();
        }
    }

    void turnShip()
    {
        int rotRand = 0;
        if (this.gameObject.name == "ShipCollider_1")
        {
            rotRand = Random.Range(1, 4);
            switch (rotRand)
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
            GameManager.Instance().rotRate = 30;
            GameObject.Find("Ship").GetComponent<ShipTurningMove>().TrunShip();
        }
        else if (this.gameObject.name == "ShipCollider_2")
        {
            GameManager.Instance().rotRate = 35;
            GameObject.Find("Ship").GetComponent<ShipTurningMove>().TrunShip();
        }
        else if (this.gameObject.name == "ShipCollider_3")
        {
            GameManager.Instance().rotRate = 40;
            GameObject.Find("Ship").GetComponent<ShipTurningMove>().TrunShip();
        }
        else if (this.gameObject.name == "ShipCollider_left")
        {
            Debug.Log("left");
            GameManager.Instance().rotShip = Vector3.up;
            GameManager.Instance().rotRate = 35;
            GameObject.Find("Ship").GetComponent<ShipTurningMove>().TrunShip();
        }
        else if (this.gameObject.name == "ShipCollider_right")
        {
            Debug.Log("Right");
            GameManager.Instance().rotShip = Vector3.down;
            GameManager.Instance().rotRate = 35;
            GameObject.Find("Ship").GetComponent<ShipTurningMove>().TrunShip();
        }
    }
}
