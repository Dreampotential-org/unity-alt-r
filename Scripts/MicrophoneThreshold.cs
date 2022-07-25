using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using System.IO;

public class MicrophoneThreshold : MonoBehaviour
{
    public Slider thresholdLevel;
    public TextMeshProUGUI textToShowThresholdLevel;
   // PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        //thresholdLevel.value = GamePlayManager.gameManager.recorder.VoiceDetectionThreshold;
    }


    public void Update()
    {

     
    }

    // Update is called once per frame
    public void changeThresholdLevel()
    {
       // GamePlayManager.gameManager.recorder.VoiceDetectionThreshold = thresholdLevel.value;
       // textToShowThresholdLevel.text = GamePlayManager.gameManager.recorder.VoiceDetectionThreshold.ToString("0.00");
    }

   
}
