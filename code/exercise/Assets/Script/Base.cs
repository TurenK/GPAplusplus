using System;
using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
    public float HP=100;
    private Building building;
    public GameObject Hps;
    public bool IsSelect = false;
    private int laymask;
    public void TakeDamage(float Damage)
    {
        HP -= Damage;
    }

    void Start ()
	{
        laymask = LayerMask.GetMask("Friendlyforce");
        GameObject child = Instantiate(Hps) as GameObject;
        child.transform.parent = this.transform;
	    if (this.gameObject.tag=="Emeny")
	    {
	        return;
	    }
	    building = GameObject.Find("BuildManager").GetComponent<Building>();
        building.Builded.Add(this.gameObject);
	}
	

	void Update ()
    {
        Beselect();
	    if (HP <= 0)
	    {
            Destroy(this.gameObject);
	    }
    }

    void Beselect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, laymask))
        {
            if (hit.collider.gameObject.tag == "Friendlyforce")
            {
                if (Input.GetMouseButton(0))
                {
                    try
                    {
                        hit.collider.gameObject.GetComponent<Base>().IsSelect = true;
                    }
                    catch 
                    {
                    }                 
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag=="Emeny"&&other.gameObject.tag=="Bullet")
        {
            TakeDamage(other.GetComponent<Bullet>().ATK);
            Destroy(other.gameObject);
        }
    }
}
