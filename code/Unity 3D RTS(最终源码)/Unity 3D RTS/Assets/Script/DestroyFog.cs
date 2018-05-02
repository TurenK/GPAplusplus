using UnityEngine;
using System.Collections;

public class DestroyFog : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Friendlyforce" || other.gameObject.tag == "Bullet" || other.gameObject.tag == "EmenyBullet")
        {

        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
