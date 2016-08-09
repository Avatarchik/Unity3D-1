using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class RPSScript : MonoBehaviour {

    //가위 = 1, 바위 = 2, 보 = 3
    public List<int> myRPS = new List<int>();
    public List<int> comRPS = new List<int>();
    public int round;
    public int winCount;
    public int loseCount;
    public int drawCount;

    [SerializeField]
    bool RoundState;
    [SerializeField]
    bool inputRPS;
    public int inputCnt;
    int RockCnt;
    int ScissorsCnt;
    int PaperCnt;

    void Start()
    {
        RoundState = false;
        inputRPS = true;
        inputCnt = 0;
        RockCnt = 0;
        ScissorsCnt = 0;
        PaperCnt = 0;
        
        round = 1;
        winCount = 0;
        enemyRPS();
    }

    void Update()
    {
        if(inputRPS == true && inputCnt == 5)
        {
            inputRPS = false;
        }

        
    }

    public void enemyRPS()
    {
        for(int i=0; i < 5; i++)
        {
            comRPS.Add(checkOver2(Random.Range(1, 4)));
        }

    }

    public int checkOver2(int num)
    {
        if (comRPS.Count < 2)
        {
            return num;
        }

        int cnt = 0;

        for (int i = 0; i < comRPS.Count; i++)
        {
            if (comRPS[i] == num)
            {
                cnt++;
            }
        }


        if (cnt >= 2)
        {
            return checkOver2(Random.Range(1, 4));
        }
        else
        {
            return num;
        }

    }


    public void compare()
    {
        if (round >= 5)
        {
            return;
        }
        switch (myRPS[round])
        {
            case 1:
                ScissorsCnt--;
                break;
            case 2:
                RockCnt--;
                break;
            case 3:
                PaperCnt--;
                break;
            default:
                break;
        }
        if (myRPS[round] == comRPS[round])
        {
            //비김
            drawCount++;
        }
        else if ((myRPS[round] == 1 && comRPS[round] == 2) || (myRPS[round] == 2 && comRPS[round] == 3) || (myRPS[round] == 1 && comRPS[round] == 1))
        {
            //패배
            loseCount++;
        }
        else
        {
            //승리
            winCount++;
        }
        round++;
    }

    public void inputScissors()
    {
        if (ScissorsCnt == 2)
        {
            GameObject.Find("Round").transform.FindChild("WaringText").gameObject.SetActive(true);
            StartCoroutine(warningEnd());
        }

        if (myRPS.Count <= 4 && inputRPS == true && ScissorsCnt < 2)
        {
            myRPS.Add(1);
            inputCnt++;
            ScissorsCnt++;
        }
        

        if(inputRPS == false && RoundState == true)
        {
            compare();
            ScissorsCnt--;
        }
        GameObject.Find("ScissorsCnt").gameObject.GetComponent<Text>().text = ScissorsCnt.ToString();
    }

    public void inputRock()
    {
        if (RockCnt == 2)
        {
            GameObject.Find("Round").transform.FindChild("WaringText").gameObject.SetActive(true);
            StartCoroutine(warningEnd());
        }


        if (myRPS.Count <= 4 && inputRPS == true && RockCnt < 2)
        {
            myRPS.Add(2);
            inputCnt++;
            RockCnt++;
            
        }
        if (inputRPS == false && RoundState == true)
        {
            compare();
            RockCnt--;
        }
        GameObject.Find("RockCnt").gameObject.GetComponent<Text>().text = RockCnt.ToString();
    }

    public void inputPaper()
    {
        if (PaperCnt == 2)
        {
            GameObject.Find("Round").transform.FindChild("WaringText").gameObject.SetActive(true);
            StartCoroutine(warningEnd());
        }


        if (myRPS.Count <= 4 && inputRPS == true && PaperCnt < 2)
        {
            myRPS.Add(3);
            inputCnt++;
            PaperCnt++;
        }
        if (inputRPS == false && RoundState == true)
        {
            compare();
            PaperCnt--;
        }
        GameObject.Find("PaperCnt").gameObject.GetComponent<Text>().text = PaperCnt.ToString();
    }

    public void StartRound()
    {
        if (inputRPS == false && RoundState == true)
        {
            compare();
        }
    }

    IEnumerator warningEnd()
    {
        yield return new WaitForSeconds(2.4f);
        GameObject.Find("Round").transform.FindChild("WaringText").gameObject.SetActive(false);
    }
}
