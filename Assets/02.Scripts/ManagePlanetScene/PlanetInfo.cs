using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PlanetInfo : MonoBehaviour {

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
    // public ??? planetTouchT
    // public ??? titaniumTouchT
    // public ??? treeTouchT
    // public ??? breaktime

    public int tree1;
    public int tree2;
    public int tree3;
    public int tree4;
    public int tree5;
    public int tree6;


    public void setVisible()
    {
        //요런식
        //this.transform.FindChild("!@#$").gameObject.SetActive(true);
    }


    public void setShip(int num)
    {
        switch (num)
        {
            case 1:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 2:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 3:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 4:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(true);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

            case 5:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(true);

                break;

            default:
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_1").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_2").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_3").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_4").gameObject.SetActive(false);
                GameObject.Find("PlanetPosition/death_planet/Ship/Ship_5").gameObject.SetActive(false);

                break;

        }

    }

    //public void setTree(int TreeCount, int TreeNum)
    //{
    //    string stringTree = "PlanetPosition/death_planet/Tree_" + TreeCount;

    //    if (GameObject.Find(stringTree) == null)
    //    {
    //        return;

    //    }
    //    switch (TreeNum)
    //    {
    //        case 0:
    //            GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);
    //            break;

    //        case 1:
    //            GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(true);
    //            GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);

    //            break;

    //        case 2:
    //            GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(true);
    //            GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);

    //            break;

    //        case 3:
    //            GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(true);
    //            GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(false);

    //            break;

    //        case 4:
    //            GameObject.Find(stringTree + "/Pinetree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Springtree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Mapletree_" + TreeCount).gameObject.SetActive(false);
    //            GameObject.Find(stringTree + "/Wintertree_" + TreeCount).gameObject.SetActive(true);

    //            break;

    //        default:
    //            break;

    //    }

    //}

    //public void setNeighber()
    //{
    //    if (MainSingleTon.Instance.neighbor == 0)
    //    {
    //        GameObject.Find("PlanetPosition/death_planet/Ship_Neighbor").gameObject.SetActive(false);
    //        GameObject.Find("PlanetPosition/death_planet/Neighbor").gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        GameObject.Find("PlanetPosition/death_planet/Ship_Neighbor").gameObject.SetActive(true);
    //        GameObject.Find("PlanetPosition/death_planet/Neighbor").gameObject.SetActive(true);

    //    }
    //}

    //public void setStation()
    //{
    //    if (MainSingleTon.Instance.position_house)
    //    {
    //        GameObject.Find("PlanetPosition/death_planet/Spacestation").gameObject.SetActive(true);
    //    }
    //    else
    //    {
    //        GameObject.Find("PlanetPosition/death_planet/Spacestation").gameObject.SetActive(false);

    //    }
    //}

    //public void setPostBox()
    //{

    //}
}
