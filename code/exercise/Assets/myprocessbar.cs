using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            myprogress.GetComponent<Image>().fillAmount = currentAmount / 100;
        }
        else
        {
            // loadingtext.GetComponent<Text>().text = "Done";
            // setText.gameObject.SetActive(false);
            SceneManager.LoadScene("GameScene");
        }
       
    }


    void Awake()
    {
        myprogress.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/3, Screen.height);
    }
}