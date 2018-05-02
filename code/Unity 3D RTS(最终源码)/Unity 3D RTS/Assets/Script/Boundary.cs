using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Bullet"||other.tag=="EmenyBullet")
        {
         Destroy(other.gameObject);
        }
    }
}
