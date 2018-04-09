using System;
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    private Slider thiSlider;
   public GameObject g;
   public Camera ACamera;
   private Vector2 p;
   private Vector2 s;
   public Canvas canvas;
   RectTransform rectTransform;
    private float MaxHP;
    private Image sdl;
	void Start ()
	{
	    sdl = this.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>();
	    thiSlider = this.gameObject.GetComponent<Slider>();
	    g = this.transform.parent.GetComponent<Transform>().gameObject;
	    if (g.gameObject.tag=="Emeny")
	    {
            if (g.gameObject.name == "EnemyBase")
            {
                MaxHP = g.GetComponent<Base>().HP;            
            }
            else
            {
                MaxHP = g.GetComponent<Emeny>().HP;           
            }
	    }
	    else
	    {
	        try
	        {
	            if (g.gameObject.name == "Base")
	            {
	                MaxHP = g.GetComponent<Base>().HP;
	            }
	            else
	            {
	                MaxHP = g.GetComponent<Friendlyforce>().HP;
	            }
	        }
	        catch 
	        {
                MaxHP = g.GetComponent<FriendlyforcesBuild>().HP;
	        }	        
	    }
	    this.transform.parent = GameObject.Find("Canvas").transform;
	    ACamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	    canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rectTransform = transform as RectTransform;
	}
	
	void Update ()
	{
	    if (g!=null)
	    {
            if (g.gameObject.tag == "Emeny")
            {
                if (g.gameObject.name == "EnemyBase")
                {
                    thiSlider.value = g.GetComponent<Base>().HP / MaxHP;
                    if (g.GetComponent<Base>().IsSelect)
                    {
                        sdl.enabled = true;
                    }
                    else
                    {
                        sdl.enabled = false;
                    }
                }
                else
                {
                    thiSlider.value = g.GetComponent<Emeny>().HP / MaxHP;
                    if (g.GetComponent<Emeny>().IsSelect)
                    {
                        sdl.enabled = true;
                    }
                    else
                    {
                        sdl.enabled = false;
                    }
                }
            }
            else
            {
                try
                {
                    if (g.gameObject.name == "Base")
                    {
                        thiSlider.value = g.GetComponent<Base>().HP / MaxHP;
                        if (g.GetComponent<Base>().IsSelect)
                        {
                            sdl.enabled = true;
                        }
                        else
                        {
                            sdl.enabled = false;
                        }
                    }
                    else
                    {
                        thiSlider.value = g.GetComponent<Friendlyforce>().HP / MaxHP;
                        if (g.GetComponent<Friendlyforce>().IsSelect)
                        {
                            sdl.enabled = true;
                        }
                        else
                        {
                            sdl.enabled = false;
                        }
                    }
                }
                catch
                {
                    thiSlider.value = g.GetComponent<FriendlyforcesBuild>().HP;
                    if (g.GetComponent<FriendlyforcesBuild>().IsSelect)
                    {
                        sdl.enabled = true;
                    }
                    else
                    {
                        sdl.enabled = false;
                    }
                }
            }    
	    }
            	    	           
	    try
	    {
	        p = ACamera.WorldToScreenPoint(g.transform.Find("HPPosition").GetComponent<Transform>().position);
	        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, p,
	            canvas.worldCamera, out s))
	        {
	            rectTransform.anchoredPosition = s;
	        }
	    }
	    catch
	    {
	    }
	    if (g==null)
	    {
	        Destroy(this.gameObject);
	    }
	}
}
