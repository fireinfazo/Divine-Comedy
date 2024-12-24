using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviourPunCallbacks
{
    public static Game_Manager Instance;
    [SerializeField] private GameObject _playerPrefab;
    private Vector3 _startPosition;

    private void Awake()
    {
        Instance = this;

        float range = Random.Range(-5f, 5f);
        _startPosition = new Vector3(range, 1f, range);

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(_playerPrefab.name, Vector3.zero, Quaternion.identity);
        }
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");

        PhotonNetwork.Instantiate(_playerPrefab.name, Vector3.zero, Quaternion.identity);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }


}
