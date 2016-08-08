using UnityEngine;
using System.Collections;

public class DefenseButton : MonoBehaviour {

    bool initDef;
    bool initRet;

    void Start()
    {
        initDef = false;
        initRet = false;
    }

    void Update()
    {
        if (initRet == false && gameObject.name == "Return")
        {
            initRet = true;
            Hashtable hash = new Hashtable();
            hash.Add("x", 183);
            //hash.Add("looktime", 1.0f);
            hash.Add("time", 1.0f);
            hash.Add("name", "return");
            //hash.Add("easetype", iTween.EaseType.easeInOutExpo);

            iTween.MoveBy(gameObject.transform.FindChild("home").gameObject, hash);
        }
        if (GameObject.Find("PlanetManager").GetComponent<PlanetManager>().attackStat == true && initDef == false && gameObject.name == "Defense")
        {
            initDef = true;
            Hashtable hash = new Hashtable();
            hash.Add("x", 183);
            //hash.Add("looktime", 1.0f);
            hash.Add("time", 1.0f);
            hash.Add("name", "defense");
            //hash.Add("easetype", iTween.EaseType.easeInOutExpo);

            iTween.MoveBy(gameObject.transform.FindChild("Def").gameObject, hash);
        }
    }
}
