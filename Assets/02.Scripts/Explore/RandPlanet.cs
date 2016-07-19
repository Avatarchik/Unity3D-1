using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RandPlanet : MonoBehaviour
{
    //color) 1= blue, 2= red , 3= yellow, 4= violate, 5= green, 6 = Orange
    //size) 1= small, 2 = midium, 3= large, 4= xlarge
    //mat ) 1= 1, 2=2, 3=3

    public List<GameObject> PlanetList = new List<GameObject>();
    public List<string> randomName = new List<string>();
    public List<string> colorName = new List<string>();
    public List<string> zName = new List<string>();
    public Dictionary<int, GameObject> D_PlanetList = new Dictionary<int, GameObject>();

    int sizeP;
    int colorP;
    int matP;
    
    public int sizeT;  // Small : 1, Medium : 2, Large : 3, XLarge : 4
    public int colorT; // Blue : 1, Red : 2, Yellow : 3, Violate : 4, Green : 5, Orange : 6
    public int matT;   // 1, 2, 3

    void Awake()
    {
        int count = 0;
        for (int i = 1; i <= 6; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                for (int k = 1; k <= 3; k++)
                {
                    D_PlanetList.Add(j * 100 + i * 10 + k, PlanetList[count]);  //size * 100 + color * 10 + mat
                    count ++;
                }
            }
        }
    }
    
    public int PlanetCreate()
    {
        //Random.seed = Random.Range(1, 500);

        sizeP = Random.Range(1, 100);
        colorP = Random.Range(1, 100);

        //Size
        if (1 <= sizeP && sizeP <= 50)
        {
            sizeT = 1;
        }
        else if (51 <= sizeP && sizeP <= 80)
        {
            sizeT = 2;
        }
        else if (81 <= sizeP && sizeP <= 95)
        {
            sizeT = 3;
        }
        else if (96 <= sizeP && sizeP <= 100)
        {
            sizeT = 4;
        }
        //Color
        if (1 <= colorP && colorP <= 25)
        {
            colorT = 1;
            //mat
            matP = Random.Range(1, 25);
            if (1 <= matP && matP <= 8)
            {
                matT = 1;
            }
            else if (9 <= matP && matP <= 16)
            {
                matT = 2;
            }
            else if (17 <= matP && matP <= 25)
            {
                matT = 3;
            }
        }
        else if (26 <= colorP && colorP <= 33)
        {
            colorT = 2;
            //mat
            matP = Random.Range(1, 8);
            if (1 <= matP && matP <= 3)
            {
                matT = 1;
            }
            else if (4 <= matP && matP <= 6)
            {
                matT = 2;
            }
            else if (7 <= matP && matP <= 8)
            {
                matT = 3;
            }
        }
        else if (34 <= colorP && colorP <= 58)
        {
            colorT = 3;
            //mat
            matP = Random.Range(1, 25);
            if (1 <= matP && matP <= 8)
            {
                matT = 1;
            }
            else if (9 <= matP && matP <= 16)
            {
                matT = 2;
            }
            else if (17 <= matP && matP <= 25)
            {
                matT = 3;
            }
        }
        else if (59 <= colorP && colorP <= 66)
        {
            colorT = 4;
            //mat
            matP = Random.Range(1, 8);
            if (1 <= matP && matP <= 3)
            {
                matT = 1;
            }
            else if (4 <= matP && matP <= 6)
            {
                matT = 2;
            }
            else if (7 <= matP && matP <= 8)
            {
                matT = 3;
            }
        }
        else if (67 <= colorP && colorP <= 91)
        {
            colorT = 5;
            //mat
            matP = Random.Range(1, 25);
            if (1 <= matP && matP <= 8)
            {
                matT = 1;
            }
            else if (9 <= matP && matP <= 16)
            {
                matT = 2;
            }
            else if (17 <= matP && matP <= 25)
            {
                matT = 3;
            }
        }
        else if (92 <= colorP && colorP <= 100)
        {
            colorT = 6;
            //mat
            matP = Random.Range(1, 9);
            if (1 <= matP && matP <= 3)
            {
                matT = 1;
            }
            else if (4 <= matP && matP <= 6)
            {
                matT = 2;
            }
            else if (7 <= matP && matP <= 9)
            {
                matT = 3;
            }
        }

        Debug.Log(sizeT * 100 + colorT * 10 + matT);
        return sizeT * 100 + colorT * 10 + matT;
    }
    public string PlanetNameCreate()
    {
        string createName = " ";
        string sName;
        string cName;
        string dName;
        // 행성 이름 생성 <형용사(사이즈별)> + <행성 색깔> + <별자리이름> 조합
        // 1: aquarius, 2: Pisces, 3: Aries, 4: Taurus, 5: Gemini, 6: Cancer, 7:, Leo, 8: Virgo, 9: Libra 10: Scorpius, 11: Sagittarius, 12: Capricornus
        /*
        S       M       L       XL
        화사한	상냥한	청아한	유별난
        명랑한	특이한	따뜻한	화려한
        유쾌한	친숙한	현명한	근엄한
        행복한	멋진	조용한	진실한
        의연한	늠름한	젊잖은	고상한
        깨끗한	무심한	황홀한	육중한
       재미있는 고고한	겸손한	자상한
        친근한	적절한	침착한	
        건방진	한가한	푸짐한	
        해맑은	포근한		
        발랄한	생생한		
        즐거운	절묘한		
        짜릿한	기발한		
        잘생긴	찬란한		
        다부진	치밀한		
        착한	해박한		
        초연한			
        정겨운			
        기쁜			
        귀여운			
        단호한			
        */
        List<string> sizeSmall = randomName.GetRange(0,21);
        List<string> sizeMedium = randomName.GetRange(22, 16);
        List<string> sizeLarge = randomName.GetRange(39, 9);
        List<string> sizeXLarge = randomName.GetRange(49, 7);
        switch (sizeT)
        {
            case 1:

                sName = GameManager.Instance().PlanetName = sizeSmall[Random.Range(0, 21)];
                createName = sName;
                break;
            case 2:
                sName = GameManager.Instance().PlanetName = sizeMedium[Random.Range(0, 16)];
                createName = sName;
                break;
            case 3:
                sName = GameManager.Instance().PlanetName = sizeLarge[Random.Range(0, 9)];
                createName = sName;
                break;
            case 4:
                sName = GameManager.Instance().PlanetName = sizeXLarge[Random.Range(0, 7)];
                createName = sName;
                break;
        }
        switch(colorT)
        {
            case 1:
                cName = colorName[0];
                createName +=" "+ cName;
                break;
            case 2:
                cName = colorName[1];
                createName += " " + cName;
                break;
            case 3:
                cName = colorName[2];
                createName += " " + cName;
                break;
            case 4:
                cName = colorName[3];
                createName += " " + cName;
                break;
            case 5:
                cName = colorName[4];
                createName += " " + cName;
                break;
            case 6:
                cName = colorName[5];
                createName += " " + cName;
                break;
        }
        return createName;
    }
    
}
