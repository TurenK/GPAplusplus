using System;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float Speed=10;
    private GameObject Target;
    private Vector3 TargetDirection;
    public float ATK ;

	void Start ()
	{
	    try
	    {
            ATK = this.gameObject.GetComponentInParent<Friendlyforce>().ATK;
	        Target = this.gameObject.GetComponentInParent<Friendlyforce>().Target;
	    }
	    catch 
	    {
            ATK = this.gameObject.GetComponentInParent<Emeny>().ATK;
	        Target = this.gameObject.GetComponentInParent<Emeny>().Target;
	    }	   
	    this.transform.parent = null;
        TargetDirection = Target.transform.position - this.transform.position;
	}


    private void Update()
    {     
        this.transform.Translate(TargetDirection.normalized*Speed*Time.deltaTime);
    }
}
