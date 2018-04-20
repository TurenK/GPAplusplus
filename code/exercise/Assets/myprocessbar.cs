using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myprocessbar : MonoBehaviour
{
    public Transform myprogress;
    private float currentAmount = 0;
    private float m_speed = 20;

    // Update is called once per frame
    void Update()
    {
        myprogress.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/3, Screen.height);
        if (currentAmount < 100)
        {
            currentAmount += m_speed * Time.deltaTime;
            // setText.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            //setText.gameObject.SetActive(true);
        }
        else
        {
            // loadingtext.GetComponent<Text>().text = "Done";
            // setText.gameObject.SetActive(false);
        }
        myprogress.GetComponent<Image>().fillAmount = currentAmount / 100;
    }


    void Awake()
    {
        myprogress.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/3, Screen.height);
    }
}