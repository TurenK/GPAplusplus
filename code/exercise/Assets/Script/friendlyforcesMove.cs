using UnityEngine;
using System.Collections;

public class friendlyforcesMove : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMesh;
    private int laymask;
    private bool Isselect;
    private Friendlyforce friendlyforce;
    private float Brontime=1.5f;
    private bool Bron=false;  

	void Start ()
	{	   
	    friendlyforce = this.GetComponent<Friendlyforce>();
	    Bron = true;
	    laymask = LayerMask.GetMask("Terrain");
	    navMesh = this.GetComponent<UnityEngine.AI.NavMeshAgent>();	   
	}
	
	void Update ()
	{
	    if (Bron)
	    {
	        Brontime -= Time.deltaTime;
            this.transform.Translate(this.transform.forward*8*Time.deltaTime,Space.World);
	        if (Brontime<=0)
	        {
	            Bron = false;
	        }
	    }
        Isselect = this.GetComponent<Friendlyforce>().IsSelect;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit,Mathf.Infinity,laymask))
        {
          if(Isselect == true)
          {
            if (Input.GetMouseButton(1)&&friendlyforce.Target == null)
            {
                    friendlyforce.StartAttack = false;
                    navMesh.SetDestination(Hit.point);                           
            }           
              if (friendlyforce.Target!=null)
              {
                  if (Vector3.Distance(this.transform.position,friendlyforce.Target.transform.position)>friendlyforce.AttackDistance)
                  {
                      friendlyforce.StartAttack = false;
                      navMesh.SetDestination(friendlyforce.Target.transform.position);         
                  }
                 else
                  {
                      friendlyforce.StartAttack = true;
                      navMesh.SetDestination(this.transform.position);      
                  }           
              }
         }                    
        }    
	}
}
