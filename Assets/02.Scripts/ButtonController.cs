using UnityEngine;
using System.Collections;

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

    
}
