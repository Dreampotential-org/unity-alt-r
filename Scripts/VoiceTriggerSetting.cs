using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dissonance;
using Photon.Pun;
using Dissonance.Audio;


public class VoiceTriggerSetting : MonoBehaviour
{
    public PhotonView PV;
    float currentVolume;
    

    // Start is called before the first frame update
    void Awake()
    {
        //PV = this.gameObject.GetComponent<PhotonView>();
        //if (PV.IsMine)
        {
           // Destroy(this.gameObject.GetComponent<VoiceReceiptTrigger>());
          //  Destroy(this.gameObject.GetComponent<VoiceBroadcastTrigger>()); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            AmplitudeMeter();
        }
    }

    public void AmplitudeMeter ()
    {
        currentVolume = this.gameObject.GetComponent<VoiceBroadcastTrigger>().CurrentFaderVolume;

        if (currentVolume < 0.1f)
        {
            GamePlayManager.gameManager.AmplitudeMeter[0].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[1].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[2].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[3].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[4].SetActive(false);
        }

        else if (currentVolume < 0.25f)
        {
            GamePlayManager.gameManager.AmplitudeMeter[0].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[1].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[2].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[3].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[4].SetActive(false);
        }
        else if (currentVolume < 0.45f)
        {
            GamePlayManager.gameManager.AmplitudeMeter[0].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[1].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[2].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[3].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[4].SetActive(false);
        }
        else if (currentVolume < 0.65f)
        {
            GamePlayManager.gameManager.AmplitudeMeter[0].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[1].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[2].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[3].SetActive(false);
            GamePlayManager.gameManager.AmplitudeMeter[4].SetActive(false);
        }
        else if (currentVolume < 0.85f)
        {
            GamePlayManager.gameManager.AmplitudeMeter[0].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[1].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[2].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[3].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[4].SetActive(false);
        }
        else if (currentVolume < 0.95f)
        {
            GamePlayManager.gameManager.AmplitudeMeter[0].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[1].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[2].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[3].SetActive(true);
            GamePlayManager.gameManager.AmplitudeMeter[4].SetActive(false);
        }
    }
}
