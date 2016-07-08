using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class csDragPlanetList : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public float dragRate = 40;
    bool initPlanet = false;
    float coRotate = 0;

    Vector2 oldPos;
    Vector2 newPos;

    List<GameObject> pos3;
    GameObject obj;
    csRotatePath script;

    static bool moving = false;
    List<GameObject> planets;

    void Start()
    {
        obj = GameObject.Find("RotatePath");
        script = obj.GetComponent<csRotatePath>();
        
        StartCoroutine("callMakePlanet");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        
        if (!moving)
        {
            StartCoroutine("callMakePlanet");
        }
        //Debug.Log("OnDrag");

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDragEnd");
    }

    IEnumerator callMakePlanet()
    {
        moving = true;

        
        script.makePlanet();
        GameObject temp = GameObject.Find("RotatePlanet");
        temp.BroadcastMessage("setI", SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(0.42f);

        moving = false;

    }
}
