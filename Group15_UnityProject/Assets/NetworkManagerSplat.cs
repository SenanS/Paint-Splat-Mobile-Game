using UnityEngine;
using Mirror;

[AddComponentMenu("")]
public class NetworkManagerSplat : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        print("#Players =");
        print(numPlayers);
        if (numPlayers == 0)
        {
            GameObject player = Instantiate(Resources.Load("Player#1", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
        }
        else if (numPlayers == 1)
        {
            GameObject player = Instantiate(Resources.Load("Player#2", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
        }
        else if (numPlayers == 2)
        {
            GameObject player = Instantiate(Resources.Load("Player#3", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
        }
        else
        {
            GameObject player = Instantiate(Resources.Load("Player#4", typeof(GameObject))) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}
