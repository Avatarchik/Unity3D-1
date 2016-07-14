using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FusionScript : MonoBehaviour {

    public GameObject TextPENum;
    public GameObject TextOENum;
    public GameObject TextGENum;
    public GameObject TextVENum;
    public GameObject TextRENum;
    public GameObject TextYENum;
    public GameObject TextBENum;

    public GameObject SingleTon;


    public void setText()
    {
        TextPENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cPE + "";
        TextOENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cRE + "";
        TextGENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cGE + "";
        TextVENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cVE + "";
        TextRENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cRE + "";
        TextYENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cYE + "";
        TextBENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cBE + "";
    }



}
