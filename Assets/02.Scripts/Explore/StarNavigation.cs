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
        GameObject.Find("PlayerController_ui").SetActive(true);
     
        maxFuel = GameData.Instance().maxFuel;
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

        GameManager.Instance().spentFuel = (int)deltaFuelTime;
        

        if (deltaFuelTime < maxFuel && engineActive == true)
        {
            //Debug.Log(deltaFuelTime);
            
            fuelGauge.value = deltaFuelTime / maxFuel;
        }

        else if (deltaFuelTime > maxFuel && engineActive == true)
        {
            spentFuel();
            GameManager.Instance().player.GetComponent<SpaceshipController>().m_spaceship.SpeedRange -= new Vector2(17, 0);
            GameManager.Instance().alertUi.SetActive(true);
            GameObject.Find("PlayerController_ui").SetActive(false);
            GameManager.Instance().alertUi.GetComponentInChildren<Image>().CrossFadeAlpha(-1,5.0f,false);
            GameObject.Find("ParticleFollow").SetActive(false);
            engineActive = false;
            StartCoroutine(returnMain());
            Debug.Log("<b>연료 부족!</b>");
            
        }

        //목적지 네비게이션
        
        if (GameData.Instance().navOn == true)
        {
            Vector3 pPoint = GameManager.Instance().player.transform.position;
            Vector3 dPoint = GameData.Instance().starPosition;
            GameObject.Find("Nav").GetComponent<LineRenderer>().SetPosition(0, pPoint);        //플레이어 현재 위치
            GameObject.Find("Nav").GetComponent<LineRenderer>().SetPosition(1, dPoint);        //목적지 위치
        }
        else
        {
            GameObject.Find("Nav").GetComponent<LineRenderer>().enabled = false;
        }

    }
    public void spentFuel()     //PlanetManage, StarNavigation, ButtonController(TransSceneToMain)에서 씬전환시 호출함
    {
        SelectDB.Instance().table = "userTable";
        SelectDB.Instance().column = "cFood, shipNum";
        SelectDB.Instance().where = " ";
        SelectDB.Instance().Select(2);

        SelectDB.Instance().food = SelectDB.Instance().food - GameManager.Instance().spentFuel;

        UpdateDB.Instance().table = "userTable";
        UpdateDB.Instance().setColumn = "\"cFood\" = " + SelectDB.Instance().food.ToString();
        UpdateDB.Instance().where = " ";
        UpdateDB.Instance().UpdateData();
    }
    IEnumerator returnMain()
    {
        SoundManager.Instance().PlaySfx(SoundManager.Instance().endExplore);
        yield return new WaitForSeconds(5.0f);
        SoundManager.Instance().bgmType = 1;
        GameObject.Find("GameManager").gameObject.GetComponent<ButtonController>().TransSceneToMain();
    }
}
