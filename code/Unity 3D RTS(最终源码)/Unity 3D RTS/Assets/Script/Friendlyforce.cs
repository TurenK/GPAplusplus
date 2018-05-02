using System;
using UnityEngine;
using System.Collections;

public class Friendlyforce : MonoBehaviour
{
    public bool IsSelect=false;
    private ScreenDraw screenDraw;
    private int laymask;
    public float HP=1;
    public float AttackDistance=10;
    public bool StartAttack=false;
    public bool IsAttack = false;
    public float ATK;
    public GameObject bullet;
    private Transform bulletPosition;
    public GameObject Target;
    private float InAttackInterval;
    public float AttackInterval=2;
    private int laymasks;
    public GameObject Hps;
    public GameObject BeSelectTexture;
	void Start ()
	{
        GameObject child = Instantiate(Hps) as GameObject;
        child.transform.parent = this.transform;
	    BeSelectTexture = this.transform.Find("Select").gameObject;
        laymasks = LayerMask.GetMask("Terrain");
	    screenDraw = GameObject.Find("Main Camera").GetComponent<ScreenDraw>();
        screenDraw.Friendlyforcess.Add(this.gameObject);
        laymask = LayerMask.GetMask("Friendlyforce");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="EmenyBullet")
        {
            TakeDamage(other.GetComponent<Bullet>().ATK);
            Destroy(other.gameObject);
        }
    }

    public void Attack()
    {
        if (StartAttack&&InAttackInterval<=0&&Target!=null)
        {
            bulletPosition = this.transform.Find("BulletPosition").GetComponent<Transform>();
            GameObject child = Instantiate(bullet, bulletPosition.position, Quaternion.identity) as GameObject;
            child.transform.parent = this.transform;         
            InAttackInterval = AttackInterval;
        }        
    }

    public void TakeDamage(float Damage)
    {
        HP -= Damage;
    }

	void Update ()
	{
        if (IsSelect)
        {
            BeSelectTexture.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            BeSelectTexture.GetComponent<MeshRenderer>().enabled = false;
        }
	    Beselect();
        Dead();
	    SelectEmeny();
	    Attack();
	    if (InAttackInterval>=0)
	    {
	        InAttackInterval -= Time.deltaTime;
	    }
	}

    private void Dead()
    {
        if (HP<=0)
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
                       hit.collider.gameObject.GetComponent<Friendlyforce>().IsSelect = true;
                   }
                   catch
                   {
                   }
               }            
            }
        }      
    }

    private void SelectEmeny()
    {
        Ray rays = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hits;
        if (Physics.Raycast(rays, out hits,Mathf.Infinity,laymasks))
        {
            if (Input.GetMouseButton(1))
            {
               if (hits.collider.gameObject.tag != "Emeny")
                {
                    if (Target != null)
                    {
                        try
                        {
                            Target.GetComponent<Emeny>().IsSelect = false;
                        }
                        catch
                        {
                            Target.GetComponent<Base>().IsSelect = false;
                        }                   
                    }                
                    Target = null;
                }
                if (hits.collider.gameObject.tag == "Emeny" && IsSelect == true)
                {
                    Target = hits.collider.gameObject;
                    try
                    {
                        Target.GetComponent<Emeny>().IsSelect = true;
                    }
                    catch
                    {
                        Target.GetComponent<Base>().IsSelect = true;
                    }                   
                }          
            }            
        }
    }
}
