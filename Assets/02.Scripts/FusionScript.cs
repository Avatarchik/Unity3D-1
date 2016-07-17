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
    public GameObject SQLManager;


    public GameObject SubPanal;
    public GameObject ConfirmInSub;

    public Slider slider;
    public Text canNum;
    public Text TextMin;
    public Text TextMax;
    public Text TextMakeNum;


    public Image ImgResult;
    public Image ImgSum1;
    public Image ImgSum2;
    public Image ImgSum3;

    public List<Sprite> EnergyIcon = new List<Sprite>();

    int switchEnergy = 0;

    public void setText()
    {
        TextPENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cPE + "";
        TextOENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cOE + "";
        TextGENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cGE + "";
        TextVENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cVE + "";
        TextRENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cRE + "";
        TextYENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cYE + "";
        TextBENum.GetComponent<Text>().text = SingleTon.GetComponent<MainSingleTon>().cBE + "";

    }

    void Start()
    {
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
        switchEnergy = 1;
        SubPanal.SetActive(true);
        setIcon(0, 1, 2, 3);
        canMakeNum(SingleTon.GetComponent<MainSingleTon>().cPE, SingleTon.GetComponent<MainSingleTon>().cOE, SingleTon.GetComponent<MainSingleTon>().cGE, SingleTon.GetComponent<MainSingleTon>().cVE);
    }

    public void MakeOE()
    {
        switchEnergy = 2;
        SubPanal.SetActive(true);
        setIcon(1, 4, 5);
        canMakeNum(SingleTon.GetComponent<MainSingleTon>().cOE, SingleTon.GetComponent<MainSingleTon>().cRE, SingleTon.GetComponent<MainSingleTon>().cYE);

    }

    public void MakeGE()
    {
        switchEnergy = 3;
        SubPanal.SetActive(true);
        setIcon(2, 5, 6);
        canMakeNum(SingleTon.GetComponent<MainSingleTon>().cGE, SingleTon.GetComponent<MainSingleTon>().cYE, SingleTon.GetComponent<MainSingleTon>().cBE);

    }

    public void MakeVE()
    {
        switchEnergy = 4;
        SubPanal.SetActive(true);
        setIcon(3, 4, 6);
        canMakeNum(SingleTon.GetComponent<MainSingleTon>().cVE, SingleTon.GetComponent<MainSingleTon>().cRE, SingleTon.GetComponent<MainSingleTon>().cBE);
    }

    void canMakeNum(int resutl, int sum1, int sum2, int sum3)
    {
        int min = 0;
        if (sum1 <= sum2 && sum1 <= sum3)
            min = sum1;
        if (sum2 <= sum1 && sum2 <= sum3)
            min = sum2;
        if (sum3 <= sum1 && sum3 <= sum2)
            min = sum3;
        TextMax.text = min + "";
        slider.maxValue = min;
        canNum.text = min.ToString();
    }

    void canMakeNum(int resutl, int sum1, int sum3)
    {
        int min = 0;
        if (sum1 <= sum3)
            min = sum1;
        else
            min = sum3;
        TextMax.text = min + "";
        slider.maxValue = min;
        canNum.text = min.ToString();
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



    public void ConfirmInSubPanal()
    {
        int makeNum = System.Convert.ToInt32(TextMakeNum.text);
        TextMakeNum.text = 0 + "";
        slider.value = 0;

        string Query="";

        switch (switchEnergy)
        {
            case 1: //pletinum = orange + green + violate 1:1:1
                MainSingleTon.Instance.cPE += makeNum;
                MainSingleTon.Instance.cOE -= makeNum;
                MainSingleTon.Instance.cGE -= makeNum;
                MainSingleTon.Instance.cVE -= makeNum;
                Query = "UPDATE userTableTest SET cPE = " + MainSingleTon.Instance.cPE
                    + ", cOE = " + MainSingleTon.Instance.cOE + ", cGE = " + MainSingleTon.Instance.cGE
                    + ", cVE = " + MainSingleTon.Instance.cVE + " WHERE cPE = " + (MainSingleTon.Instance.cPE - makeNum);
                break;

            case 2: // orange = red + yellow 1:1
                MainSingleTon.Instance.cOE += makeNum;
                MainSingleTon.Instance.cRE -= makeNum;
                MainSingleTon.Instance.cYE -= makeNum;
                Query = "UPDATE userTableTest SET cOE = " + MainSingleTon.Instance.cOE
                    + ", cRE = " + MainSingleTon.Instance.cRE + ", cYE = " + MainSingleTon.Instance.cYE
                    + " WHERE cOE = " + (MainSingleTon.Instance.cOE - makeNum);

                break;

            case 3: //green = ytellow + blue 1:1
                MainSingleTon.Instance.cGE += makeNum;
                MainSingleTon.Instance.cYE -= makeNum;
                MainSingleTon.Instance.cBE -= makeNum;
                Query = "UPDATE userTableTest SET cGE = " + MainSingleTon.Instance.cGE
                      + ", cYE = " + MainSingleTon.Instance.cYE + ", cBE = " + MainSingleTon.Instance.cBE
                        + " WHERE cGE = " + (MainSingleTon.Instance.cGE - makeNum);

                break;

            case 4: // violate = red + blue 1:1
                MainSingleTon.Instance.cVE += makeNum;
                MainSingleTon.Instance.cRE -= makeNum;
                MainSingleTon.Instance.cBE -= makeNum;
                Query = "UPDATE userTableTest SET cVE = " + MainSingleTon.Instance.cVE
                    + ", cRE = " + MainSingleTon.Instance.cRE + ", cBE = " + MainSingleTon.Instance.cBE
                    + " WHERE cVE = " + (MainSingleTon.Instance.cVE - makeNum);
                break;

            default:
                break;


        }


        switchEnergy = 0;
        SQLManager.GetComponent<MainSceneSQL>().UpdateEnergy(Query);
        SubPanal.SetActive(false);
        
    }
    public void CancelInSubPanal()
    {
        TextMakeNum.text = 0 + "";
        slider.value = 0;
        switchEnergy = 0;
        SubPanal.SetActive(false);

    }

}
