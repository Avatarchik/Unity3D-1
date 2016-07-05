using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public void explore()
    {
        Debug.Log("행성을 탐사합니다!");
    }

    public void pass()
    {
        Time.timeScale = 1;
        GameManager.Instance().exploreUi.SetActive(false);
    }


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
        GameObject.Find("Canvas").transform.FindChild("DragZone").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("BlockPanal").gameObject.SetActive(true);
        GameObject planet = GameObject.Find("death_planet");
        planet.gameObject.layer = 2;
    }


    public void Confirm()
    {
        Debug.Log("confirm");
        GameObject.Find("Canvas/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("DragZone").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("BlockPanal").gameObject.SetActive(false);
        GameObject planet = GameObject.Find("death_planet");
        planet.gameObject.layer = 0;

    }

    public void Cancel()
    {
        Debug.Log("Cancel");
        GameObject.Find("Canvas/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("DragZone").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("BlockPanal").gameObject.SetActive(false);
        GameObject planet = GameObject.Find("death_planet");
        planet.gameObject.layer = 0;

    }

    public void TransSceneToWorldMap()
    {
        //SceneManager.LoadScene("WorldMap");
        Debug.Log("scene Trans to WorldMap");
    }

}
