using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManagePlanetRay : MonoBehaviour {

    public static bool dragging;

    public GameObject SQLManager;

    void Start()
    {
        dragging = false;
    }

    void Update()
    {

        //if (Input.touchCount != 0)
        if (Input.GetButtonUp("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log("Rayhit");
                Debug.Log(hit.transform.name);
                Debug.Log(hit.transform.tag);

                if(hit.transform.tag == "Stars")
                {
                    if (hit.transform.GetComponent<MoveEachPlanet>().center && hit.transform.GetComponent<StarInfo>())
                    {
                        Debug.Log("center");
                        GameObject.Find("OBJ").GetComponent<OBJScript>().rowid = hit.transform.GetComponent<StarInfo>().rowid;
                        DontDestroyOnLoad(GameObject.Find("OBJ").gameObject);

                        SQLManager.GetComponent<ManageSceneSQL>().dbClose();
                        SceneManager.LoadScene("Star");
                    }

                }

            }
        }

    }

}
