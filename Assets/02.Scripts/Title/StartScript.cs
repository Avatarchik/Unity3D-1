using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartScript : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Main");
        }

        if(Input.touchCount >= 1)
        {
            SceneManager.LoadScene("Main");
        }
    }


}
