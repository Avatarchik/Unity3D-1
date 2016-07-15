using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class FusionScript : MonoBehaviour {

    public GameObject TextPENum;
    public GameObject TextOENum;
    public GameObject TextGENum;
    public GameObject TextVENum;
    public GameObject TextRENum;
    public GameObject TextYENum;
    public GameObject TextBENum;

    public GameObject SingleTon;


    public Slider slider;
    public Text canNum;
    public Text TextMin;
    public Text TextMax;
    public Text TextMakeNum;


    public Image ImgResult;
    public Image ImgSum1;
    public Image ImgSum2;
    public Image ImgSum3;

    //public List<Image> EnergyIcon = new List<Image>();
    public List<Sprite> EnergyIcon = new List<Sprite>();


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

    void Start()
    {
        TextMakeNum.text = 0 + "";
        //setIcon(0, 0, 0,0);
        canMakeNum();
    }


    public void setIcon(int Result, int Sum1, int Sum3)
    {
        ImgResult.GetComponent<Image>().sprite = EnergyIcon[Result];
        ImgSum1.GetComponent<Image>().sprite = EnergyIcon[Sum1];
        ImgSum3.GetComponent<Image>().sprite = EnergyIcon[Sum3];
        ImgSum2.GetComponent<Image>().gameObject.SetActive(false);
        
    }

    public void setIcon(int Result, int Sum1, int Sum2, int Sum3)
    {
        ImgResult.GetComponent<Image>().sprite = EnergyIcon[Result];
        ImgSum1.GetComponent<Image>().sprite = EnergyIcon[Sum1];
        ImgSum2.GetComponent<Image>().sprite = EnergyIcon[Sum2];
        ImgSum3.GetComponent<Image>().sprite = EnergyIcon[Sum3];

    }


    public void MakePE()
    {
        Debug.Log("MPE");
    }

    public void MakeOE()
    {
        Debug.Log("MOE");
    }

    public void MakeGE()
    {
        Debug.Log("MGE");
    }

    public void MakeVE()
    {
        Debug.Log("MVE");
    }


    void canMakeNum()
    {
        //Test용도
        TextMax.text = 500 + "";
        slider.maxValue = 500;
    }



    public void ChangeSliderValue()
    {
        float val = slider.value;

        UpdateText((int)val);


    }

    public void UpdateText(int cnt)
    {
        TextMakeNum.text = cnt + "";
    }



}
