using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        PV = GetComponent<PhotonView>();

        if (PV.IsMine)
        {
            createController();
        }
    }

    void createController ()
    {
        GameObject obj =   PhotonNetwork.Instantiate(Path.Combine("PhotonPrefebs", "PlayerController"), new Vector3(Random.Range(1f, 30f), 0f, 0f) ,Quaternion.identity) as GameObject;
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefebs", "Threshold"), new Vector3(Random.Range(1f, 30f), 0f, 0f), Quaternion.identity);

        GamePlayManager.gameManager.player = obj;
    }
}
