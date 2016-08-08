using UnityEngine;
using System.Collections;

public class PlanetInitWork : MonoBehaviour {


    bool SceneInit = true;
	
    void Awake()
    {
        SceneInit = false;
    }

	void Update () {
       
        if(SceneInit == false)
        {
            Hashtable hash = new Hashtable();

            hash.Add("y", 36.0f);
            hash.Add("z", -6.0f);
            hash.Add("time", 6.0f);
            
            iTween.MoveTo(gameObject, hash);
            SceneInit = true;
        }
    }
}
