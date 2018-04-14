using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    public Camera  a;
    public Transform Direction;
    private bool IsDown=false;
    private bool IsLeft = false;
    private bool IsRighrt = false;
    private bool IsUp = false;
    public float speed=5;
    void Update()
    {
       MoveDown();
       MoveLeft();
       MoveRight();
       MoveUp();
        this.transform.position=new Vector3(Mathf.Clamp(this.transform.position.x,-10,500),this.transform.position.y,Mathf.Clamp(this.transform.position.z,-10,500));
    }

    public void IsDowns()
    {
        if (IsDown == true)
        {
            IsDown = false;
        }
        else
        {
            IsDown = true;
        }      
    }
    public void IsRights()
    {
        if (IsRighrt == true)
        {
            IsRighrt = false;
        }
        else
        {
            IsRighrt = true;
        }
    }
    public void IsUps()
    {
        if (IsUp== true)
        {
            IsUp = false;
        }
        else
        {
            IsUp = true;
        }
    }
    public void IsLefts()
    {
        if (IsLeft== true)
        {
            IsLeft = false;
        }
        else
        {
            IsLeft = true;
        }
    }

    private void MoveUp()
    {
       if (IsUp == true)
      {
            a.transform.Translate(Direction.transform.forward * speed * Time.deltaTime, Space.World);
        }      
    }

    private void MoveLeft()
    {
        if (IsLeft == true)      {
            a.transform.Translate(-Direction.transform.right* speed * Time.deltaTime, Space.World);
       }      
    }

    private void MoveRight()
    {
        if (IsRighrt == true)
        {
            a.transform.Translate(Direction.transform.right * speed * Time.deltaTime, Space.World);
       }      
    }

    public void MoveDown()
    {
     if (IsDown==true)
      {
           a.transform.Translate(-Direction.transform.forward * speed * Time.deltaTime, Space.World);
      }      
    }
}
