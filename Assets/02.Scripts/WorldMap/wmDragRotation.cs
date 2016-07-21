using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class wmDragRotation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public float dragRate = 40;
    
    Vector2 oldPos;
    Vector2 newPos;

    GameObject obj;
    void Start()
    {
        obj = GameObject.Find("Main Camera");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (WorldMapManager.Instance().dragState == false)
        {
            WorldMapManager.Instance().dragState = true;
        }
        oldPos = new Vector2(eventData.position.x, eventData.position.y);
        //Debug.Log("OnBeginDrag");
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(WorldMapManager.Instance().dragState == false)
        {
            WorldMapManager.Instance().dragState = true;
        }
        //if (Input.touchCount == 1)  //Build Mode
        //{

            //Debug.Log("OnDrag");
            newPos = new Vector2(eventData.position.x, eventData.position.y);
            //Debug.Log(eventData.delta);

            GameObject obj = GameObject.Find("Galaxy");
            //obj.transform.Rotate(new Vector3(eventData.delta.y/dragRate, 0, -eventData.delta.x/ dragRate));
            obj.transform.Rotate(new Vector3((newPos.y - oldPos.y) / dragRate, 0, -(newPos.x - oldPos.x) / dragRate));
        //}//Build Mode

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(WorldMapManager.Instance().dragState == true)
        {
            WorldMapManager.Instance().dragState = false;
        }
        //Debug.Log("OnDragEnd");
    }

}
