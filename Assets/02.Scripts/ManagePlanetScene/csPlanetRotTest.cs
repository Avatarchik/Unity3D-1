using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class csPlanetRotTest : MonoBehaviour {

    public List<Transform> objs = new List<Transform>();
    public List<Transform> Pos = new List<Transform>();
    public float curDrag = 0;

    int temp = 0;

    //float step;


    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    curDrag += 0.1f;
        //    MoveObj();
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    curDrag -= 0.1f;
        //    MoveObj();
        //}

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    //curDrag++;
        //    //MoveObj();
        //    float step = 10 * Time.deltaTime;
        //    objs[0].transform.position = Vector3.MoveTowards(objs[0].position, Pos[0].position, step);
        //}

            //curDrag++;
            //MoveObj();
            float step = 10 * Time.deltaTime;
            objs[0].transform.position = Vector3.MoveTowards(objs[0].position, Pos[0].position, step);
    }

    void MoveObj()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            //objs[i].localPosition = new Vector3(Mathf.Sin(curDrag + i), curDrag + i, 0);
            //objs[i].localPosition = 
            //objs[i].localPosition = Pos[i].localPosition;

            temp++;
            if (temp >= Pos.Count)
            {
                temp = 0;
            }
            objs[i].position = Pos[temp].position;
        }
    }

}
