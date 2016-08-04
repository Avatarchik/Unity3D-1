using UnityEngine;
using System.Collections;

public class csMove : MonoBehaviour
{

    float speed = 20.0f;
    public Transform Engine;
    bool engineCheck = false;
    bool backCnt = false;

    void Start()
    {
        Engine = GameObject.Find("AirFighter").GetComponentInChildren<Transform>().FindChild("Engine");
        Engine.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") == 1)
        {
            
            Engine.gameObject.SetActive(true);
            engineCheck = true;
        }
        else if (Input.GetAxis("Vertical") == -1)
        {
            Engine.gameObject.SetActive(true);
            engineCheck = true;

            if (backCnt == false)
            {
                Engine.gameObject.transform.Rotate(Vector3.up * 180);
                backCnt = true;
            }
            
            
        }
        else if(Input.GetAxis("Vertical") == 0)
        {
            if(engineCheck == true) { 
                Engine.gameObject.SetActive(false);
                engineCheck = false;
            }

            if (backCnt == true)
            {
                Engine.gameObject.transform.Rotate(Vector3.up * 180);
                backCnt = false;
            }
            
        }
        // 키보드 입력 Horizontal (좌,우)는 MouseLook에서 처리한다.
        //float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동 거리 보정
        //h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        // 이동
        //transform.Translate(Vector3.right * h);
        //transform.Translate(Vector3.forward * v);

        // 회전 이동
        //transform.Rotate(Vector3.up * h * 10);
        transform.Translate(Vector3.forward * v);

    }
}
