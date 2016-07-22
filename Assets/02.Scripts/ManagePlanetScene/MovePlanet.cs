using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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

    //public List<MoveEachPlanet> planets = new List<MoveEachPlanet>(); 
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



    //public bool OnMove
    //{
    //    get
    //    {
    //        foreach (MoveEachPlanet planet in planets)
    //        {
    //            if (!planet.onMoving)
    //                continue;
    //            else
    //                return true;
    //        }
    //        return false;
    //    }
    //}

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


    //public void SetDrag(PointerEventData data)
    //{
    //    //if (Mathf.Abs(data.delta.y) < 10) return;

    //    for (int i = 0; i < planets.Count; i++)
    //    {
    //        if (data.delta.y < 0)
    //            planets[i].MoveNext();
    //        else
    //            planets[i].MovePrev();
    //    }
    //}

    //public void SetDrag(PointerEventData data)
    //{
    //    if (Mathf.Abs(data.delta.y) < 10) return;

    //    for (int i = 0; i < planets.Count; i++)
    //    {
    //        if (data.delta.y < 0)
    //            planets[i].MoveNext();
    //        else
    //            planets[i].MovePrev();
    //    }
    //}

    /* keyboard
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
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

        if (OnMove) return;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            for (int i = 0; i < planets.Count; i++)
            {
                planets[i].MovePrev();
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            for (int i = 0; i < planets.Count; i++)
            {
                planets[i].MoveNext();
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < planets.Count; i++)
            {
                planets[i].Stop();
            }
        }        
    }

    */

}
