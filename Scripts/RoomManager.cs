using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager roomManager;

    // Start is called before the first frame update
    void Awake()
    {
        if (roomManager == null)
        {
            roomManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene , LoadSceneMode loadSceneMode)
    {
 
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefebs", "PlayerManager"), Vector3.zero , Quaternion.identity);
    }
    
}
