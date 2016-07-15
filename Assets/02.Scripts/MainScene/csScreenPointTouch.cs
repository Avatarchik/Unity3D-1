using UnityEngine;
using System.Collections;

public class csScreenPointTouch : MonoBehaviour
{

    public LayerMask ignoreUI;

    public static bool rDrag;

    void Start()
    {
        rDrag = false;
    }

    public void dragTrue()
    {
        Debug.Log("dragTrue");
        rDrag = true;
    }

    public void dragFalse()
    {
        Debug.Log("dragFalse");
        rDrag = false;
    }
    void Update()
    {
        if (rDrag == false)
        {
            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.tag.Equals("Finish"))
                    {
                        Debug.Log("panal");
                    }

                    if (hit.transform.tag.Equals("Food"))
                    {
                        Debug.Log("ray hit food");
                    }

                    if (hit.transform.tag.Equals("Titanium"))
                    {
                        Debug.Log("ray hit titanium");
                    }

                    if (hit.transform.tag.Equals("Ship"))
                    {
                        GameObject.Find("UIManager").gameObject.GetComponent<ButtonController>().TransSceneToMap();
                    }
                    if (hit.transform.tag.Equals("Energy"))
                    {
                        Debug.Log("Ray hit Energy");
                    }

                }
            }
        }
        rDrag = false;

    }
}

