using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this.gameObject);
            initVoiceChatSetting();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void initVoiceChatSetting ()
    {
        PlayerPrefs.SetInt("VoiceSetting", 0);
    }
 
}

public enum States
{
    lobby, 
    room
}

