using UnityEngine;
using System.Collections;

public class FogOfWar : MonoBehaviour
{
    public int FogMaxSize;
    public GameObject Fog;
    public float Hight;


	void Start ()
	{
	    FogMaxSize *=(int)Fog.transform.localScale.x;
        for (int i = 0; i < FogMaxSize; i+=(int)Fog.transform.localScale.x)
	    {
            for (int j = 0; j < FogMaxSize; j+=(int)Fog.transform.localScale.x)
            {
                Instantiate(Fog, new Vector3(0 + i, Hight, 0 + j), Quaternion.identity);
            }
	    }	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
