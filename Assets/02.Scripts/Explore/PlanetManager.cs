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
    public float checkInterval = 20.0f;
    float deltaSpawnTime = 0.0f;

    int spawnCnt = 1;
    int maxSpawnCnt = 100;

    GameObject[] planetPool;
    int poolSize = 20;

    int planetLoadCnt = 1;


    public int zodiacCnt1;
    public int zodiacCnt2;
    public int zodiacCnt3;
    public int zodiacCnt4;
    public int zodiacCnt5;
    public int zodiacCnt6;
    public int zodiacCnt7;
    public int zodiacCnt8;
    public int zodiacCnt9;
    public int zodiacCnt10;
    public int zodiacCnt11;
    public int zodiacCnt12;

    bool cnt1 = false;
    bool cnt2 = false;
    bool cnt3 = false;
    bool cnt4 = false;
    bool cnt5 = false;
    bool cnt6 = false;
    bool cnt7 = false;
    bool cnt8 = false;
    bool cnt9 = false;
    bool cnt10 = false;
    bool cnt11 = false;
    bool cnt12 = false;

    void Awake()
    {
        Debug.Log(natureObj.Length);
        for (int i = 0; i < natureObj.Length; i++)
        {
            Debug.Log(i + " " + natureObj[i].transform.childCount);
            for (int j = 0; j < natureObj[i].transform.childCount; j++)
            {
                Debug.Log(j + " " + natureObj[i].transform.GetChild(j).gameObject.name);
                natureObj[i].transform.GetChild(j).gameObject.AddComponent<MeshCollider>().enabled = true;
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
        loadStar();
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
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * checkInterval + left;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * checkInterval + left;

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
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * checkInterval + right;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * checkInterval + right;

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
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * checkInterval + up;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * checkInterval + up;

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
                    spaceChecker.transform.position = player.transform.position + player.transform.forward * checkInterval + down;
                    if (GameManager.Instance().spaceCollision == false && GameManager.Instance().scInit == true)
                    {
                        Debug.Log("false!");
                        planetPool[i].transform.position = player.transform.position + player.transform.forward * checkInterval + down;

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

        UpdateDB.Instance().table = "managePlanetTable";
        UpdateDB.Instance().setColumn = " \"User\" = 0 ";
        UpdateDB.Instance().where = " WHERE \"User\"= 1";
        UpdateDB.Instance().UpdateData();

        //초기 행성생성시 데이터 초기화 및 DB INSERT (Table Column 순서 수정필요함)
        InsertDB.Instance().table = "managePlanetTable";
        InsertDB.Instance().column = "name,size,color,mFood,mTitanium,le_persec,locationX,locationY,locationZ,mat,lFood,lTitanium,User";
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
                                     tempmTitanium + "," +      //lTitanium 티타늄 잔존량
                                     "1";
        InsertDB.Instance().Insert();
        SoundManager.Instance().bgmType = 1;
        GameObject.Find("Nav").gameObject.GetComponent<StarNavigation>().spentFuel();  //연료 소모 DB반영
        GameObject.Find("GameManager").gameObject.GetComponent<ButtonController>().TransSceneToPlanet();
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
        Debug.Log(planetLoadCnt + "," + SelectDB.Instance().planetCount);
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
                for (int treeCnt = 1; treeCnt <= 6; treeCnt++)
                {
                    string treeObj = "Tree_" + treeCnt;
                    if (obj.transform.FindChild(treeObj) != null)
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

        //휴식 행성 로드
        SelectDB.Instance().table = "garbageTable";
        SelectDB.Instance().column = "rowid, Count(*)";
        SelectDB.Instance().Select(0);

        SelectDB.Instance().table = "garbageTable";
        SelectDB.Instance().column = "rowid, name, size, color, mat, locationX, locationY, locationZ";
        for (; planetLoadCnt <= SelectDB.Instance().planetCount; planetLoadCnt++)
        {
            SelectDB.Instance().where = "WHERE rowid =" + planetLoadCnt;
            SelectDB.Instance().Select(3);
            SelectDB.Instance().where = " ";
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
                obj.transform.FindChild("Postbox").gameObject.SetActive(false);
                obj.transform.FindChild("Spacestation").gameObject.SetActive(false); 

                for (int treeCnt = 1; treeCnt <= 6; treeCnt++)
                {
                    string treeObj = "Tree_" + treeCnt;
                    if (obj.transform.FindChild(treeObj) != null)
                    {
                        obj.transform.FindChild(treeObj).gameObject.SetActive(false);
                    }
                }
            }
        }
        planetLoadCnt = 1;

    }

    void loadStar()
    {
        SelectDB.Instance().table = "zodiacTable";
        SelectDB.Instance().column = "Count(*)";
        SelectDB.Instance().Select(0);
        for (int i = 1; i <= SelectDB.Instance().starCount; i++)
        {
            SelectDB.Instance().table = "zodiacTable";
            SelectDB.Instance().column = "rowid, open, find, active, zID, zodiac";
            SelectDB.Instance().where = "WHERE \"rowid\" =" + i;
            SelectDB.Instance().Select(4);

            if (SelectDB.Instance().starActive == 0)
            {
                GameObject.Find(SelectDB.Instance().zodiacID).gameObject.GetComponent<SphereCollider>().enabled = true;
                GameObject.Find(SelectDB.Instance().zodiacID).gameObject.GetComponent<SphereCollider>().isTrigger = true;
                GameObject.Find(SelectDB.Instance().zodiacID).transform.FindChild("Point light").gameObject.SetActive(false);
            }
            else if (SelectDB.Instance().starActive == 1)
            {
                Debug.Log(SelectDB.Instance().zodiacName);
                if (SelectDB.Instance().zodiacName == "Aquarius")
                    zodiacCnt1 += 1;
                else if (SelectDB.Instance().zodiacName == "Pisces")
                    zodiacCnt2++;
                else if (SelectDB.Instance().zodiacName == "Aries")
                    zodiacCnt3++;
                else if (SelectDB.Instance().zodiacName == "Taurus")
                    zodiacCnt4++;
                else if (SelectDB.Instance().zodiacName == "Gemini")
                    zodiacCnt5++;
                else if (SelectDB.Instance().zodiacName == "Cancer")
                    zodiacCnt6++;
                else if (SelectDB.Instance().zodiacName == "Leo")
                    zodiacCnt7++;
                else if (SelectDB.Instance().zodiacName == "Virgo")
                    zodiacCnt8++;
                else if (SelectDB.Instance().zodiacName == "Libra")
                    zodiacCnt9++;
                else if (SelectDB.Instance().zodiacName == "Scorpius")
                    zodiacCnt10++;
                else if (SelectDB.Instance().zodiacName == "Sagittarius")
                    zodiacCnt11++;
                else if (SelectDB.Instance().zodiacName == "Capricornus")
                    zodiacCnt12++;
                GameObject.Find(SelectDB.Instance().zodiacID).transform.FindChild("Point light").gameObject.SetActive(true);
                GameObject.Find(SelectDB.Instance().zodiacID).gameObject.GetComponent<SphereCollider>().enabled = false;
                
            }
            if (zodiacCnt1 == 6 && cnt1 == false)
            {
                for (int cnt = 7; cnt < 17; cnt++)
                {
                    Debug.Log(GameObject.Find("Aquarius").transform.FindChild("aqua_" + cnt).name);
                    GameObject.Find("Aquarius").transform.FindChild("aqua_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Aquarius").transform.FindChild("aqua_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                    
                }
                cnt1 = true;
            }
            if (zodiacCnt2 == 5 && cnt2 == false)
            {
                for (int cnt = 6; cnt < 22; cnt++)
                {
                    GameObject.Find("Pisces").transform.FindChild("pis_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Pisces").transform.FindChild("pis_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt2 = true;
            }
            //if (zodiacCnt3 == 4 && cnt3 == false)
            //{
            //    //작은별없음 Aries
            //  cnt3 == true;
            //}
            if (zodiacCnt4 == 6 && cnt4 == false)
            {
                for (int cnt = 7; cnt < 20; cnt++)
                {
                    GameObject.Find("Taurus").transform.FindChild("tau_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Taurus").transform.FindChild("tau_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt4 = true;
            }
            if (zodiacCnt5 == 5 && cnt5 == false)
            {
                for (int cnt = 6; cnt < 18; cnt++)
                {
                    GameObject.Find("Gemini").transform.FindChild("gem_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Gemini").transform.FindChild("gem_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt5 = true;
            }
            if (zodiacCnt6 == 5 && cnt6 == false)
            {
                for (int cnt = 6; cnt < 8; cnt++)
                {
                    GameObject.Find("Cancer").transform.FindChild("can_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Cancer").transform.FindChild("can_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt6 = true;
            }
            if (zodiacCnt7 == 4 && cnt7 == false)
            {
                for (int cnt = 5; cnt < 17; cnt++)
                {
                    GameObject.Find("Leo").transform.FindChild("leo_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Leo").transform.FindChild("leo_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt7 = true;
            }
            if (zodiacCnt8 == 5 && cnt8 == false)
            {
                for (int cnt = 6; cnt < 16; cnt++)
                {
                    GameObject.Find("Virgo").transform.FindChild("vir_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Virgo").transform.FindChild("vir_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt8 = true;
            }
            if (zodiacCnt9 == 5 && cnt9 == false)
            {
                for (int cnt = 6; cnt < 7; cnt++)
                {
                    GameObject.Find("Libra").transform.FindChild("lib_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Libra").transform.FindChild("lib_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt9 = true;
            }
            if (zodiacCnt10 == 6 && cnt10 == false)
            {
                for (int cnt = 7; cnt < 13; cnt++)
                {
                    GameObject.Find("Scorpius").transform.FindChild("sco_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Scorpius").transform.FindChild("sco_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt10 = true;
            }
            if (zodiacCnt11 == 6 && cnt11 == false)
            {
                for (int cnt = 7; cnt < 22; cnt++)
                {
                    GameObject.Find("Sagittarius").transform.FindChild("sag_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Sagittarius").transform.FindChild("sag_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt11 = true;
            }
            if (zodiacCnt12 == 6 && cnt12 == false)
            {
                for (int cnt = 7; cnt < 13; cnt++)
                {
                    GameObject.Find("Capricornus").transform.FindChild("cap_" + cnt).gameObject.SetActive(true);
                    GameObject.Find("Capricornus").transform.FindChild("cap_" + cnt).gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                cnt12 = true;
            }

        }

    }

    int treeCheck(string treeCntStr)
    {
        if (treeCntStr == "tree1")
        {
            return SelectDB.Instance().tree1;
        }
        else if (treeCntStr == "tree2")
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
        }
        else
        {
            return 0;
        }
    }
}


