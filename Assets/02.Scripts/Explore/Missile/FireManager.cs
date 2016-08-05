using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject fireObject1;
    public GameObject fireObject2;
    public Transform firePoint;
    
    public GameObject fireEffect;
    public AudioClip clip;
    GameObject obj;
    public float power = 20.0f;

    int fireCount;

    //PlayerState playerHealth = null;

    void Start()
    {
        //playerHealth = GetComponent<PlayerState>();
        fireEffect = GameObject.Find("FireEffect").gameObject;
        fireEffect.SetActive(false);
        fireCount = 0;
    }

    //void Update()
    //{
    //    //if (PauseScript.gamePause == true)
    //    //    return;
    //    //if (playerHealth.isDead)
    //    //    return;

    //    //Debug.Log(missileGameManager.Instance().lockOn);
    //    if (missileGameManager.Instance().lockOn == false)
    //    {
    //        //if (Input.GetButtonDown("Fire1"))
    //        //{
                
    //        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // Debug Mode
    //        //    RaycastHit hit;                                                 // Debug Mode
    //        //    Debug.Log(ray.ToString());
    //        //    //foreach (Touch touch in Input.touches)                        // Build Mode
    //        //    //{
    //        //    //    Ray ray = Camera.main.ScreenPointToRay(touch.position);   // Build Mode
    //        //    //    RaycastHit hit;                                           // Build Mode

    //        //    if (Physics.Raycast(ray, out hit))
    //        //    {
    //        //        Debug.Log("@@@@@");
    //        //        if (hit.transform.tag.Equals("FireArea"))
    //        //        {
    //                    //AudioManager.Instance().PlaySfx(clip);

    //                    //GameObject particleObj = Instantiate(fireEffect) as GameObject;
    //                    //particleObj.transform.position = firePoint.transform.position;

    //                    GameObject obj = Instantiate(fireObject) as GameObject;

    //                    obj.transform.position = firePoint.transform.position;
    //                    obj.transform.rotation = firePoint.transform.rotation;
    //                    //obj.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power;
    //                    //obj.GetComponent<csMissile>().target = GameObject.Find("Enemy").gameObject.transform;
    //                    obj.GetComponent<csMissile>().target = GameObject.FindWithTag("Enemy").gameObject;

    //                    //obj.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);

    //                    Quaternion target = Quaternion.Euler(0.0f, cameraTransform.rotation.eulerAngles.y, 0.0f);
    //                    obj.transform.rotation = target;

    //                    //Debug.Log("cameraTransform : " + cameraTransform.rotation.eulerAngles.y);
    //                    //Vector3 test = new Vector3(90.0f, cameraTransform.rotation.eulerAngles.y, 0.0f);
    //                    fireEffect.SetActive(true);
    //                    StartCoroutine("fireSteam");
    //        //      }
    //        //    }
    //        //    //}                                                             // Build mode
    //        //}                                                                   // Debug mode 
    //    }
        
    //}

    public void Fire()
    {
        fireCount++;
        if(fireCount%2 == 0)
        {
             obj = Instantiate(fireObject2) as GameObject;
        }
        else
        {
             obj = Instantiate(fireObject1) as GameObject;
        }
        
        
        obj.transform.position = firePoint.transform.position;
        obj.transform.rotation = firePoint.transform.rotation;
        //obj.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power;
        //obj.GetComponent<csMissile>().target = GameObject.Find("Enemy").gameObject.transform;
        obj.GetComponent<csMissile>().target = GameObject.FindWithTag("Enemy").gameObject;

        //obj.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);

        Quaternion target = Quaternion.Euler(0.0f, cameraTransform.rotation.eulerAngles.y, 0.0f);
        obj.transform.rotation = target;

        //Debug.Log("cameraTransform : " + cameraTransform.rotation.eulerAngles.y);
        //Vector3 test = new Vector3(90.0f, cameraTransform.rotation.eulerAngles.y, 0.0f);
        fireEffect.SetActive(true);
        StartCoroutine("fireSteam");
    }

    IEnumerator fireSteam()
    {
        
        yield return new WaitForSeconds(1.5f);
        fireEffect.SetActive(false);
        
    }
}