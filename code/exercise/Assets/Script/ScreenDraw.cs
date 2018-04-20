using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenDraw : MonoBehaviour {

    private Vector3 EndPosition;
    private Building building;
    private bool IsDraw = false;
    private Vector3 MouseStartPosition;
    private Vector3 o;
    public Material a;
    public List<GameObject> Friendlyforcess;
    public Camera camera;
    private int laymask;


    // Update is called once per frame

    private void OnPostRender()
    {
        if (IsDraw == false)
            return;
        a.SetPass(0);
        GL.PushMatrix();
        GL.LoadPixelMatrix();//设置用屏幕坐标绘图
        GL.Begin(GL.LINES);
        GL.Color(Color.white);
        GL.Vertex3(MouseStartPosition.x, MouseStartPosition.y, 0);
        GL.Vertex3(EndPosition.x, MouseStartPosition.y, 0);
        GL.Vertex3(EndPosition.x, MouseStartPosition.y, 0);
        GL.Vertex3(EndPosition.x, EndPosition.y, 0);
        GL.Vertex3(EndPosition.x, EndPosition.y, 0);
        GL.Vertex3(MouseStartPosition.x, EndPosition.y, 0);
        GL.Vertex3(MouseStartPosition.x, EndPosition.y, 0);
        GL.Vertex3(MouseStartPosition.x, MouseStartPosition.y, 0);
        GL.End();
        GL.PopMatrix();
    }

    void Start()
    {
        building = GameObject.Find("BuildManager").GetComponent<Building>();
        laymask = LayerMask.GetMask("Terrain");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Friendlyforcess.Count; i++)
        {
            if (Friendlyforcess[i]==null)
            {
                Friendlyforcess.RemoveAt(i);
            }
        }
        o = Input.mousePosition;
        EndPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            MouseStartPosition = Input.mousePosition;
            IsDraw = true;
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                IsDraw = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, laymask))
            {
                if (hit.collider.gameObject.tag == "Terrain")
                {
                    for (int y= 0; y <building.Builded.Count ; y++)
                    {
                        try
                        {
                            building.Builded[y].GetComponent<FriendlyforcesBuild>().IsSelect =false;
                        }
                        catch
                        {
                            building.Builded[y].GetComponent<Base>().IsSelect = false;
                        }
                    }
                    for (int d= 0; d< Friendlyforcess.Count; d++)
                    {
                        Friendlyforcess[d].GetComponent<Friendlyforce>().IsSelect = false;
                    }
                }
            }
        }
        if (IsDraw == true)
        {
            for (int i = 0; i < Friendlyforcess.Count; i++)
            {
                float x = camera.WorldToScreenPoint(Friendlyforcess[i].transform.position).x;
                float y = camera.WorldToScreenPoint(Friendlyforcess[i].transform.position).y;
                Vector3 p1 = Vector3.zero;
                Vector3 p2 = Vector3.zero;
                if (MouseStartPosition.x > EndPosition.x)
                {
                    p1.x = EndPosition.x;
                    p2.x = MouseStartPosition.x;
                }
                else
                {
                    p1.x = MouseStartPosition.x;
                    p2.x = EndPosition.x;
                }
                if (MouseStartPosition.y > EndPosition.y)
                {
                    p1.y = EndPosition.y;
                    p2.y = MouseStartPosition.y;
                }
                else
                {
                    p1.y = MouseStartPosition.y;
                    p2.y = EndPosition.y;
                }
                if (x < p1.x || x > p2.x || y < p1.y || y > p2.y)
                {

                }
                else
                {
                    Friendlyforcess[i].GetComponent<Friendlyforce>().IsSelect = true;
                }
            }
            if (building.Builded.Count > 0)
            {
                for (int t = 0; t < building.Builded.Count; t++)
                {
                    float x = camera.WorldToScreenPoint(building.Builded[t].transform.position).x;
                    float y = camera.WorldToScreenPoint(building.Builded[t].transform.position).y;
                    Vector3 p1 = Vector3.zero;
                    Vector3 p2 = Vector3.zero;
                    if (MouseStartPosition.x > EndPosition.x)
                    {
                        p1.x = EndPosition.x;
                        p2.x = MouseStartPosition.x;
                    }
                    else
                    {
                        p1.x = MouseStartPosition.x;
                        p2.x = EndPosition.x;
                    }
                    if (MouseStartPosition.y > EndPosition.y)
                    {
                        p1.y = EndPosition.y;
                        p2.y = MouseStartPosition.y;
                    }
                    else
                    {
                        p1.y = MouseStartPosition.y;
                        p2.y = EndPosition.y;
                    }
                    if (x < p1.x || x > p2.x || y < p1.y || y > p2.y)
                    {

                    }
                    else
                    {
                        try
                        {
                            building.Builded[t].GetComponent<FriendlyforcesBuild>().IsSelect = true;
                        }
                        catch
                        {
                            building.Builded[t].GetComponent<Base>().IsSelect = true;
                        }
                    }
                }
            }
        }
    }
}
