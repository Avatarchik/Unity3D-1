using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class wmScreenPointTouch : MonoBehaviour
{

    void Update()
    {
        if (WorldMapManager.Instance().dragState == false)
        {
            if (Input.GetButtonUp("Fire1"))                                     // Debug Mode
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // Debug Mode
                RaycastHit hit;                                                 // Debug Mode

                //foreach (Touch touch in Input.touches)                        // Build Mode
                //{
                //    Ray ray = Camera.main.ScreenPointToRay(touch.position);   // Build Mode
                //    RaycastHit hit;                                           // Build Mode

                if (Physics.Raycast(ray, out hit))
                {
                    if (WorldMapManager.Instance().dragState == false)
                    {
                        if (hit.transform.tag.Equals("Stars"))
                        {

                            SelectDB.Instance().column = "locationX,locationY,locationZ";
                            SelectDB.Instance().table = "zodiacTable";
                            SelectDB.Instance().where = "WHERE zID= " + "'" + hit.transform.name + "'";
                            SelectDB.Instance().Select(1);
                            GameData.Instance().starPosition = SelectDB.Instance().starPosition;

                            WorldMapManager.Instance().Touch.SetActive(false);
                            WorldMapManager.Instance().Destination_ui.SetActive(true);
                            WorldMapManager.Instance().Destination_ui.GetComponentInChildren<Text>().text = hit.transform.name;
                        }
                        //else
                        //{
                        //    WorldMapManager.Instance().Touch.SetActive(false);
                        //    WorldMapManager.Instance().Destination_ui.SetActive(true);
                        //    WorldMapManager.Instance().Destination_ui.GetComponentInChildren<Text>().text = hit.transform.name;
                        //}
                    }
                }
                //}                                                             // Build Mode
            }                                                                   // Debug Mode
        }
        WorldMapManager.Instance().dragState = false;
    }
}
