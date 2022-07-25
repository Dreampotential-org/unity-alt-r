using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class EstablishConnection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NickName = GameSettings.gameSettings.nickName + Random.Range (0,999);
        PhotonNetwork.GameVersion = GameSettings.gameSettings.versionNumber;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion("us");
        Debug.Log("Connecting to Server");
    }


    public void createRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(UIManager.uIManager.joiningRoom.text , roomOptions, TypedLobby.Default);
    }

    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinLobby();
        Invoke("delayInLeaveRoom", 1f);
    }

    public void delayInLeaveRoom()
    {
        UIManager.uIManager.roomPanel.SetActive(false);
        UIManager.uIManager.lobbyPanel.SetActive(true);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }



    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to Server");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
        UIManager.uIManager.roomManager.SetActive(true);
    }

    public override void OnJoinedLobby()
    {
        UIManager.uIManager.lobbyPanel.SetActive(true);
    }

    

    public override void OnJoinedRoom()
    {

        UIManager.uIManager.lobbyPanel.SetActive(false);
        UIManager.uIManager.roomPanel.SetActive(true);
        UIManager.uIManager.roomName.text = PhotonNetwork.CurrentRoom.Name + " Is Created Successfully";

        Player[] player = PhotonNetwork.PlayerList;

        Debug.Log(player.Length);

        if (player.Length <= 5)
        {

            for (int i = 0; i < player.Length; i++)
            {
                Instantiate(UIManager.uIManager.playerListItem, UIManager.uIManager.playerListContent).GetComponent<PlayerListItem>().setUp(player[i]);
            }
        }
        else
        {
            Debug.Log("Room is already full");
        }

        UIManager.uIManager.startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

  
   
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(UIManager.uIManager.playerListItem, UIManager.uIManager.playerListContent).GetComponent<PlayerListItem>().setUp(newPlayer);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        UIManager.uIManager.startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

}
