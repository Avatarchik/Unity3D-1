using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {


    //씬 전환 기능
    public void TransSceneToMain()
    {
        SceneManager.LoadScene("Main");
        Destroy(GameObject.Find("GameData").gameObject);
        Debug.Log("scene Trans to Main");
    }

    public void TransSceneToShop()
    {
        GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = false;
        GameObject.Find("UI").transform.FindChild("StorePanal").gameObject.SetActive(true);
        GameObject.Find("UI/Main/Button/SettingBtn").gameObject.SetActive(false);
        GameObject.Find("GameManager/UIManager").GetComponent<StoreScript>().activeBuildingPanal();
        //Debug.Log("scene Trans to shop");
    }


    public void TransSceneToBook()
    {
        //SceneManager.LoadScene("Book");
        DontDestroyOnLoad(GameObject.Find("GameData").gameObject);
        Debug.Log("scne trans to Book");
    }

    //우주선 터치하여 월드맵으로 전환할때 (내비게이션 기능 활성화)
    public void TransSceneToMap()
    {
        SceneManager.LoadScene("WorldMap");
        DontDestroyOnLoad(GameObject.Find("GameData").gameObject);
        Debug.Log("scene trans to WorldMap");
    }

    // 행성관리 화면에서 전체맵 버튼으로 월드맵 전환할때 (내비게이션 기능 비활성화)
    public void TransSceneToWorldMap()
    {
        //내비게이션 비활성화 조건 추가필요 
        SceneManager.LoadScene("WorldMap");
        Debug.Log("scene Trans to WorldMap");
    }
    public void TransSceneToManage()
    {
        SceneManager.LoadScene("ManagePlanet");

    }

    public void TransSceneToExplore()
    {
        SceneManager.LoadScene("Explore");
        DontDestroyOnLoad(GameObject.Find("GameData").gameObject);
        Debug.Log("scene Trans to Explore");
    }


    public void VisibleSetting()
    {
        GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = false;
        GameObject.Find("UI").transform.FindChild("SettingPanal").gameObject.SetActive(true);
        GameObject.Find("UI").transform.FindChild("DragZone").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("BlockPanal").gameObject.SetActive(true);
        GameObject planet = GameObject.Find("death_planet");
        planet.gameObject.layer = 2;
    }


    public void Confirm()
    {
        Debug.Log("confirm");
        GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = true;
        GameObject.Find("UI/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("DragZone").gameObject.SetActive(true);
        GameObject.Find("UI").transform.FindChild("BlockPanal").gameObject.SetActive(false);
        GameObject planet = GameObject.Find("death_planet");
        planet.gameObject.layer = 0;

        csScreenPointTouch.rDrag = true;


    }

    public void Cancel()
    {
        Debug.Log("Cancel");
        GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = true;
        GameObject.Find("UI/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("DragZone").gameObject.SetActive(true);
        GameObject.Find("UI").transform.FindChild("BlockPanal").gameObject.SetActive(false);
        GameObject planet = GameObject.Find("death_planet");
        planet.gameObject.layer = 0;

        csScreenPointTouch.rDrag = true;


    }




    public void VisibleSettingInStar()
    {
        GameObject.Find("Canvas").transform.FindChild("SettingPanal").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("BlockPanal").gameObject.SetActive(true);
    }


    public void ConfirmInStar()
    {
        Debug.Log("confirm");
        GameObject.Find("Canvas/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("BlockPanal").gameObject.SetActive(false);

    }

    public void CancelInStar()
    {
        Debug.Log("Cancel");
        GameObject.Find("Canvas/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("BlockPanal").gameObject.SetActive(false);

    }

    public void InjectionInStar()
    {
        Debug.Log("injectionOpen");
        GameObject.Find("Canvas").transform.FindChild("injectionPanal").gameObject.SetActive(true);
        GameObject.Find("Manager/UIManager").GetComponent<csInjection>().setPanal();

        GameObject.Find("Canvas").transform.FindChild("BlockPanal").gameObject.SetActive(true);
    }

    public void InjectionConfirm()
    {
        Debug.Log("injection confirm");
        GameObject.Find("Canvas/BlockPanal").gameObject.SetActive(false);
        GameObject.Find("Canvas/injectionPanal").gameObject.SetActive(false);
    }

    public void InjectionCancel()
    {
        Debug.Log("injection cancel");
        GameObject.Find("Canvas/BlockPanal").gameObject.SetActive(false);
        GameObject.Find("Canvas/injectionPanal").gameObject.SetActive(false);

    }

    public void setVisibleFusionPanal()
    {
        GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = false;
        GameObject.Find("UI").transform.FindChild("FusionPanal").gameObject.SetActive(true);
        MainSingleTon.Instance.activeFusionPanal = true;
    }

    public void CancelInFusionPanal()
    {
        GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = true;
        GameObject.Find("UI/FusionPanal").gameObject.SetActive(false);
        MainSingleTon.Instance.activeFusionPanal = false;
    }

    public void getEnergy()
    {
        MainSingleTon.Instance.getEnergy();
    }

    public void Movebtn()
    {
        Debug.Log("이주이주");
    }
    // 메인화면

    // 탐사화면
    public void explore()
    {
        //관리중인 오브젝트 개수 체크
        //SelectDB.Instance().table = "managePlanetTable";
        //SelectDB.Instance().column = "Count(*)";
        //SelectDB.Instance().Select(0);

        //SelectDB.Instance().table = "zodiacTable";
        //SelectDB.Instance().column = "Count(*)";
        //SelectDB.Instance().where = "WHERE open = 1 AND  find = 1 AND active = 0";

        Debug.Log("행성을 탐사합니다!");
        //Vector3 spawnPoint = GameManager.Instance().planetSpawnPoint;

        //충돌한 물음표 행성 비활성화
        GameManager.Instance().tempPlanet.SetActive(false);

        //행성 생성
        Debug.Log("<b>SpawnPoint!!</b> " + GameManager.Instance().planetSpawnPoint);
        PlanetManager script = GameObject.Find("PlanetManager").GetComponent<PlanetManager>();
        script.planetChange(GameManager.Instance().planetSpawnPoint);

        //탐사 UI 비활성화
        GameManager.Instance().exploreUi.SetActive(false);

        //Scene 전환 추가예정
    }

    public void pass()
    {
        //게임 시간 초기화
        Time.timeScale = 1;

        //행성 생성하지 않음
        GameManager.Instance().tempPlanet.SetActive(false);
        //탐사 UI 비활성화
        GameManager.Instance().exploreUi.SetActive(false);
    }

    // 월드맵
    public void ReChoose()
    {
        WorldMapManager.Instance().Touch.SetActive(true);
        WorldMapManager.Instance().Destination_ui.SetActive(false);
    }

    public void useNav()
    {
        GameData.Instance().navOn = true;
        WorldMapManager.Instance().Touch.SetActive(true);
        WorldMapManager.Instance().UseNav_ui.SetActive(false);
    }
    public void noNav()
    {
        TransSceneToExplore();
    }
}
