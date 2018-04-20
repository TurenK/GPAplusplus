using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Friendlyforce"||other.gameObject.tag=="EmenyBullet")
        {
            return;
        }
            Destroy(other.gameObject);              
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
