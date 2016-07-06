using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StarNavigation : MonoBehaviour {

    
    bool navCount = false;
    
    void Start()
    {
        
    }
	void Update () {

        /*
        //목적지 설정
        //if(GameManager.Instance().navUi_des.GetComponent<Text>().text != null && navCount == false)
        //{
        //    Vector3 dPoint = GameManager.Instance().destination.transform.position;
        //    GameManager.Instance().navUi_des.GetComponent<Text>().text = "(" + dPoint.x.ToString("N1") + ", " + dPoint.y.ToString("N1") + ", " + dPoint.z.ToString("N1") + ")";
        //    navCount = true;
        //}

        //유저 현재 위치
        //Vector3 pPoint = GameManager.Instance().player.transform.position;
        //GameManager.Instance().navUi_player.GetComponent<Text>().text = "(" + pPoint.x.ToString("N1") + ", " + pPoint.y.ToString("N1") + ", " + pPoint.z.ToString("N1") + ")";

        //방향 표시계
        //transform.LookAt(GameManager.Instance().destination.transform.position);
        */

        //목적지 네비게이션
        Vector3 pPoint = GameManager.Instance().player.transform.position;
        Vector3 dPoint = GameManager.Instance().destination.transform.position;
        GameObject.Find("Ship").GetComponent<LineRenderer>().SetPosition(0, pPoint);        //플레이어 현재 위치
        GameObject.Find("Ship").GetComponent<LineRenderer>().SetPosition(1, dPoint);        //목적지 위치

    }
}
