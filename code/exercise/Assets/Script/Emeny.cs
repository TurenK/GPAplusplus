using System;
using UnityEngine;
using System.Collections;

public class Emeny : MonoBehaviour
{
    public float HP=100;
    public float ATK=10;
    public float AttackDistance=20;
    private ScreenDraw screenDraw;
    public GameObject Target;
    private float InAttackInterval;
    public float AttackInterval = 2;
    public GameObject Bullet;
    public GameObject Hps;
    public bool IsSelect = false;
	void Start ()
    {
        GameObject child = Instantiate(Hps) as GameObject;
        child.transform.parent = this.transform;
        screenDraw = GameObject.Find("Main Camera").GetComponent<ScreenDraw>();
	}

    private void Dead()
    {
        if (HP<=0)
        {
            Destroy(this.gameObject);
        }
    }

    void Update ()
    {
        Dead();
	   FindTarget();
       Attack();
       if (InAttackInterval >= 0)
       {
           InAttackInterval -= Time.deltaTime;
       }
	}

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Bullet")
        {
            TakeDamage(other.GetComponent<Bullet>().ATK);
            Destroy(other.gameObject);
        }
    }
    private void TakeDamage(float Damage)
    {
        HP -= Damage;
    }

    private void Attack()
    {
        if (Target != null && InAttackInterval <0)
        {
            GameObject child = Instantiate(Bullet, this.transform.Find("BulletPosition").transform.position, Quaternion.identity)as GameObject;    
            child.transform.parent = this.transform;
            InAttackInterval = AttackInterval;
        }
    }

    private void FindTarget()
    {
        if (Target == null && screenDraw.Friendlyforcess.Count!=0)
        {
            for (int i = 0; i < screenDraw.Friendlyforcess.Count; i++)
            {
                try
                {
                    if (Vector3.Distance(this.gameObject.transform.position, screenDraw.Friendlyforcess[i].transform.position) <= AttackDistance && screenDraw.Friendlyforcess[i] != null)
                    {
                        Target = screenDraw.Friendlyforcess[i];
                        break;
                    }
                }
                catch 
                {                
                }              
            }
        }

        if (Target!=null&&Vector3.Distance(this.gameObject.transform.position, Target.transform.position)>AttackDistance)
        {
            Target = null;
        }
    }
}
