using UnityEngine;
using System.Collections;

public class DefenseButton : MonoBehaviour {

    bool init;

    void Start()
    {
        init = false;
    }

    void Update()
    {
        if (GameObject.Find("PlanetManager").GetComponent<PlanetManager>().attackStat == true && init == false)
        {
            init = true;
            Hashtable hash = new Hashtable();
            hash.Add("x", 70);
            //hash.Add("looktime", 1.0f);
            hash.Add("time", 1.0f);
            hash.Add("name", "defense");
            //hash.Add("easetype", iTween.EaseType.easeInOutExpo);

            iTween.MoveBy(gameObject.transform.FindChild("Def").gameObject, hash);
        }
    }
}
