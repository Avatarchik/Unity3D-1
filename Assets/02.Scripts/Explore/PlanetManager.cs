using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetManager : MonoBehaviour
{
    public GameObject udp;
    public GameObject[] natureObj;
    private GameObject player;
    private GameObject spaceChecker;
    public float spawnTime = 10.0f;

    float deltaSpawnTime = 0.0f;

    int spawnCnt = 1;
    int maxSpawnCnt = 100;

    GameObject[] planetPool;
    int poolSize = 20;

    int planetLoadCnt = 1;

    void Awake()
    {
        Debug.Log(natureObj.Length);
        for (int i = 0; i < natureObj.Length; i++)
        {
            Debug.Log(i +" "+ natureObj[i].transform.childCount);
            for (int j = 0; j < natureObj[i].transform.childCount; j++)
            {
                Debug.Log(j +" "+ natureObj[i].transform.GetChild(j).gameObject.name);
                natureObj[i].transform.GetChild(j).gameObject.AddComponent<MeshCollider>().enabled =true;
            }
        }

    }

    void Start()
    {

        planetPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            planetPool[i] = Instantiate(udp) as GameObject;
            planetPool[i].SetActive(false);
        }
        loadPlanet();
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
                Vector3 left = Vector3.left * Random.Range(1.0f, 5.0f);
                Vector3 right = Vector3.right * Random.Range(1.0f, 5.0f);
                Vector3 up = Vector3.up * Random.Range(1.0f, 5.0f);
                Vector3 down = Vector3.down * Random.Range(1.0f, 5.0f);
                int x = Random.Range(-5, 5);


                if (planetRandom == 1)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + left;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
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
                        spaceChecker.transform.position = new Vector3(0, 0, 350);
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        --i;
                        break;
                    }
                }

                else if (planetRandom == 2)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + right;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
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
                        spaceChecker.transform.position = new Vector3(0, 0, 350);
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        --i;
                        break;
                    }
                }
                else if (planetRandom == 3)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + up;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
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
                        spaceChecker.transform.position = new Vector3(0, 0, 350);
                        Debug.Log("현재 상태:" + GameManager.Instance().spaceCollision);
                        --i;
                        break;
                    }
                }

                else if (planetRandom == 4)
                {
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * 10.0f + down;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
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
                        spaceChecker.transform.position = new Vector3(0, 0, 350);
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

        //초기 행성생성시 데이터 초기화 및 DB INSERT (Table Column 순서 수정필요함)
        InsertDB.Instance().table = "managePlanetTable";
        InsertDB.Instance().column = "name,size,color,mFood,mTitanium,le_persec,locationX,locationY,locationZ,mat,lFood,lTitanium";
        InsertDB.Instance().values = "\"" + tempName + "\"," +    //name      행성이름
                                     tempsize + "," +           //size      행성크기
                                     tempcolor + "," +          //color     행성색상
                                     tempmFood + "," +          //mFood     식량 부존량
                                     tempmTitanium + "," +      //mTitanium 티타늄 부존량
                                     tempLepersec + "," +       //le_persec 초당 빛생산량
                                     tempX + "," +              //locationX 좌표X
                                     tempY + "," +              //locationY 좌표Y
                                     tempZ + "," +              //locationZ 좌표Z 
                                     tempmat + "," +            //material  행성 스타일
                                     tempmFood + "," +          //lFood     식량 잔존량
                                     tempmTitanium;     //lTitanium 티타늄 잔존량

                                               

        InsertDB.Instance().Insert();
    }

    void loadPlanet()
    {
        //마지막에 추가된 rowid 조회
        SelectDB.Instance().table = "managePlanetTable";
        SelectDB.Instance().column = "rowid, Count(*)";
        SelectDB.Instance().Select(0);
        Debug.Log(SelectDB.Instance().planetCount);

        SelectDB.Instance().table = "userTable";
        SelectDB.Instance().column = "cfood, shipNum";
        SelectDB.Instance().Select(2);

        SelectDB.Instance().table = "managePlanetTable";
        SelectDB.Instance().column = "rowid, name, size, color, mat, locationX, locationY, locationZ, tree1, tree2, tree3, tree4, tree5, tree6";
        Debug.Log(planetLoadCnt+","+SelectDB.Instance().planetCount);
        for (; planetLoadCnt <= SelectDB.Instance().planetCount; planetLoadCnt++)
        {
            SelectDB.Instance().where = "WHERE rowid =" + planetLoadCnt;
            SelectDB.Instance().Select(3);
            
            if (SelectDB.Instance().planetIndex != 0)
            {
                int planetShape = (SelectDB.Instance().planetSize * 100) + (SelectDB.Instance().planetColor * 10) + SelectDB.Instance().planetMat;
                //쿼리 결과로 변수 초기화
                Debug.Log(planetShape);
                // 행성 오브젝트 생성 및 배치 

                GameObject obj = Instantiate(GameObject.Find("PlanetManager").gameObject.GetComponent<RandPlanet>().D_PlanetList[planetShape]);
                obj.transform.position = SelectDB.Instance().starPosition;
                obj.name = SelectDB.Instance().planetName;
                obj.tag = "Planet";
                //obj.GetComponent<SphereCollider>().isTrigger = false;
                obj.transform.FindChild("PC").gameObject.SetActive(false);
                obj.transform.FindChild("Neighbor").gameObject.SetActive(false);
                obj.transform.FindChild("Ship").gameObject.SetActive(false);
                obj.transform.FindChild("Ship_Neighbor").gameObject.SetActive(false);
                obj.transform.FindChild("Zoo").gameObject.SetActive(false);
                
                //나무 표시 처리
                for(int treeCnt = 1; treeCnt <= 6; treeCnt++)
                {
                    string treeObj = "Tree_" + treeCnt;
                    if(obj.transform.FindChild(treeObj) != null)
                    {
                        string treeCntStr = "tree" + treeCnt;

                        switch (treeCheck(treeCntStr))
                        {
                            case 1:
                                obj.transform.FindChild(treeObj).FindChild("Pinetree_" + treeCnt).gameObject.SetActive(true);
                                obj.transform.FindChild(treeObj).FindChild("Springtree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Mapletree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Wintertree_" + treeCnt).gameObject.SetActive(false);
                                break;
                            case 2:
                                obj.transform.FindChild(treeObj).FindChild("Pinetree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Springtree_" + treeCnt).gameObject.SetActive(true);
                                obj.transform.FindChild(treeObj).FindChild("Mapletree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Wintertree_" + treeCnt).gameObject.SetActive(false);
                                break;
                            case 3:
                                obj.transform.FindChild(treeObj).FindChild("Pinetree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Springtree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Mapletree_" + treeCnt).gameObject.SetActive(true);
                                obj.transform.FindChild(treeObj).FindChild("Wintertree_" + treeCnt).gameObject.SetActive(false);
                                break;
                            case 4:
                                obj.transform.FindChild(treeObj).FindChild("Pinetree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Springtree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Mapletree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Wintertree_" + treeCnt).gameObject.SetActive(true);
                                break;
                            default:
                                obj.transform.FindChild(treeObj).FindChild("Pinetree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Springtree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Mapletree_" + treeCnt).gameObject.SetActive(false);
                                obj.transform.FindChild(treeObj).FindChild("Wintertree_" + treeCnt).gameObject.SetActive(false);
                                break;
                        }
                    }
                }
            }
        }

        planetLoadCnt = 1;
    }
 
    int treeCheck(string treeCntStr)
    {
        if(treeCntStr == "tree1")
        {
            return SelectDB.Instance().tree1;
        }else if (treeCntStr == "tree2")
        {
            return SelectDB.Instance().tree2;
        }
        else if (treeCntStr == "tree3")
        {
            return SelectDB.Instance().tree3;
        }
        else if (treeCntStr == "tree4")
        {
            return SelectDB.Instance().tree4;
        }else
        {
            return 0;
        }
    }
}


    