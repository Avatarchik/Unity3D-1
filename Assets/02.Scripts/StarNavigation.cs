using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StarNavigation : MonoBehaviour {

    float deltaFuelTime = 0.0f;
    public float maxFuel;
    bool engineActive;

    Slider fuelGauge;
    bool navCount = false;
    
    void Start()
    {
        fuelGauge = GameObject.Find("FuelGauge").GetComponent<Slider>();
        maxFuel = 20;   // 우주선 업그레이드시 연료 값 변경되는 코드는 추가 예정
        engineActive = true;
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

        //연료 표시계
        deltaFuelTime += Time.deltaTime;
        if (deltaFuelTime < maxFuel && engineActive == true)
        {
            //Debug.Log(deltaFuelTime);
            fuelGauge.value = deltaFuelTime / maxFuel;
        }

        else if (deltaFuelTime > maxFuel && engineActive == true)
        {
            //GameManager.Instance().player.GetComponent<SpaceshipController>().
            engineActive = false;
            Debug.Log("<b>연료 부족!</b>");
            //Time.timeScale = 0;
            //탐사 종료(행성 귀환) 추가예정
        }
        

        //목적지 네비게이션
        Vector3 pPoint = GameManager.Instance().player.transform.position;
        Vector3 dPoint = GameManager.Instance().destination.transform.position;
        GameObject.Find("Nav").GetComponent<LineRenderer>().SetPosition(0, pPoint);        //플레이어 현재 위치
        GameObject.Find("Nav").GetComponent<LineRenderer>().SetPosition(1, dPoint);        //목적지 위치

    }

}
