using UnityEngine;
using System.Collections;

public class csMissile : MonoBehaviour {

    public GameObject target;
    public GameObject explosionEffect;
    public float Speed = 0.5f;
    bool coCnt = false;

    /*
    이동 속도보다 회전 속도가 월등히 빨라야 정상적인 동작이 가능
    이 예제에서는 3번의 경우 이동 속도보다 회전 속도가 10배 정도 차이가 나면 정상 동작.
    */

	void Update () {
        MissileControl3();
	}

    void MIssileControl1()
    {
        Vector3 Dir = target.transform.position - transform.position;
        Dir.Normalize();

        Quaternion qtn = Quaternion.identity;
        qtn.SetLookRotation(Dir);

        transform.rotation = qtn;
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void MissileControl2()
    {
        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }


    void MissileControl3()
    {
        if (target != null)
        {
            // 방향 벡터 구하기
            Vector3 Dir = transform.position - target.transform.position;

            // 외적, Axis 축 구하기
            Vector3 Axis = Vector3.Cross(Dir, transform.forward);

            // Quaternion.AngleAxis(angle, Axis)
            // angle - 휘는각도 높을수록 정확도 높음
            // Axis - 축
            Quaternion NewRotation = Quaternion.AngleAxis(Time.deltaTime * 450, Axis) * transform.rotation;

            //좀 더 부드럽게 회전
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                                 NewRotation,
                                                 50.0f * Time.deltaTime);
            
        }
        else if (target == null && coCnt == false)
        {
            StartCoroutine("DestroyMissile");
            coCnt = true;
        }
        if(this.gameObject.GetComponentInChildren<Transform>().FindChild("body") != null)
        {
            // Vector3(0, 0, 1) 방향 초당 속도로
            Vector3 Pos = Vector3.forward * Time.deltaTime * 20.0f;
            transform.Translate(Pos);
        }

       

    }

        void MissileControl4()
    {
        Vector3 Dir = target.transform.position - transform.position;
        Dir.Normalize();

        Quaternion targetQtn = Quaternion.LookRotation(Dir);

        //좀 더 부드럽게 회전
        transform.rotation = Quaternion.Lerp(transform.rotation,
                                             targetQtn,
                                             1.0f * Time.deltaTime);
        Vector3 Pos = Vector3.forward * Time.deltaTime * 2.0f;
        transform.Translate(Pos);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + other.name);
        if( other.tag== "Enemy")
        {
            //missileGameManager.Instance().targetLastDir(other.gameObject.transform.position);
            GameObject particleObj = Instantiate(explosionEffect) as GameObject;
            particleObj.transform.position = other.transform.position;

            Destroy(other.gameObject);
            Destroy(this.gameObject.GetComponentInChildren<Transform>().FindChild("body").gameObject);
        }
    }

    IEnumerator DestroyMissile()
    {
        
        yield return new WaitForSeconds(2.0f);

        if (this.gameObject.GetComponentInChildren<Transform>().FindChild("body") != null)
        { 
            Destroy(this.gameObject.GetComponentInChildren<Transform>().FindChild("body").gameObject);
            GameObject particleObj = Instantiate(explosionEffect) as GameObject;
            particleObj.transform.position = this.transform.position;
            particleObj.transform.name = "missileP";
        }
        yield return new WaitForSeconds(2.0f);
        
        Destroy(this.gameObject);
        Destroy(GameObject.Find("missileP").gameObject);
    }


}
