using UnityEngine;
using System.Collections;

public class TouchFade : MonoBehaviour {


    void Start()
    {

    }

    void Update()
    {
            Hashtable hash = new Hashtable();
            hash.Add("y", -35);
            hash.Add("looktime", 1.0f);
            hash.Add("time", 5.0f);

            iTween.FadeTo(gameObject, hash);
    }
}
