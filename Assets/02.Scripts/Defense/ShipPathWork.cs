﻿using UnityEngine;
using System.Collections;

public class ShipPathWork : MonoBehaviour {

    bool SceneInit = true;


    void Awake()
    {
        SceneInit = false;
    }

	void Update () {
        if(SceneInit == false)
        {
            Hashtable hash = new Hashtable();

            hash.Add("path", iTweenPath.GetPath("ShipPath"));
            hash.Add("movetopath", true);
            hash.Add("orienttopath", true);
            hash.Add("looktime", 3.0f);
            hash.Add("time", 9.0f);
            hash.Add("easetype", iTween.EaseType.easeOutExpo);
            hash.Add("looptype", iTween.LoopType.none);

            //hash.Add("onstart", "ItweenStart");
            //hash.Add("onstarttarget", gameObject);

            //hash.Add("onupdate", "ItweenUpdate");
            //hash.Add("onupdatetarget", gameObject);

            hash.Add("oncomplete", "ItweenComplete");
            hash.Add("oncompletetarget", gameObject);

            iTween.MoveTo(gameObject, hash);
            SceneInit = true;
        }
    }

    void ItweenStart()
    {
        Debug.Log("Tween Start : " + Time.realtimeSinceStartup);
    }

    void ItweenUpdate()
    {
        Debug.Log("Tween Update : " + Time.realtimeSinceStartup);
    }

    void ItweenComplete()
    {
        // itween을 이용하여 엔진 점점 줄어드는것으로 수정 필요
        gameObject.transform.FindChild("Ship_" + GameData.Instance().shipNum).FindChild("Engines_" + GameData.Instance().shipNum).transform.localScale = new Vector3(1,1,0.5f);
        
        Debug.Log("Tween Complete : " + Time.realtimeSinceStartup);
    }
}
