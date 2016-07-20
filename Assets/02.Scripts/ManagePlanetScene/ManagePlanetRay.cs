﻿using UnityEngine;
using System.Collections;

public class ManagePlanetRay : MonoBehaviour {

    public static bool dragging;

    void Start()
    {
        dragging = false;
    }

    void Update()
    {

        //if (Input.touchCount != 0)
        if (Input.GetButtonUp("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Rayhit");
                Debug.Log(hit.transform.name);
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag.Equals("Planet"))
                {
                    Debug.Log("Planet");
                }
            }
        }

    }

}
