using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class csMovePlanet : MonoBehaviour {

    List<GameObject> Pos2;
    GameObject Rot;

    int i = 0;

    GameObject dragzone;

    csDragRotation dragScript;

    GameObject parent;


    void Start()
    {
        parent = GameObject.Find("RotatePlanet");
        this.transform.parent = parent.transform;

        Rot = GameObject.Find("RotatePath");
        Pos2 = Rot.GetComponent<csRotatePath>().Pos;
        i = 7;
    }

    void Update()
    {
        float step = 10 * Time.deltaTime ;
        transform.position = Vector3.MoveTowards(this.transform.position, Pos2[i].transform.position, step);
    }

   private void setI()
    {
        i++;
        if(i >= Pos2.Count)
        {
            i = 0;
        }
        if (i == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
