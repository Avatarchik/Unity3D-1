using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class csRotatePath : MonoBehaviour {

    public List<GameObject> Pos = new List<GameObject>();

    public GameObject Planet = null;

    public void makePlanet()
    {
        Instantiate(Planet, Pos[6].transform.position, Pos[6].transform.localRotation);
    }

}
