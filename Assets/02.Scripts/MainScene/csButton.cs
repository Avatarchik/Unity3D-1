using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class csButton : MonoBehaviour {



    public void TransSceneToShop()
    {
        //SceneManager.LoadScene("asdf");
        Debug.Log("scene Trans to shop");
    }


    public void TransSceneToBook()
    {
        //SceneManager.LoadScene("Book");
        Debug.Log("scne trans to Book");
    }

    public void TransSceneToMap()
    {
        //SceneManager.LoadScene("Map");
        Debug.Log("scene trans to map");
    }

    public void VisibleSetting()
    {
        GameObject.Find("Canvas").transform.FindChild("SettingPanal").gameObject.SetActive(true);
    }


    public void Confirm()
    {
        Debug.Log("confirm");
        GameObject.Find("Canvas/SettingPanal").gameObject.SetActive(false);
    }
    public void Cancel()
    {
        Debug.Log("Cancel");
        GameObject.Find("Canvas/SettingPanal").gameObject.SetActive(false);

    }

}
