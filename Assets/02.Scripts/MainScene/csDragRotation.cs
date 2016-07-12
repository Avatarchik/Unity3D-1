using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class csDragRotation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public float dragRate = 40;

    Vector2 oldPos;
    Vector2 newPos;
    Vector2 delPos;

    GameObject obj;
    GameObject RotateBase;
    GameObject planet;

    Vector3 planetRotation = new Vector3(0, 0, 0);


    void Start()
    {
        //planetRotation = new Vector3(0, 0, 0);
        obj = GameObject.Find("Main Camera");

        RotateBase = GameObject.Find("PlanetPosition");
        planet = GameObject.Find("PlanetPosition/death_planet");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        oldPos = new Vector2(eventData.position.x,eventData.position.y);
        Debug.Log("OnBeginDrag");
        csScreenPointTouch script = obj.GetComponent<csScreenPointTouch>();
        script.dragTrue();
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        newPos = new Vector2(eventData.position.x, eventData.position.y);

        delPos = new Vector2(eventData.delta.x, eventData.delta.y);
        Debug.Log(delPos);
        RotateBase.transform.Rotate(new Vector3(eventData.delta.y, -eventData.delta.x,0 ));

        //GameObject obj = GameObject.Find("PlanetPosition/death_planet");
        //obj.transform.Rotate(new Vector3(eventData.delta.y , 0, -eventData.delta.x ));
        //Quaternion.w
        ////obj.transform.Rotate(new Vector3((newPos.y - oldPos.y) / dragRate, 0, -(newPos.x - oldPos.x) / dragRate));
        //obj.transform.Rotate(RotateBase.transform.localEulerAngles/dragRate);
        //obj.transform.localRotation = Quaternion.Euler(new Vector3(RotateBase.transform.eulerAngles.x/dragRate, 0, -RotateBase.transform.eulerAngles.z/dragRate));

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnDragEnd");

        //planet.gameObject.transform.rotation = RotateBase.gameObject.transform.rotation;
        calculateRotation();
        RotateBase.transform.localRotation = Quaternion.identity;
        planet.transform.Rotate(planetRotation);



        //GameObject RotateBase = GameObject.Find("RotateBase");
        //RotateBase.transform.rotation = Quaternion.identity;
        //RotateBase.transform.localRotation = Quaternion.identity;
        //RotateBase.transform.Rotate(new Vector3(0,0,0));
        //RotateBase.transform.Rotate()

        csScreenPointTouch script = obj.GetComponent<csScreenPointTouch>();

        script.dragTrue();
    }
    
    void calculateRotation()
    {
        planetRotation = RotateBase.transform.rotation.eulerAngles;
    }
}
