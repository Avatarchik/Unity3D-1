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


        //setPlanets();
    }

    public List<MoveEachPlanet> planets = new List<MoveEachPlanet>();    
    public List<Transform> orderdPoints = new List<Transform>();
    public List<Transform> points = new List<Transform>();

    bool bDrag = false;
    int movePos = 0;

    public List<MoveEachPlanet> planetList = new List<MoveEachPlanet>();

    public float moveTime = 0.5f;
    public float addTime = 1f;

    public int planetCount;

    public GameObject instantPosition;




    public void getPlanets()
    {
        int count = 0;
        while (count < planetCount)
        {
            planets.Add(planetList[count]);
            Instantiate(planetList[count++], instantPosition.transform.position, instantPosition.transform.rotation);

       }

        setPlanets();
    }


    void setPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            points.Add(orderdPoints[i]);
        }

        points.Sort((x, y) => string.Compare(x.name, y.name));

        for (int i = 0; i < points.Count; i++)
        {
            planets[i].transform.position = points[i].position;
            planets[i].curPos = i;
            planets[i].lastPos = i;
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

        if (OnMove) return;

        if(movePos == 1)
        {
            movePos = 0;
            for (int i = 0; i < planets.Count; i++)
            {
                planets[i].MovePrev();
            }
        }
        
        
        if(movePos == -1)
        {
            movePos = 0;
            for (int i = 0; i < planets.Count; i++)
            {
                planets[i].MoveNext();
            }
        }
        
    }

    public bool OnMove
    {
        get
        {
            foreach (MoveEachPlanet planet in planets)
            {
                if (!planet.onMoving)
                    continue;
                else
                    return true;
            }
            return false;
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
