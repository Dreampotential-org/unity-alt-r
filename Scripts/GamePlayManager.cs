using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePlayManager : MonoBehaviour
{

    public static GamePlayManager gameManager;
    [HideInInspector]public GameObject player;

    public GameObject[] AmplitudeMeter;
   public GameObject setting;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void clickOnSettingButton (){
	setting.SetActive (true);
}

public void clickOnCloseButton (){
	setting.SetActive (false);
}
}
