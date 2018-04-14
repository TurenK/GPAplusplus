using UnityEngine;
using System.Collections;

public class Barracks : MonoBehaviour
{
    private Building building;
	void Start ()
	{
	    building = GameObject.Find("BuildManager").GetComponent<Building>();
	    building.IsBarracks = true;
	}


	
	void Update ()
	{
	    Dead();
	}

    private void Dead()
    {
        if (GetComponent<FriendlyforcesBuild>().HP<=0)
        {
            building.IsBarracks = false;
            Destroy(this.gameObject);
        }      
    }
}
