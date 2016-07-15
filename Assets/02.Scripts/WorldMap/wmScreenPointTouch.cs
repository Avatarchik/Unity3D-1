using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class wmScreenPointTouch : MonoBehaviour
{

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (WorldMapManager.Instance().dragState == false)
                {
                    if (hit.transform.tag.Equals("Stars"))
                    {

                        SelectDB.Instance().column = "locationX,locationY,locationZ";
                        SelectDB.Instance().table = "zodiacTable";
                        SelectDB.Instance().where = "WHERE zID= " + "'" + hit.transform.name + "'";
                        SelectDB.Instance().Select(2);
                        GameData.Instance().starPosition = SelectDB.Instance().starPosition;

                        WorldMapManager.Instance().Touch.SetActive(false);
                        WorldMapManager.Instance().Destination_ui.SetActive(true);
                        WorldMapManager.Instance().Destination_ui.GetComponentInChildren<Text>().text = hit.transform.name;
                        //csCubeRotate cubeScript = hit.transform.GetComponent<csCubeRotate>();
                        //if (cubeScript != null)
                        //{
                        //    cubeScript.RotateByHit();
                        //}
                    }
                    //else
                    //{
                    //    WorldMapManager.Instance().Touch.SetActive(false);
                    //    WorldMapManager.Instance().Destination_ui.SetActive(true);
                    //    WorldMapManager.Instance().Destination_ui.GetComponentInChildren<Text>().text = hit.transform.name;
                    //}
                }
            }
        }
    }
}
