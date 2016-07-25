using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {


    //씬 전환 기능
    public void TransSceneToMain()
    {
        if (GameObject.Find("GameData"))
        {
            Destroy(GameObject.Find("GameData").gameObject);
        }

        SceneManager.LoadScene("Main");
        Debug.Log("scene Trans to Main");
    }

    public void setVisibleStore()
    {
        GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = false;
        GameObject.Find("UI").transform.FindChild("StorePanal").gameObject.SetActive(true);
        GameObject.Find("UI/Main/Button/SettingBtn").gameObject.SetActive(false);
        GameObject.Find("GameManager/UIManager").GetComponent<StoreScript>().activeBuildingPanal();
        //Debug.Log("scene Trans to shop")
    }

    public void setVisibleStoreInPlanet()
    {
        GameObject.Find("UI").gameObject.GetComponent<PlanetTouchRay>().enabled = false;
        GameObject.Find("UI").transform.FindChild("StorePanal").gameObject.SetActive(true);
        GameObject.Find("UI/Main/Button/SettingBtn").gameObject.SetActive(false);
        GameObject.Find("GameManager/UIManager").GetComponent<PlanetStoreScript>().activeBuildingPanal();

    }


    public void TransSceneToBook()
    {
        //SceneManager.LoadScene("Book");
        //DontDestroyOnLoad(GameObject.Find("GameData").gameObject);
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
        DontDestroyOnLoad(GameObject.Find("WorldMapFlag"));
        Debug.Log("scene Trans to WorldMap");
    }
    public void TransSceneToManage()
    {
        if(GameObject.Find("GameManager/SqlManager") != null)
        {
            GameObject.Find("GameManager/SqlManager").GetComponent<MainSceneSQL>().dbClose();
        }else if(GameObject.Find("WorldMapFlag") != null)
        {
            Destroy(GameObject.Find("WorldMapFlag").gameObject);
        }
        SceneManager.LoadScene("ManagePlanet");
    }

    public void TransSceneToManageInStar()
    {
        if(GameObject.Find("GameManager/SqlManager") != null)
        {
            GameObject.Find("GameManager/SqlManager").GetComponent<StarSceneSql>().dbClose();
        }

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
        Debug.Log("set");
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

    public void VisibleSettingInManage()
    {
        GameObject.Find("Manager").gameObject.GetComponent<ManagePlanetRay>().enabled = false;
        GameObject.Find("UI").transform.FindChild("SettingPanal").gameObject.SetActive(true);
        GameObject.Find("UI/PlanetEx").gameObject.SetActive(false);

    }

    public void confirmInSettingAtManage()
    {
        GameObject.Find("Manager").gameObject.GetComponent<ManagePlanetRay>().enabled = true;
        GameObject.Find("UI/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("PlanetEx").gameObject.SetActive(true);

    }

    public void cancelInSettingAtmanage()
    {
        GameObject.Find("Manager").gameObject.GetComponent<ManagePlanetRay>().enabled = true;
        GameObject.Find("UI/SettingPanal").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("PlanetEx").gameObject.SetActive(true);

    }




    public void VisibleSettingInStar()
    {
        GameObject.Find("UI").transform.FindChild("SettingPanal").gameObject.SetActive(true);
    }


    public void ConfirmInStar()
    {
        Debug.Log("confirm");
        GameObject.Find("UI/SettingPanal").gameObject.SetActive(false);

    }

    public void CancelInStar()
    {
        Debug.Log("Cancel");
        GameObject.Find("UI/SettingPanal").gameObject.SetActive(false);

    }


    public void InjectionInStar()
    {
        Debug.Log("injectionOpen");
        GameObject.Find("UI").transform.FindChild("Injection_PE").gameObject.SetActive(true);
        GameObject.Find("GameManager/UIManager").GetComponent<csInjection>().setPanal();

    }

    public void setVisibleFusionPanal()
    {
        if (GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>())
        {
            GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = false;
        }

        GameObject.Find("UI").transform.FindChild("FusionPanel").gameObject.SetActive(true);

        if (GameObject.Find("GameManager").gameObject.GetComponent<MainSingleTon>())
        {
            MainSingleTon.Instance.activeFusionPanal = true;
        }
        if (GameObject.Find("GameManager").gameObject.GetComponent<StarSingleTon>())
        {
            GameObject.Find("GameManager/UIManager").gameObject.GetComponent<StarFusion>().setText();
        }

    }

    public void CancelInFusionPanal()
    {
        if (GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>())
        {
            GameObject.Find("UI").gameObject.GetComponent<csScreenPointTouch>().enabled = true;
        }

        GameObject.Find("UI/FusionPanel").gameObject.SetActive(false);

        if (GameObject.Find("GameManager").gameObject.GetComponent<MainSingleTon>())
        {
            MainSingleTon.Instance.activeFusionPanal = false;
        }
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

    public void pass(int type)
    {
        //게임 시간 초기화
        Time.timeScale = 1;

        if (type == 1)
        {
            //행성 생성하지 않음
            GameManager.Instance().tempPlanet.SetActive(false);
            //탐사 UI 비활성화
            GameManager.Instance().exploreUi.SetActive(false);
        }
        else if(type == 2)
        {
            GameManager.Instance().noMorePS.SetActive(false);
        }
    }

    // 월드맵
    public void ReChoose()
    {
        WorldMapManager.Instance().ChooseStar.SetActive(true);
        WorldMapManager.Instance().Touch.SetActive(true);
        WorldMapManager.Instance().Destination_ui.SetActive(false);
    }

    public void useNav()
    {
        GameData.Instance().navOn = true;
        WorldMapManager.Instance().ChooseStar.SetActive(true);
        WorldMapManager.Instance().Touch.SetActive(true);
        WorldMapManager.Instance().UseNav_ui.SetActive(false);
        
    }
    public void noNav()
    {
        TransSceneToExplore();
    }
}
