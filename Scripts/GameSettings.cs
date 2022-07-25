using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameSettings gameSettings;
    public string versionNumber = "0.1";
    public string nickName = "photonFPS";

    public void Awake()
    {
        gameSettings = this;
    }

}
