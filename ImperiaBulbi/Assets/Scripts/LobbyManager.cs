using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text LogText;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        int num = Random.Range(0, 1000);
        PhotonNetwork.NickName = $"Player {num}";

        Debug.Log("Player: " + PhotonNetwork.NickName);
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "1";
    }
    void Update()
    {

    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected cool!");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Join room");
        PhotonNetwork.LoadLevel("MyLevel");    // ???? ? ??????? ?????????? ?? ??????? ???????
                                               // ?? ????? ?????????? ????????? ????? ?? ?????
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Room was created");
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 15,
            IsOpen = true,
            IsVisible = true
        };

        PhotonNetwork.CreateRoom("RoomName", roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}