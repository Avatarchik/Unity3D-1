using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public void pass()
    {
        Time.timeScale = 1;
        GameManager.Instance().exploreUi.SetActive(false);
    }
    
}
