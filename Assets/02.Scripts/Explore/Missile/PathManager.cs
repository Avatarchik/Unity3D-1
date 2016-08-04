using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Hashtable hash = new Hashtable();

            hash.Add("path", iTweenPath.GetPath("Path1"));
            hash.Add("movetopath", true);
            hash.Add("orienttopath", true);
            hash.Add("looktime", 0.5f);
            hash.Add("speed", 30.0f);
            hash.Add("easetype", iTween.EaseType.linear);
            hash.Add("looptype", iTween.LoopType.loop);

            //hash.Add("onstart", "ItweenStart");
            //hash.Add("onstarttarget", gameObject);

            //hash.Add("onupdate", "ItweenUpdate");
            //hash.Add("onupdatetarget", gameObject);

            //hash.Add("oncomplete", "ItweenComplete");
            //hash.Add("oncompletetarget", gameObject);

            iTween.MoveTo(gameObject, hash);
        }

    }

    //void ItweenStart()
    //{
    //    Debug.Log("Tween Start : " + Time.realtimeSinceStartup);
    //}

    //void ItweenUpdate()
    //{
    //    Debug.Log("Tween Update : " + Time.realtimeSinceStartup);
    //}

    //void ItweenComplete()
    //{
    //    Debug.Log("Tween Complete : " + Time.realtimeSinceStartup);
    //}
}
