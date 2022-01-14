using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = new Vector3(player1.position.x, player1.position.y, transform.position.z);
        transform.position = new Vector3(player2.position.x, player2.position.y, transform.position.z);
        transform.position = new Vector3(player3.position.x, player.position.y, transform.position.z);
        transform.position = new Vector3(player4.position.x, player.position.y, transform.position.z);
    }

}