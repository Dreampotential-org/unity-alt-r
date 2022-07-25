using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    Player player;

    public void setUp (Player _player)
    {
        player = _player;
        this.GetComponent<TextMeshProUGUI>().text = _player.NickName;
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }
}
