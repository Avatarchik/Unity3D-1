using UnityEngine;
using System.Collections;

public class csRaycast : MonoBehaviour
{

    private float speed = 5.0f;

    void Update()
    {
        // 이동
        float amtMove = speed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * amtMove);

        // DrawRay
        Debug.DrawRay(transform.position, transform.forward * 8, Color.red);
        Gizmos.DrawLine(transform.position, transform.forward * 8);


        //Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 8))
        {
            Debug.Log(hit.collider.gameObject.name);
        }


    }
}
