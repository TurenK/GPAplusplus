using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour
{
    public bool IsBarracks=false;
    public bool IsSelectBuild=false;
    public List<GameObject> Builded;
    private bool IsInstantiate=false;
    private GameObject BuildingObject;
    public GameObject Barracks;
    private int laymask;
	void Start () 
    {
        laymask = LayerMask.GetMask("Terrain");
	}

    public void OnClickBuildBarracks()
   {
       IsInstantiate = true;    
       BuildingObject = Barracks;
   }

    public void BarracksInstantiateProduct()
    {
        for (int i = 0; i < Builded.Count; i++)
        {
            try
            {
                if (Builded[i].GetComponent<FriendlyforcesBuild>().BulidTag == "Barracks(Clone)")
                {
                    Builded[i].GetComponent<FriendlyforcesBuild>().InstantiateProduct();
                    break;
                }             
            }
            catch 
            {               
                
            }
        }       
    }

    void Update () 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (IsInstantiate == true)
        {          
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, laymask))
            {
                if (hit.collider.gameObject.tag == "Terrain")
                {
                    if (IsSelectBuild == false)
                    Instantiate(BuildingObject, new Vector3(hit.point.x, Terrain.activeTerrain.SampleHeight(hit.point) + (this.transform.localScale.y / 2), hit.point.z), Quaternion.identity);
                    IsSelectBuild = true;
                    IsInstantiate = false;
                }
            }        
        }      
	}
}
