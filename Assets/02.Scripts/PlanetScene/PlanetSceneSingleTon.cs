﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class PlanetSceneSingleTon : MonoBehaviour {

    static PlanetSceneSingleTon _instance = null;

    public static PlanetSceneSingleTon Instance
    {
        get
        {
            return _instance;
        }
    }
    //color) 1= blue, 2= red , 3= yellow, 4= violate, 5= green, 6 = Orange
    //size) 1= small, 2 = midium, 3= large, 4= xlarge
    //mat ) 1= 1, 2=2, 3=3
    //list입력관련 (Color)(Size)(Mat) -> 변경순서mat->size->color

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        int count = 0;
        for (int i = 1; i <= 6; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                for (int k = 1; k <= 3; k++)
                {
                    D_PlanetList.Add(i * 100 + j * 10 + k, PlanetList[count]);
                    count++;
                }
            }
        }
    }


    public int cPlanet;
    public int cFood;
    public int cTitanium;
    public int cRE;
    public int cYE;
    public int cBE;
    public int cOE;
    public int cGE;
    public int cVE;
    public int cPE;
    public int shipNum;


    public int rowid;
    public string pName;
    public int size;
    public int color;
    public int mat;
    public int mFood;
    public int mTitanium;
    public float locationX;
    public float locationY;
    public float locationZ;
    public int le_persec;
    public bool position_house;
    public int state;
    public bool user;
    public int neighbor;
    public int lFood;
    public int lTitanium;
    public string planetTouchT;
    public string titaniumTouchT;
    public string treeTouchT;
    public string breaktime;

    public int tree1;
    public int tree2;
    public int tree3;
    public int tree4;
    public int tree5;
    public int tree6;


    public GameObject UIobj;
    public GameObject MoveBtn;
    public GameObject EnergyBtn;
    public GameObject notResText;
    public GameObject SQLManager;

    public bool activeFusionPanal = false;

    public bool shipTouch = false;


    public List<GameObject> PlanetList = new List<GameObject>();
    public Dictionary<int, GameObject> D_PlanetList = new Dictionary<int, GameObject>();
    public List<Sprite> EnergyIconList = new List<Sprite>();

    public float getCountFood;
    public float getCountTitanium;
    public float getCountE;
    public float getCountEE;

    public int maxStoreFood;
    public int maxStoreTitanium;
    int maxStoreE;

    public int maxFood;
    public int maxTitanium;
    public int maxE;

    int treeCount;
    public GameObject getText;
    public GameObject getEnergyText;


    GameObject tempTex;

    string tempString = "";



    GameObject Pla;
    public GameObject PlanetPosition;

    public GameObject MovePanal;

    public RuntimeAnimatorController cont;

    public GameObject getEspawn;

    void Start()
    {
        treeCount = 0;
    }

    public void callPlanet()
    {
        int PlanetNum = color * 100 + size * 10 + mat;
        setPlanet(PlanetNum);

    }
    
    public void setPlanet(int Num)
    {
        if (PlanetPosition.transform.childCount == 1)
        {
            Pla = Instantiate(D_PlanetList[Num], PlanetPosition.transform.position, PlanetPosition.transform.rotation) as GameObject;
            Pla.name = "death_planet";
            Pla.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            Pla.transform.parent = PlanetPosition.transform;
            Camera.main.transform.parent = PlanetPosition.transform.FindChild("DragCamera").transform;
            Destroy(Pla.GetComponent<Rigidbody>());
            //Destroy(Pla.GetComponent<SphereCollider>());

            Pla.gameObject.GetComponent<SphereCollider>().isTrigger = false;
            Pla.transform.FindChild("PC/astronaut").gameObject.tag = "Player";
            Pla.transform.FindChild("PC").gameObject.tag = "Player";

            Pla.transform.FindChild("PC/astronaut").gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            //Pla.transform.FindChild("PC/astronaut").gameObject.transform.rotation( new Vector3(0f, 0f, 0f));
            //Pla.transform.FindChild("PC/astronaut").gameObject.transform.position = new Vector3(0f, 0f, 0f);

            Pla.transform.FindChild("PC/astronaut").gameObject.AddComponent<BoxCollider>();
            Pla.transform.FindChild("PC/astronaut").gameObject.GetComponent<BoxCollider>().center = new Vector3(0f, 0.7f, 0f);
            Pla.transform.FindChild("PC/astronaut").gameObject.GetComponent<BoxCollider>().size = new Vector3(0.9f, 1.5f, 1f);


            Pla.gameObject.AddComponent<GravityAttractor>();
            Pla.transform.FindChild("PC").gameObject.AddComponent<GravityBody>();
            Pla.transform.FindChild("PC").gameObject.GetComponent<GravityBody>().attractor = Pla.gameObject.GetComponent<GravityAttractor>();
            Pla.transform.FindChild("PC").gameObject.AddComponent<PlayerController>();

            Pla.transform.FindChild("PC").gameObject.GetComponent<Animator>().runtimeAnimatorController = cont;
            Pla.transform.FindChild("PC").gameObject.AddComponent<Rigidbody>();
            Pla.transform.FindChild("PC").gameObject.AddComponent<CapsuleCollider>();
            Pla.transform.FindChild("PC").gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0f, 1f, 0f);
            Pla.transform.FindChild("PC").gameObject.GetComponent<CapsuleCollider>().height = 2f;

            //Pla.transform.FindChild("PC").gameObject.GetComponent<Rigidbody>().freezeRotation;

            Pla.transform.FindChild("PC").gameObject.GetComponent<PlayerController>().anim = Pla.transform.FindChild("PC").gameObject.GetComponent<Animator>();

        }
    }


    public void callShip()
    {
        GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
        GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
        GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
        GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
        GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

        if (rowid != cPlanet)
        {
            return;
        }
        setShip(shipNum);

    }

    public void setShip(int num)
    {
        switch (num)
        {
            case 1:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 2:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 3:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 4:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 5:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(true);

                break;

            default:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;
        }


    }
    
    public void callTree()
    {
        setTree(1, tree1);
        setTree(2, tree2);
        setTree(3, tree3);
        setTree(4, tree4);
        setTree(5, tree5);
        setTree(6, tree6);
    }

    public void setTree(int TreeCount, int TreeNum)
    {
        string stringTree = "PlanetPosition/death_planet/Tree_" + TreeCount;

        if (GameObject.Find(stringTree) == null)
        {
            return;

        }
        switch (TreeNum)
        {
            case 0:
                GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);
                break;

            case 1:
                GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(true);
                GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);

                break;

            case 2:
                GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(true);
                GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);

                break;

            case 3:
                GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(true);
                GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);

                break;

            case 4:
                GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
                GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(true);

                break;

            default:
                break;

        }

    }


    public void callNeighber()
    {
        setNeighber();
    }

    public void setNeighber()
    {
        if (neighbor == 0)
        {
            GameObject.Find("PlanetPosition/death_planet/Ship_Neighbor").gameObject.SetActive(false);
            GameObject.Find("PlanetPosition/death_planet/Neighbor").gameObject.SetActive(false);
        }
        else
        {
            GameObject.Find("PlanetPosition/death_planet/Ship_Neighbor").gameObject.SetActive(true);
            GameObject.Find("PlanetPosition/death_planet/Neighbor").gameObject.SetActive(true);

        }
    }

    public void callStation()
    {
        setStation();
    }

    public void setStation()
    {
        if (position_house)
        {
            GameObject.Find("PlanetPosition/death_planet/Spacestation").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("PlanetPosition/death_planet/Spacestation").gameObject.SetActive(false);

        }
    }

    public void callPostBox()
    {
        setPostBox();
    }

    public void setPostBox()
    {
        if (cPlanet == rowid)
        {
            GameObject.Find("PlanetPosition/death_planet/Postbox").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("PlanetPosition/death_planet/Postbox").gameObject.SetActive(false);
        }
    }

    public void setVisibleEnergyBtn()
    {
        if (gameObject.scene.name != "Defense")
        {
            EnergyBtn.gameObject.SetActive(false);
            if (lFood == 0 && lTitanium == 0)
            {
                EnergyBtn.gameObject.SetActive(false);
                notResText.gameObject.SetActive(true);
                return;
            }

            if (!position_house)
            {
                EnergyBtn.gameObject.SetActive(false);
                return;
            }

            EnergyBtn.gameObject.SetActive(true);
        }
    }

    public void setVisibleMoveBtn()
    {
        if (gameObject.scene.name != "Defense")
        {
            if (cPlanet == rowid)
            {
                MoveBtn.gameObject.SetActive(false);
            }
            else
            {
                MoveBtn.gameObject.SetActive(true);
            }
        }
    }

    public void getFood(Vector3 textPos)
    {

        treeCount = checkTree();
        int canStoreMaxFood = maxStoreFood * treeCount;

        System.DateTime touchTime = System.DateTime.Now;
        string Query = "";
        if (treeTouchT == "0")
        {
            Query = "UPDATE managePlanetTable SET treeTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1 " ;
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);

            tempTex = Instantiate(getText, textPos, GameObject.Find("PlanetPosition/DragCamera").transform.rotation) as GameObject;
            tempTex.GetComponent<getTextScript>().setText("생산시작");
            return;
        }

        if (cFood >= maxFood)
        {
            cFood = maxFood;
            Query = "UPDATE managePlanetTable SET treeTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1 ";
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);

            tempTex = Instantiate(getText, textPos, GameObject.Find("PlanetPosition/DragCamera").transform.rotation) as GameObject;
            tempTex.GetComponent<getTextScript>().setText("MAX");

            return;
        }

        System.DateTime preT = System.DateTime.ParseExact(treeTouchT, "yyyy-MM-dd HH:mm:ss", null);

        System.TimeSpan deff = touchTime - preT;
        int defTime = System.Convert.ToInt32(deff.TotalSeconds);
        int calculateFood = System.Convert.ToInt32(defTime * getCountFood);

        //이후시간, 이전시간 = 1, 같은경우 = 0, 이전,이후 = -1
        int comp = System.DateTime.Compare(touchTime, preT);

        if (comp == 1)
        {
            if (lFood < canStoreMaxFood)
            {
                if (calculateFood < lFood)
                {
                    cFood += calculateFood;
                    lFood -= calculateFood;

                    tempString = calculateFood.ToString();
                }
                else // calculateFood >=lFood
                {
                    cFood += lFood;
                    lFood = 0;

                    tempString = lFood.ToString();
                }
            }
            else // lFood >= maxStoreFood)
            {
                if (calculateFood < canStoreMaxFood)
                {
                    cFood += calculateFood;
                    lFood -= calculateFood;

                    tempString = calculateFood.ToString();
                }
                else //calculateFood >= maxStoreFood && lFood
                {
                    cFood += canStoreMaxFood;
                    lFood -= canStoreMaxFood;

                    tempString = canStoreMaxFood.ToString();
                }
            }

            if (cFood >= maxFood)
            {
                cFood = maxFood;
            }
            if (lFood < 0)
            {
                lFood = 0;
            }

            treeTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");


            tempTex = Instantiate(getText, textPos, GameObject.Find("PlanetPosition/DragCamera").transform.rotation) as GameObject;
            tempTex.GetComponent<getTextScript>().setText(tempString);

            string tempQuery1 = "UPDATE userTable SET cFood = " + cFood;
            string tempQuery2 = "UPDATE managePlanetTable SET treeTouchT = \"" + treeTouchT + "\", lFood = " + lFood + " WHERE User = 1 ";
            Debug.Log(tempQuery1);
            Debug.Log(tempQuery2);
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(tempQuery1);
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(tempQuery2);

            setVisibleEnergyBtn();

            return;
        }
        else if (comp == 0)
        {
            return;
        }
        else
        {
            treeTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");
            Query = "UPDATE managePlanetTable SET treeTouchT = \"" + treeTouchT + "\" WHERE User = 1" ;
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
        }
    }

    int checkTree()
    {
        int a = 0;
        if (tree1 != 0)
        {
            a++;
            if (tree2 != 0)
            {
                a++;

                if (tree3 != 0)
                {
                    a++;

                    if (tree4 != 0)
                    {
                        a++;

                        if (tree5 != 0)
                        {
                            a++;

                            if (tree6 != 0)
                            {
                                a++;
                            }
                        }
                    }
                }
            }
        }
        return a;
    }

    public void getTitanium(Vector3 textPos)
    {
        System.DateTime touchTime = System.DateTime.Now;
        string Query = "";

        if (titaniumTouchT == "0")
        {
            Query = "UPDATE managePlanetTable SET titaniumTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1" ;
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);

            tempTex = Instantiate(getText, textPos, GameObject.Find("PlanetPosition/DragCamera").transform.rotation) as GameObject;
            tempTex.GetComponent<getTextScript>().setText("생산시작");

            return;
        }

        if (cTitanium >= maxTitanium)
        {
            cTitanium = maxTitanium;
            Query = "UPDATE managePlanetTable SET treeTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);

            tempTex = Instantiate(getText, textPos, GameObject.Find("PlanetPosition/DragCamera").transform.rotation) as GameObject;
            tempTex.GetComponent<getTextScript>().setText("MAX");

            return;
        }


        System.DateTime preT = System.DateTime.ParseExact(titaniumTouchT, "yyyy-MM-dd HH:mm:ss", null);
        System.TimeSpan deff = touchTime - preT;
        int defTime = System.Convert.ToInt32(deff.TotalSeconds);
        int calculateTitanium = System.Convert.ToInt32(defTime * getCountTitanium);

        //이후시간, 이전시간 = 1, 같은경우 = 0, 이전,이후 = -1
        int comp = System.DateTime.Compare(touchTime, preT);

        if (comp == 1)
        {
            if (lTitanium < maxStoreTitanium)
            {
                if (calculateTitanium < lTitanium)
                {
                    cTitanium += calculateTitanium;
                    lTitanium -= calculateTitanium;

                    tempString = calculateTitanium.ToString();

                }
                else // calculateTitanium >=lTitanium
                {
                    cTitanium += lTitanium;
                    lTitanium = 0;

                    tempString = lTitanium.ToString();

                }
            }
            else // lFood >= maxStoreFood)
            {
                if (calculateTitanium < maxStoreTitanium)
                {
                    cTitanium += calculateTitanium;
                    lTitanium -= calculateTitanium;

                    tempString = calculateTitanium.ToString();

                }
                else //calculateFood >= maxStoreFood && lFood
                {
                    cTitanium += maxStoreTitanium;
                    lTitanium -= maxStoreTitanium;

                    tempString = maxStoreTitanium.ToString();

                }
            }

            if (cTitanium > maxTitanium)
            {
                cTitanium = maxTitanium;
            }
            if (lTitanium < 0)
            {
                lTitanium = 0;
            }

            titaniumTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

            string tempQuery1 = "UPDATE userTable SET cTitanium = " + cTitanium;
            string tempQuery2 = "UPDATE managePlanetTable SET titaniumTouchT = \"" + titaniumTouchT + "\", lTitanium = " + lTitanium + " WHERE User = 1 ";
            Debug.Log(tempQuery1);
            Debug.Log(tempQuery2);

            tempTex = Instantiate(getText, textPos, GameObject.Find("PlanetPosition/DragCamera").transform.rotation) as GameObject;
            tempTex.GetComponent<getTextScript>().setText(tempString);


            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(tempQuery1);
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(tempQuery2);

            setVisibleEnergyBtn();

            return;
        }
        else if (comp == 0)
        {
            return;
        }
        else
        {
            titaniumTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");
            Query = "UPDATE managePlanetTable SET titaniumTouchT = \"" + titaniumTouchT + "\" WHERE user = 1";
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
        }
    }

    public void getEnergy()
    {
        System.DateTime touchTime = System.DateTime.Now;
        string Query = "";
        if (planetTouchT == "0")
        {
            Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
            tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
            tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
            tempTex.GetComponent<getEnergyTextScript>().setText("생산시작");
            return;
        }


        if (lFood == 0 && lTitanium == 0)
        {
            Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
            return;
        }

        switch (size)
        {
            case 1:
                maxStoreE = 200;
                break;
            case 2:
                maxStoreE = 400;
                break;
            case 3:
                maxStoreE = 800;
                break;
            case 4:
                maxStoreE = 1600;
                break;
            default:
                maxStoreE = 200;
                break;
        }



        System.DateTime preT = System.DateTime.ParseExact(planetTouchT, "yyyy-MM-dd HH:mm:ss", null);
        System.TimeSpan deff = touchTime - preT;
        int defTime = System.Convert.ToInt32(deff.TotalSeconds);
        int calculateEnergy = System.Convert.ToInt32(defTime * getCountE);

        //이후시간, 이전시간 = 1, 같은경우 = 0, 이전,이후 = -1
        int comp = System.DateTime.Compare(touchTime, preT);

        if (comp == 1)
        {
            string tempQuery1 = "";
            string tempQuery2 = "";


            switch (color)
            {
                case 1: //b

                    if (cBE >= maxE)
                    {
                        cBE = maxE;
                        Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
                        SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("MAX");
                        return;
                    }

                    if (calculateEnergy <= maxStoreE)
                    {
                        cBE += calculateEnergy;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + calculateEnergy.ToString());
                    }
                    else
                    {
                        cBE += maxStoreE;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + maxStoreE.ToString());
                    }


                    if (cBE > maxE)
                    {
                        cBE = maxE;
                    }

                    planetTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

                    tempQuery1 = "UPDATE userTable SET cBE = " + cBE;
                    tempQuery2 = "UPDATE managePlanetTable SET planetTouchT = \"" + planetTouchT + "\" WHERE User = 1";

                    break;

                case 2: //r 
                    if (cRE >= maxE)
                    {
                        cRE = maxE;
                        Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
                        SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("MAX");
                        return;
                    }

                    if (calculateEnergy <= maxStoreE)
                    {
                        cRE += calculateEnergy;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + calculateEnergy.ToString());
                    }
                    else
                    {
                        cRE += maxStoreE;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + maxStoreE.ToString());
                    }


                    if (cRE > maxE)
                    {
                        cRE = maxE;
                    }

                    planetTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

                    tempQuery1 = "UPDATE userTable SET cRE = " + cRE;
                    tempQuery2 = "UPDATE managePlanetTable SET planetTouchT = \"" + planetTouchT + "\" WHERE User = 1";

                    break;

                case 3: //y
                    if (cYE >= maxE)
                    {
                        cYE = maxE;
                        Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
                        SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("MAX");
                        return;
                    }

                    if (calculateEnergy <= maxStoreE)
                    {
                        cYE += calculateEnergy;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + calculateEnergy.ToString());
                    }
                    else
                    {
                        cYE += maxStoreE;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + maxStoreE.ToString());
                    }


                    if (cYE > maxE)
                    {
                        cYE = maxE;
                    }

                    planetTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

                    tempQuery1 = "UPDATE userTable SET cYE = " + cYE;
                    tempQuery2 = "UPDATE managePlanetTable SET planetTouchT = \"" + planetTouchT + "\" WHERE User = 1";

                    break;

                case 4: //v
                    if (cVE >= maxE)
                    {
                        cVE = maxE;
                        Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
                        SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("MAX");
                        return;
                    }

                    if (calculateEnergy <= maxStoreE)
                    {
                        cVE += calculateEnergy;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + calculateEnergy.ToString());
                    }
                    else
                    {
                        cVE += maxStoreE;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + maxStoreE.ToString());
                    }


                    if (cVE > maxE)
                    {
                        cVE = maxE;
                    }

                    planetTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

                    tempQuery1 = "UPDATE userTable SET cVE = " + cVE;
                    tempQuery2 = "UPDATE managePlanetTable SET planetTouchT = \"" + planetTouchT + "\" WHERE User = 1";
                    break;

                case 5: //g
                    if (cGE >= maxE)
                    {
                        cGE = maxE;
                        Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
                        SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("MAX");
                        return;
                    }

                    if (calculateEnergy <= maxStoreE)
                    {
                        cGE += calculateEnergy;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + calculateEnergy.ToString());
                    }
                    else
                    {
                        cGE += maxStoreE;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + maxStoreE.ToString());
                    }


                    if (cGE > maxE)
                    {
                        cGE = maxE;
                    }

                    planetTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

                    tempQuery1 = "UPDATE userTable SET cGE = " + cGE;
                    tempQuery2 = "UPDATE managePlanetTable SET planetTouchT = \"" + planetTouchT + "\" WHERE User = 1";
                    break;

                case 6: //o
                    if (cOE >= maxE)
                    {
                        cOE = maxE;
                        Query = "UPDATE managePlanetTable SET planetTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE User = 1";
                        SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("MAX");
                        return;
                    }

                    if (calculateEnergy <= maxStoreE)
                    {
                        cOE += calculateEnergy;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + calculateEnergy.ToString());
                    }
                    else
                    {
                        cOE += maxStoreE;
                        tempTex = Instantiate(getEnergyText, getEspawn.transform.localPosition, Quaternion.identity) as GameObject;
                        tempTex.transform.SetParent(GameObject.Find("UI").transform, false);
                        tempTex.GetComponent<getEnergyTextScript>().setText("+" + maxStoreE.ToString());
                    }


                    if (cOE > maxE)
                    {
                        cOE = maxE;
                    }

                    planetTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

                    tempQuery1 = "UPDATE userTable SET cOE = " + cOE;
                    tempQuery2 = "UPDATE managePlanetTable SET planetTouchT = \"" + planetTouchT + "\" WHERE User = 1";
                    break;

                default:
                    return;
            }


            Debug.Log(tempQuery1);
            Debug.Log(tempQuery2);
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(tempQuery1);
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(tempQuery2);

            return;
        }
        else if (comp == 0)
        {
            return;
        }
        else
        {
            planetTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");
            Query = "UPDATE managePlanetTable SET planetTouchT = \"" + planetTouchT + "\" WHERE User = 1";
            SQLManager.GetComponent<PlanetSceneSQL>().UpdateQuery(Query);
        }
    }

    void Update()
    {
        if (gameObject.scene.name != "Defense")     //수비 씬 예외처리
        {


            UIobj.GetComponent<PlanetUIFromSQL>().setUIText();
            if (activeFusionPanal)
            {
                UIobj.GetComponent<PlanetFusionScript>().setText();

            }
        }
    }


    public void downMoveBtn()
    {
        GameObject.Find("UI").GetComponent<PlanetTouchRay>().enabled = false;
        MovePanal.gameObject.SetActive(true);

    }

    public void downOKInMove()
    {
        GameObject.Find("UI").GetComponent<PlanetTouchRay>().enabled = true;
        GameObject.Find("GameManager/UIManager").GetComponent<ButtonController>().Movebtn();
    }

    public void downNOInMove()
    {
        GameObject.Find("UI").GetComponent<PlanetTouchRay>().enabled = true;
        MovePanal.gameObject.SetActive(false);
    }

}

