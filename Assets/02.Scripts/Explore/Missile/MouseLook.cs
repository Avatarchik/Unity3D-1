using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MouseLook : MonoBehaviour
{
    public float sensitivity = 400.0f;
    public float rotationX;
    public float rotationY;
    
   

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");
        missileGameManager.Instance().lockOnStatus(false);

        GameObject.Find("Text").gameObject.GetComponent<Text>().color = Color.red;

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        if (rotationX > 50.0f)
            rotationX = 50.0f;

        if (rotationX < -50.0f)
            rotationX = -50.0f;

        //if (rotationY > 360.0f)
        //    rotationY = 360.0f;

        //if (rotationY < -360.0f)
        //    rotationY = -360.0f;

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);

        // DrawRay
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);

        //Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.Log(hit.collider.gameObject.tag);

            if(hit.collider.gameObject.tag == "Enemy") { 
                missileGameManager.Instance().lockOnStatus(true);
                GameObject.Find("Text").gameObject.GetComponent<Text>().color = Color.green;
            }
        }
        
    }
}