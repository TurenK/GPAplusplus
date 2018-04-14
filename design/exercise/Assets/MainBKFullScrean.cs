using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBKFullScrean : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
      //  Handheld.PlayFullScreenMovie("startcg.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    void Awake()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);


    }

    void OnGUI()
    {

    }

}
