using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class newDragPlanetList : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float deltaX;

    static bool moving = false;
    //MovePlanet

    void Start()
    {
        deltaX = 0;
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        //MovePlanet.Instance.SetDrag(eventData);
        //return;
        //deltaX = eventData.delta.y;
        //deltaX = eventData.scrollDelta.y;
        //deltaX = eventData.useDragThreshold;

        deltaX = eventData.delta.y;

        Debug.Log(deltaX);
        //if (Mathf.Abs(deltaX) < 10) return;
        if (!moving)
        {
               StartCoroutine(dragFlase());
            if (deltaX > 0)
            {
                MovePlanet.Instance.insertDrag();
                MovePlanet.Instance.moveUp();
            }
            else if (deltaX < 0)
            {
                MovePlanet.Instance.insertDrag();
                MovePlanet.Instance.moveDown();

            }

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDragEnd");
    }

    IEnumerator dragFlase()
    {
        moving = true;

        yield return new WaitForSeconds(0.4f);


        moving = false;


    }
}
