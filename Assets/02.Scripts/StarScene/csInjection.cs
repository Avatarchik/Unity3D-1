using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class csInjection : MonoBehaviour {

    Text PEText;
    Text MaxText;
    Slider slider;


    int minimum;
    int maximun;
    int nowE;

    
    void Start()
    {
        PEText = GameObject.Find("Canvas/injectionPanal/Image/Slider/NowE").GetComponent<Text>();
        slider = GameObject.Find("Canvas/injectionPanal/Image/Slider").GetComponent<Slider>();
        MaxText = GameObject.Find("Canvas/injectionPanal/Image/Slider/MAX").GetComponent<Text>();


        minimum = 0;
        nowE = 0;

        setMaximunPE();


    }

    void setMaximunPE()
    {
        //잔존량 > 유저보유량 -> max = 유저량
        //잔존량<= 유저보유량 -> max = 보유량



        maximun = 50000;
        slider.GetComponent<Slider>().maxValue = maximun;
        MaxText.text = slider.GetComponent<Slider>().maxValue + "";

    }

    public void ChangeSliderValue()
    {
        float val = slider.value;

        UpdateText((int)val);
        

    }

    public void UpdateText(int cnt)
    {
        PEText.text = cnt + "";
    }
}

