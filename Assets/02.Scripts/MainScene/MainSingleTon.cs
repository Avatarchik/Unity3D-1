using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MainSingleTon : MonoBehaviour {

    static MainSingleTon _instance = null;

    public static MainSingleTon Instance
    {
        get
        {
            return _instance;
        }
    }
    //color) 1= blue, 2= red , 3= yellow, 4= violate, 5= green, 6 = Orange
    //size) 1= small, 2 = midium, 3= large, 4= xlarge
    //mat ) 1= 1, 2=2, 3=3
    //list입력관련 (Color)(Size)(Mat) -> 변경순서mat->size->color

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        int count = 0;
        for (int i = 1; i <= 6; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                for (int k = 1; k <= 3; k++)
                {
                    D_PlanetList.Add(i * 100 + j * 10 + k, PlanetList[count]);
                    count++;
                }
            }
        }
    }


    public int cPlanet;
    public int cFood;
    public int cTitanium;
    public int cRE;
    public int cYE;
    public int cBE;
    public int cOE;
    public int cGE;
    public int cVE;
    public int cPE;
    public int shipNum;


    public int rowid;
    public string pName;
    public int size;
    public int color;
    public int mat;
    public int mFood;
    public int mTitanium;
    public float locationX;
    public float locationY;
    public float locationZ;
    public int le_persec;
    public bool position_house;
    public int state;
    public bool user;
    public int neighbor;
    public int lFood;
    public int lTitanium;
    public string planetTouchT;
    public string titaniumTouchT;
    public string treeTouchT;
    public string breaktime;

    public int tree1;
    public int tree2;
    public int tree3;
    public int tree4;
    public int tree5;
    public int tree6;


    public GameObject UIobj;

    public bool activeFusionPanal = false;

    public bool shipTouch = false;


    public List<GameObject> PlanetList = new List<GameObject>();
    public Dictionary<int, GameObject> D_PlanetList = new Dictionary<int, GameObject>();

    public GameObject SQLManager;
    public int getCountFood;
    public int getCountTitanium;
    public int getCountEnergy;

    public int maxStoreFood;
    public int maxStoreTitanium;
    public int maxStoreEnergy;

    void Start()
    {
    }

    public void callPlanet()
    {
        int PlanetNum = color * 100 + size * 10 + mat;
        UIobj.GetComponent<MainUIfromSQL>().setPlanet(PlanetNum);

    }

    public void callShip()
    {
        UIobj.GetComponent<MainUIfromSQL>().setShip(shipNum);

    }

    public void callTree()
    {
        UIobj.GetComponent<MainUIfromSQL>().setTree(1, tree1);
        UIobj.GetComponent<MainUIfromSQL>().setTree(2, tree2);
        UIobj.GetComponent<MainUIfromSQL>().setTree(3, tree3);
        UIobj.GetComponent<MainUIfromSQL>().setTree(4, tree4);
        UIobj.GetComponent<MainUIfromSQL>().setTree(5, tree5);
        UIobj.GetComponent<MainUIfromSQL>().setTree(6, tree5);

    }


    public void callNeighber()
    {
        UIobj.GetComponent<MainUIfromSQL>().setNeighber();
    }

    public void callStation()
    {
        UIobj.GetComponent<MainUIfromSQL>().setStation();
    }

    public void setPostBox()
    {
        UIobj.GetComponent<MainUIfromSQL>().setPostBox();
    }

    public void getFood()
    {
        System.DateTime touchTime = System.DateTime.Now;
        string Query = "";
        if(treeTouchT == "0")
        {
            Query = "UPDATE managePlanetTable SET treeTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE rowid = " + rowid;
            SQLManager.GetComponent<MainSceneSQL>().UpdateQuery(Query);
            return;
        }

        System.DateTime preT = System.DateTime.ParseExact(treeTouchT, "yyyy-MM-dd HH:mm:ss", null);

        System.TimeSpan deff = touchTime - preT;
        int defTime = System.Convert.ToInt32(deff.TotalSeconds);
        int calculateFood = defTime * getCountFood;

        //이후시간, 이전시간 = 1, 같은경우 = 0, 이전,이후 = -1
        int comp = System.DateTime.Compare(touchTime, preT);

        if (comp == 1)
        {
            if(calculateFood > lFood)
            {
                if (lFood > maxStoreFood)
                {

                }
            }
            if (calculateFood > maxStoreFood)
            {
                cFood = cFood + maxStoreFood;
            }
            else
            {
                cFood = cFood + calculateFood;
            }

            treeTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");

            Query = "UPDATE userTable SET cFood = " + cFood;
            SQLManager.GetComponent<MainSceneSQL>().UpdateQuery(Query);

            Query = "UPDATE managePlanetTable SET treeTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE rowid = " + rowid;
            SQLManager.GetComponent<MainSceneSQL>().UpdateQuery(Query);

            return;
        }
        else if (comp == 0)
        {
            return;
        }
        else
        {
            treeTouchT = touchTime.ToString("yyyy-MM-dd HH:mm:ss");
            Query = "UPDATE managePlanetTable SET treeTouchT = \"" + touchTime.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE rowid = " + rowid;
            SQLManager.GetComponent<MainSceneSQL>().UpdateQuery(Query);

        }

    }

    public void getTitanium()
    {

    }

    void Update()
    {
        UIobj.GetComponent<MainUIfromSQL>().setUIText();
        if (activeFusionPanal) 
        {
            UIobj.GetComponent<FusionScript>().setText();

        }
    }
}
