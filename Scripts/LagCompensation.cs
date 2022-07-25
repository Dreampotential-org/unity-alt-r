using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LagCompensation : MonoBehaviourPun, IPunObservable
{
    Rigidbody rigidbody;
    Vector3 networkPosition;
    Quaternion networkRotation;

    // Start is called before the first frame update
    public void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            rigidbody.position = Vector3.MoveTowards(rigidbody.position, networkPosition, Time.fixedDeltaTime);
            rigidbody.rotation = Quaternion.RotateTowards(rigidbody.rotation, networkRotation, Time.fixedDeltaTime * 100.0f);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rigidbody.position);
            stream.SendNext(rigidbody.rotation);
            stream.SendNext(rigidbody.velocity);
        }
        else
        {
            networkPosition = (Vector3)stream.ReceiveNext();
            networkRotation = (Quaternion)stream.ReceiveNext();
            rigidbody.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            networkPosition += ( rigidbody.velocity * (lag*2));
        }
    }
}
