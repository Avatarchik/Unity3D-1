using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {

    public GameObject SQLManager;

    public GameObject BuildingPanal;
    public GameObject ShipPanal;
    public GameObject CachePanal;

    public List<Sprite> shipList = new List<Sprite>();

    public GameObject lake;


    public Image ShipImage;
    public Text shipMoney;

    public Text stationBtnText;
    public Text tree1BtnText;
    public Text tree2BtnText;
    public Text tree3BtnText;
    public Text tree4BtnText;


    void Start()
    {

    }


    //버튼
    public void Exit()
    {
        GameObject.Find("UI/Main/Button").transform.FindChild("SettingBtn").gameObject.SetActive(true);
        GameObject.Find("UI/StorePanal").gameObject.SetActive(false);
    }

    public void ativeBuildingPanal()
    {
        BuildingPanal.gameObject.SetActive(true);
        ShipPanal.gameObject.SetActive(false);
        CachePanal.gameObject.SetActive(false);
    }

    public void activeShipPanal()
    {
        BuildingPanal.gameObject.SetActive(false);
        ShipPanal.gameObject.SetActive(true);
        CachePanal.gameObject.SetActive(false);
        setShipPanal();
    }

    public void activeCachePanal()
    {
        BuildingPanal.gameObject.SetActive(false);
        ShipPanal.gameObject.SetActive(false);
        CachePanal.gameObject.SetActive(true);
    }

    public void getStation()
    {
        Debug.Log("station");
    }

    public void getTree1()
    {
        Debug.Log("tree1");

    }
    
    public void getTree2()
    {
        Debug.Log("tree2");

    }

    public void getTree3()
    {
        Debug.Log("tree3");

    }

    public void getTree4()
    {
        Debug.Log("tree4");

    }

    void setBuildingPanal()
    {
        //int stationNum

    }

    public void getShip()
    {

        int nowShipNum = MainSingleTon.Instance.shipNum;
        int nowTitanium = MainSingleTon.Instance.cTitanium;
        string Query = "";


        switch (nowShipNum)
        {
            case 1:
                if(nowTitanium < 9999)
                {
                    lake.gameObject.SetActive(true);
                    lakescript.ActiveFalseTime = 0;
                }
                else
                {
                    MainSingleTon.Instance.cTitanium -= 9999;
                    MainSingleTon.Instance.shipNum++;

                    Query = "UPDATE userTableTest SET cTitanium = " + MainSingleTon.Instance.cTitanium + ", shipNum = " + MainSingleTon.Instance.shipNum;
                    Debug.Log(Query);
                    SQLManager.GetComponent<MainSceneSQL>().UpdateShip(Query);

                    setShipPanal();
                }
                break;

            case 2:
                if(nowTitanium < 12900)
                {
                    lake.gameObject.SetActive(true);
                    lakescript.ActiveFalseTime = 0;

                }
                else
                {
                    MainSingleTon.Instance.cTitanium -= 12900;
                    MainSingleTon.Instance.shipNum++;

                    Query = "UPDATE userTableTest SET cTitanium = " + MainSingleTon.Instance.cTitanium + ", shipNum = " + MainSingleTon.Instance.shipNum;
                    Debug.Log(Query);
                    SQLManager.GetComponent<MainSceneSQL>().UpdateShip(Query);

                    setShipPanal();
                }
                break;

            case 3:
                if (nowTitanium < 15900)
                {
                    lake.gameObject.SetActive(true);
                    lakescript.ActiveFalseTime = 0;

                }
                else
                {
                    MainSingleTon.Instance.cTitanium -= 15900;
                    MainSingleTon.Instance.shipNum++;

                    Query = "UPDATE userTableTest SET cTitanium = " + MainSingleTon.Instance.cTitanium + ", shipNum = " + MainSingleTon.Instance.shipNum;
                    Debug.Log(Query);
                    SQLManager.GetComponent<MainSceneSQL>().UpdateShip(Query);

                    setShipPanal();
                }
                break;

            case 4:
                if (nowTitanium < 20000)
                {
                    lake.gameObject.SetActive(true);
                    lakescript.ActiveFalseTime = 0;
                }
                else
                {
                    MainSingleTon.Instance.cTitanium -= 20000;
                    MainSingleTon.Instance.shipNum++;

                    Query = "UPDATE userTableTest SET cTitanium = " + MainSingleTon.Instance.cTitanium + ", shipNum = " + MainSingleTon.Instance.shipNum;
                    Debug.Log(Query);
                    SQLManager.GetComponent<MainSceneSQL>().UpdateShip(Query);

                    setShipPanal();

                }
                break;

            default:
                break;

        }
        

    }

    void setShipPanal()
    {
        int tempShip = MainSingleTon.Instance.shipNum;
        switch (tempShip)
        {
            case 1:
                ShipImage.sprite = shipList[0];
                shipMoney.text = "9999";

                //GameObject.Find("UI/StorePanal/ViewPanal/ShipsPanal/Panal/Image/ImgNot").gameObject.SetActive(false);
                break;

            case 2:
                ShipImage.sprite = shipList[1];
                shipMoney.text = "12900";
                //GameObject.Find("UI/StorePanal/ViewPanal/ShipsPanal/Panal/Image/ImgNot").gameObject.SetActive(false);
                break;

            case 3:
                ShipImage.sprite = shipList[2];
                shipMoney.text = "15900";
                //GameObject.Find("UI/StorePanal/ViewPanal/ShipsPanal/Panal/Image/ImgNot").gameObject.SetActive(false);
                break;

            case 4:
                ShipImage.sprite = shipList[3];
                shipMoney.text = "20000";
                //GameObject.Find("UI/StorePanal/ViewPanal/ShipsPanal/Panal/Image/ImgNot").gameObject.SetActive(false);
                break;

            case 5:
                ShipImage.sprite = shipList[4];
                shipMoney.text = "구매불가";
                //GameObject.Find("UI/StorePanal/ViewPanal/ShipsPanal/Panal/Image/ImgNot").gameObject.SetActive(true);
                break;

            default:
                shipMoney.text = "구매불가";
                //GameObject.Find("UI/StorePanal/ViewPanal/ShipsPanal/Panal/Image/ImgNot").gameObject.SetActive(true);
                break;

        }
        //if()

    }

}
