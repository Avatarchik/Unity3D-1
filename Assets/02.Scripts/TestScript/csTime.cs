using UnityEngine;
using System.Collections;

public class csTime : MonoBehaviour {


    public string touchTime;

    public System.DateTime temp = System.DateTime.Now;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            System.DateTime a = System.DateTime.Now;
            touchTime = System.DateTime.Now.ToString();
            Debug.Log(System.DateTime.Now);
            Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Debug.Log("Temp : " + temp);

            string time2 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Debug.Log(time2);
            //Debug.Log(System.Convert.ToDateTime(time2));
            //System.Convert.ToDateTime(time2);
            Debug.Log(System.DateTime.ParseExact(time2, "yyyy-MM-dd HH:mm:ss", null));
            System.DateTime temp2 = System.DateTime.ParseExact(time2, "yyyy-MM-dd HH:mm:ss", null);
            //System.Convert.ToDateTime
            System.TimeSpan diff1 = temp2 - temp;
            //Debug.Log("diff = " + diff1);
            Debug.Log(diff1);


        }
    }

}
