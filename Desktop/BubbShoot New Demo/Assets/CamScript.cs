using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform player;
    public float offset = 1.5f;
    public float cameraSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.position;
        Vector3 movePosition = Vector3.Lerp(transform.position, playerPosition, cameraSpeed);
        transform.position = new Vector3(movePosition.x,movePosition.y, transform.position.z);
    }
}
