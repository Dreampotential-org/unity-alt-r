using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;
    public GameObject lobbyPanel, roomPanel;
    public TextMeshProUGUI roomName;
    public GameObject playerListItem;
    public Transform playerListContent;
    public GameObject startGameButton;
    public GameObject roomManager;
    public TextMeshProUGUI joiningRoom;

    // Start is called before the first frame update
    void Awake()
    {
        uIManager = this;  
    }

   
}
