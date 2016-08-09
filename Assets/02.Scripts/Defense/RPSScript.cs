using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class RPSScript : MonoBehaviour {

    //가위 = 1, 바위 = 2, 보 = 3
    public List<int> myRPS = new List<int>();
    public List<int> comRPS = new List<int>();
    int round;
    int winCount;


    void Start()
    {
        round = 0;
        winCount = 0;
        enemyRPS();
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
        if (comRPS.Count <= 2)
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
        if(round >= 5)
        {
            return;
        }

        if(myRPS[round] == comRPS[round])
        {
            //비김
        }
        else if((myRPS[round]==1 && comRPS[round] ==2) ||(myRPS[round] == 2 && comRPS[round]==3) || (myRPS[round]==1 && comRPS[round] == 1))
        {
            //패배
        }
        else
        {
            //승리
            winCount++;
        }
        round++;
    }


    public void inputRock()
    {
        myRPS.Add(1);
        compare();
    }

    public void inputPaper()
    {
        myRPS.Add(2);
        compare();

    }

    public void inputScissors()
    {
        myRPS.Add(3);
        compare();
    }



}
