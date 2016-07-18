using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetManager : MonoBehaviour
{
    public GameObject udp;
    public GameObject[] planet;
    private GameObject player;
    private GameObject spaceChecker;
    public float spawnTime = 10.0f;

    float deltaSpawnTime = 0.0f;

    int spawnCnt = 1;
    int maxSpawnCnt = 100;

    GameObject[] planetPool;
    int poolSize = 20;
    
    void Start()
    {

        planetPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            planetPool[i] = Instantiate(udp) as GameObject;
            planetPool[i].SetActive(false);
        }
    }

    void Update()
    {
        player = GameManager.Instance().player;
        spaceChecker = GameManager.Instance().spaceChecker;
        if (spawnCnt > maxSpawnCnt)
            return;

        deltaSpawnTime += Time.deltaTime;

        if (deltaSpawnTime > spawnTime)
        {
            deltaSpawnTime = 0.0f;
            for (int i = 0; i < poolSize; i++)
            {
                if (planetPool[i].activeSelf == true)
                {
                    //충돌하지 않은 물음표 행성 10m 초과로 멀어지면 Active False 처리
                    //Debug.Log("Distance of RandomPlanet" + Vector3.Distance(planetPool[i].transform.position, player.transform.position));
                    if (Vector3.Distance(planetPool[i].transform.position, player.transform.position) > 15)
                    {
                        Debug.Log("Planet Disable!");
                        planetPool[i].SetActive(false);
                    }
                    continue;
                }

                //물음표 행성 랜덤 생성

                int planetRandom = Random.Range(1, 4);
                //Debug.Log("[SpawnDirection]\n1: left , 2: Right, 3: up, 4: down" + "\t<b>" +planetRandom +"</b>");
                //Vector3 pcPosition = player.transform.localPosition;
                Vector3 left = Vector3.left * 3.5f;
                Vector3 right = Vector3.right * 3.5f;
                Vector3 up = Vector3.up * 3.5f;
                Vector3 down = Vector3.down * 3.5f;
                int x = Random.Range(-5, 5);


                if (planetRandom == 1)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + left;
                    if (GameManager.Instance().spaceCollision == false)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * 10.0f + left;

                        planetPool[i].SetActive(true);

                        planetPool[i].name = "Planet_" + spawnCnt;
                        ++spawnCnt;
                        break;
                    }
                    else if (GameManager.Instance().spaceCollision == true)
                    {
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        GameManager.Instance().spaceCollision = false;
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        --i;
                        break;
                    }
                }

                else if (planetRandom == 2)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + right;
                    if (GameManager.Instance().spaceCollision == false)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * 10.0f + right;

                        planetPool[i].SetActive(true);

                        planetPool[i].name = "Planet_" + spawnCnt;
                        ++spawnCnt;
                        break;
                    }
                    else if (GameManager.Instance().spaceCollision == true)
                    {
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        GameManager.Instance().spaceCollision = false;
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        --i;
                        break;
                    }
                }
                else if (planetRandom == 3)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + up;
                    if (GameManager.Instance().spaceCollision == false)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * 10.0f + up;

                        planetPool[i].SetActive(true);

                        planetPool[i].name = "Planet_" + spawnCnt;
                        ++spawnCnt;
                        break;
                    }
                    else if (GameManager.Instance().spaceCollision == true)
                    {
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        GameManager.Instance().spaceCollision = false;
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        --i;
                        break;
                    }
                }

                else if (planetRandom == 4)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + down;
                    if (GameManager.Instance().spaceCollision == false)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * 10.0f + down;

                        planetPool[i].SetActive(true);

                        planetPool[i].name = "Planet_" + spawnCnt;
                        ++spawnCnt;
                        break;
                    }
                    else if (GameManager.Instance().spaceCollision == true)
                    {
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        GameManager.Instance().spaceCollision = false;
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        --i;
                        break;
                    }
                }
            }
        }
    }
    
    public void planetChange(Vector3 spawnPoint)
    {
        int rand = GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().PlanetCreate();
        float tempDistance = 500;       // 별자리 거리 임시 값
        int nearStar = 0;               // 가장 가까운 별자리 카운트 값 
        string tempName;
        int tempsize;
        int tempcolor;
        int tempmFood;
        int tempmTitanium;
        int tempLepersec;
        float tempX;
        float tempY;
        float tempZ;
        int tempmat;
        // 행성 오브젝트 생성 및 배치 

        GameObject obj = Instantiate(GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().D_PlanetList[rand]);
        obj.transform.position = spawnPoint;

        // 행성 이름 생성 <형용사(사이즈별)> + <행성 색깔> + <별자리이름> 조합
        // 가까운 별자리 찾기
        for (int i = 1; i <= 12; i++)
        {
            string starName = "Center_" + i;
            float starDistance = Vector3.Distance(obj.transform.position, GameObject.Find(starName).transform.position);

            Debug.Log(starName + "\t" + starDistance);
            if (tempDistance > starDistance)
            {
                tempDistance = starDistance;
                nearStar = i;
            }
        }
        Debug.Log("제일 가까운 거리!" + tempDistance + "\t" + nearStar);
        tempName = GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().PlanetNameCreate() + " " + GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().zName[nearStar - 1];
        obj.name = tempName;

        tempsize = GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().sizeT;
        tempcolor = GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().colorT;
        tempmFood = Random.Range(tempsize * tempsize * 100, tempsize * 5 * 100);
        tempmTitanium = Random.Range(tempsize * tempsize * 100, tempsize * 5 * 100);
        tempLepersec = tempsize;
        tempX = spawnPoint.x;
        tempY = spawnPoint.y;
        tempZ = spawnPoint.z;
        tempmat = GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().matT;


        InsertDB.Instance().table = "managePlanetTableTest";
        InsertDB.Instance().column = "name,size,color,mFood,le_persec,locationX,locationY,locationZ,mat,state,lFood,lTitanium,position_house,User,neighbor,mTitanium,tree2,tree3,tree4,tree5,tree6";
        InsertDB.Instance().values = tempName + "," + tempcolor + "," + tempmFood + "," + tempLepersec + ","
                                    + tempX + "," + tempY + "," + tempZ + "," + tempmat + "," 
                                    + "1" + "," + tempmFood + "," + tempmTitanium + "," + "0" + "," + "0" + "," + "0" + "," + tempmTitanium + "," +"0" + "," +"0" + "," + "0" + "," + "0" + "," + "0";

        InsertDB.Instance().Insert();

        //DB Column
        /*
        pID
        name
        size
        color
        mFood
        le_persec
        locationX
        locationY
        locationZ
        mat
        state
        lFood
        lTitanium
        position_house
        tree1
        User
        neighbor
        PlanetTouchT
        TitaniumTouchT
        treeTouchT
        breakTime
        mTitanium
        tree2
        tree3
        tree4
        tree5
        tree6
        */

        //obj.name = rand + "" + "" + spawnPoint;

    }


}


