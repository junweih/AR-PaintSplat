using UnityEngine;

public class MobileNetwork : Photon.PunBehaviour
{
    private string roomName;

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    // done
    // TODO-2.a: 
    // Copy and paste the Start() and OnJoinedLobby() methods from MobileNetwork_Cube.cs

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        roomName = "testing";
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRoom(roomName);
        base.OnJoinedLobby();
    }

    public override void OnJoinedRoom()
    {

        //GameObject ballObj = PhotonNetwork.Instantiate("ball", new Vector3(0.0f,0.0f,25.0f), Quaternion.identity, 0) as GameObject;
        GetComponent<MobileShooter>().Activate();
		base.OnJoinedRoom ();
    }
}
