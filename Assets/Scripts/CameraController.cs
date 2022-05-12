using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        Vector3 position = player.position + GameManager.Instance.Settings.cameraOffset;
        Vector3 smooth = Vector3.Lerp(transform.position, position, GameManager.Instance.Settings.cameraFollowSpeed);
        transform.position = smooth;
        
        transform.LookAt(player);
    }
}
