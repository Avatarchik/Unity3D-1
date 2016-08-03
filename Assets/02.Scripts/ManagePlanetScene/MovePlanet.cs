using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class MovePlanet : MonoBehaviour
{
    static MovePlanet _instance = null;

    public static MovePlanet Instance
    {
        get
        {
            return _instance;
        }
    }
    
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
                    D_PlanetList.Add(i * 100 + j * 10 + k, planetList[count]);
                    count++;
                }
            }
        }

    }

    public List<GameObject> planets = new List<GameObject>();
    
    public List<Transform> orderdPoints = new List<Transform>();
    public List<Transform> points = new List<Transform>();

    bool bDrag = false;
    int movePos = 0;

    public List<GameObject> planetList = new List<GameObject>();
    public Dictionary<int, GameObject> D_PlanetList = new Dictionary<int, GameObject>();

    public float moveTime = 0.5f;
    public float addTime = 1f;

    public int planetCount;

    public GameObject instantPosition;
    public GameObject myPosition;

    public GameObject prefStar;

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

    public Text textFood;
    public Text textTitanium;
    public Text textPE;

    public void setResource()
    {
        textFood.text = cFood.ToString();
        textTitanium.text = cTitanium.ToString();
        textPE.text = cPE.ToString();
    }

    public void getPlanets(int color, int size, int mat, int rowid)
    {
        int count = color * 100 + size * 10 + mat;
        GameObject temp;
        temp = Instantiate(D_PlanetList[count], instantPosition.transform.position, instantPosition.transform.rotation) as GameObject;
        temp.AddComponent<MoveEachPlanet>();
        temp.AddComponent<PlanetInfo>();
        temp.name = rowid.ToString();
        temp.transform.parent = GameObject.Find("RotatePlanet").transform;
        planets.Add(temp);
        count++;

    }


    public void getStar(int rowid)
    {
        GameObject temp;
        temp = Instantiate(prefStar, instantPosition.transform.position, instantPosition.transform.rotation) as GameObject;
        temp.AddComponent<MoveEachPlanet>();
        temp.AddComponent<StarInfo>();
        temp.name = rowid.ToString();
        temp.transform.parent = GameObject.Find("RotateStar").transform;
        planets.Add(temp);

    }


    public void nowPlanet(int color, int size, int mat, int rowid)
    {
        int count = color * 100 + size * 10 + mat;
        GameObject nowPlanet;
        nowPlanet = Instantiate(D_PlanetList[count], myPosition.transform.position, Quaternion.Euler(335f,0.01f,15f)) as GameObject;
        nowPlanet.AddComponent<PlanetInfo>();
        nowPlanet.name = "Myplanet";
        nowPlanet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        nowPlanet.transform.parent = GameObject.Find("CurrentPlanet").transform;

        //setShip(shipNum);
        
    }


    public void callShip()
    {
        GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_1").gameObject.SetActive(false);
        GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_2").gameObject.SetActive(false);
        GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_3").gameObject.SetActive(false);
        GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_4").gameObject.SetActive(false);
        GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_5").gameObject.SetActive(false);

        setShip(shipNum);

    }

    public void setShip(int num)
    {
        switch (num)
        {
            case 1:
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_1").gameObject.SetActive(true);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 2:
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_2").gameObject.SetActive(true);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 3:
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_3").gameObject.SetActive(true);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 4:
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_4").gameObject.SetActive(true);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 5:
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_5").gameObject.SetActive(true);

                break;

            default:
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("CurrentPlanet/Myplanet/Ship/Ship_5").gameObject.SetActive(false);

                break;
        }


    }




    public void setPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            points.Add(orderdPoints[i]);
        }

        points.Sort((x, y) => string.Compare(x.name, y.name));


        for (int i = 0; i < points.Count; i++)
        {
            planets[i].transform.position = points[i].position;
            //planets[i].curPos = i;
            //planets[i].lastPos = i;
            planets[i].GetComponent<MoveEachPlanet>().curPos = i;
            planets[i].GetComponent<MoveEachPlanet>().lastPos = i;
        }

    }

    void Update()
    {

        if(bDrag)
        {
            if (addTime < 5)
                addTime += 0.1f;
            else
                addTime = 5;
        }
        else
        {
            if (addTime > 1)
                addTime -= 0.1f;
            else
                addTime = 1f;
        }
        bDrag = false;

        //if (OnMove) return;

        if(movePos == 1)
        {
            movePos = 0;
            for (int i = 0; i < planets.Count; i++)
            {
                planets[i].GetComponent<MoveEachPlanet>().MovePrev();
            }
        }
        
        
        if(movePos == -1)
        {
            movePos = 0;
            for (int i = 0; i < planets.Count; i++)
            {
                planets[i].GetComponent<MoveEachPlanet>().MoveNext();
            }
        }
        
    }

    public void insertDrag()
    {
        bDrag = true;

    }

    public void moveUp()
    {
        movePos = 1;

    }

    public void moveDown()
    {
        movePos = -1;
    }



}
