using System;
using UnityEngine;
using System.Collections;

public class FriendlyforcesBuild : MonoBehaviour
{
    public string BulidTag ;
    public float HP=100 ;
    private ScreenDraw screenDraw;
    private Building building;
    private bool IsBuild = true;
    public bool AbleBuild= false;
    private int laymasks;
    private SphereCollider destroyFog;
    private Renderer renderer;
    Transform RespawnPosition ;
    public GameObject product;
    public GameObject Hps;
    public bool IsSelect=false;
    private int laymask;
	void Start ()
	{
         laymask = LayerMask.GetMask("Friendlyforce");
        GameObject child=Instantiate(Hps)as GameObject;
	    child.transform.parent = this.transform;
	    BulidTag = this.gameObject.name;
        destroyFog = this.GetComponentInChildren<SphereCollider>();
	    destroyFog.enabled = false;
        screenDraw = GameObject.Find("Main Camera").GetComponent<ScreenDraw>();
        laymasks = LayerMask.GetMask("Terrain");
	    renderer = this.GetComponent<Renderer>();
        building = GameObject.Find("BuildManager").GetComponent<Building>();       
    }

    public void TakeDemage(float Damage)
    {
        HP -= Damage;
    }

    private float HorizontalDistance(Vector3 a,Vector3 b)
    {  
        return Vector3.Distance(new Vector3(a.x, 0, a.z), new Vector3(b.x, 0, b.z));
    }

    public void InstantiateProduct()
    {
        RespawnPosition = this.transform.Find("RespawnPosition").GetComponent<Transform>();
        Instantiate(product,RespawnPosition.position, product.transform.rotation);
    }

    void Update ()
    {
        Beselect();
	    if (Input.GetMouseButton(0)&&AbleBuild==true&&IsBuild==true)
	    {
            building.Builded.Add(this.gameObject);
	        IsBuild = false;
            renderer.material.color = Color.gray;
	        building.IsSelectBuild = false;
	        destroyFog.enabled = true;
	        this.GetComponent<BoxCollider>().enabled = true;
	    }
	    if (IsBuild)
	    {
            if (AbleBuild == false)
            {
                renderer.material.color = Color.red;
            }
            else
            {
                renderer.material.color = Color.green;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;                      
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, laymasks))
                {
                    if (hit.collider.gameObject.tag == "Terrain")
                    {
                       transform.position=Vector3.Lerp(this.transform.position,new Vector3(hit.point.x,Terrain.activeTerrain.SampleHeight( transform.position)+(this.transform.localScale.y/2),hit.point.z),10*Time.deltaTime );
                    }
                }          
            if (screenDraw.Friendlyforcess.Count!=0)
	        {
                for (int i = 0; i < screenDraw.Friendlyforcess.Count; i++)
                {
                    if (HorizontalDistance(screenDraw.Friendlyforcess[i].transform.position, this.transform.position) < 5.5)
                    {
                        AbleBuild = false;
                        break;
                    }
                    AbleBuild = true;
                }
	        }
            else
            {
                AbleBuild = true;
            }
              
	        if (AbleBuild == true)
	        {
                for (int i = 0; i < building.Builded.Count; i++)
                {
                    if (HorizontalDistance(building.Builded[i].transform.position, this.transform.position) < 30)
                    {
                        AbleBuild = true;
                        break;
                    }
                    else
                    {
                        AbleBuild = false;
                    }
                }
	        }	      
	        if (AbleBuild==true)
	        {
                for (int i = 0; i < building.Builded.Count; i++)
                {
                    if (HorizontalDistance(building.Builded[i].transform.position, this.transform.position) < 10)
                    {
                        AbleBuild = false;
                        break;
                    }
                    else
                    {
                        AbleBuild = true;
                    }
                }
	        }      
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
                        hit.collider.gameObject.GetComponent<FriendlyforcesBuild>().IsSelect = true;
                    }
                    catch 
                    {                   
                    }                 
                }
            }
        }
    }
}
