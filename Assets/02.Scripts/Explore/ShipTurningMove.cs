using UnityEngine;
using System.Collections;

public class ShipTurningMove : MonoBehaviour
{
    Vector3 rotShip;
    int rotRate;
    void Start()
    {

    }

    public void TrunShip()
    {
        rotShip = GameManager.Instance().rotShip;
        rotRate = GameManager.Instance().rotRate;

        if (rotShip == Vector3.up)
        {
            Hashtable hash = new Hashtable();
            hash.Add("y", rotShip.y * rotRate);
            hash.Add("time", 3.5f);

            iTween.RotateAdd(gameObject, hash);
        }
        else if (rotShip == Vector3.down)
        {
            Hashtable hash = new Hashtable();
            hash.Add("y", rotShip.y * rotRate);
            hash.Add("time", 3.5f);

            iTween.RotateAdd(gameObject, hash);
        }
        else if (rotShip == Vector3.left)
        {
            Hashtable hash = new Hashtable();
            hash.Add("x", rotShip.x * rotRate);
            hash.Add("time", 3.5f);

            iTween.RotateAdd(gameObject, hash);
        }
        else if (rotShip == Vector3.right)
        {
            Hashtable hash = new Hashtable();
            hash.Add("x", rotShip.x * rotRate);
            hash.Add("time", 3.5f);

            iTween.RotateAdd(gameObject, hash);
        }
    }
}
