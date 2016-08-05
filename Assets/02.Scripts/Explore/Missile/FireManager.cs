using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject fireObject;
    public Transform firePoint;
    
    public GameObject fireEffect;
    public AudioClip clip;

    public float power = 20.0f;

    //PlayerState playerHealth = null;

    void Start()
    {
        //playerHealth = GetComponent<PlayerState>();
        fireEffect = GameObject.Find("FireEffect").gameObject;
        fireEffect.SetActive(false);
    }

    void Update()
    {
        //if (PauseScript.gamePause == true)
        //    return;
        //if (playerHealth.isDead)
        //    return;

        //Debug.Log(missileGameManager.Instance().lockOn);
        if (missileGameManager.Instance().lockOn == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //AudioManager.Instance().PlaySfx(clip);

                //GameObject particleObj = Instantiate(fireEffect) as GameObject;
                //particleObj.transform.position = firePoint.transform.position;

                GameObject obj = Instantiate(fireObject) as GameObject;

                obj.transform.position = firePoint.transform.position;
                obj.transform.rotation = firePoint.transform.rotation;
                //obj.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power;
                //obj.GetComponent<csMissile>().target = GameObject.Find("Enemy").gameObject.transform;
                //obj.GetComponent<csMissile>().target = GameObject.FindWithTag("Enemy").gameObject;

                //obj.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);

                Quaternion target = Quaternion.Euler(0.0f, cameraTransform.rotation.eulerAngles.y, 0.0f);
                obj.transform.rotation = target;

                //Debug.Log("cameraTransform : " + cameraTransform.rotation.eulerAngles.y);
                //Vector3 test = new Vector3(90.0f, cameraTransform.rotation.eulerAngles.y, 0.0f);
                fireEffect.SetActive(true);
                StartCoroutine("fireSteam");
            }
        }
        
    }

    IEnumerator fireSteam()
    {
        
        yield return new WaitForSeconds(1.5f);
        fireEffect.SetActive(false);
        
    }
}