using UnityEngine;
using System.Collections;

public class csScreenPointTouch : MonoBehaviour {


    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag.Equals("Energy"))
                {
                    Debug.Log("Ray hit Energy");
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
                    Debug.Log("ray hit ship");
                }
            }
        }
    }

}
