using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class csDragRotation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public float dragRate = 5;

    Vector2 oldPos;
    Vector2 newPos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        oldPos = new Vector2(eventData.position.x,eventData.position.y);
        Debug.Log("OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        newPos = new Vector2(eventData.position.x, eventData.position.y);
        Debug.Log(eventData.delta);

        GameObject obj = GameObject.Find("death_planet/death_planet");
        //obj.transform.Rotate(new Vector3(eventData.delta.y/dragRate, 0, -eventData.delta.x/ dragRate));
        obj.transform.Rotate(new Vector3((newPos.y - oldPos.y) / dragRate, 0, -(newPos.x-oldPos.x) / dragRate));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnDragEnd");
    }

}
