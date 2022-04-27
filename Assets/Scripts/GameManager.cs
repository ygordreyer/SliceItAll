
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string GroundTag = "Ground";
    public static string KnifeTag = "Knife";
    public static string DestroyableTag = "Destroyable";
    public static string KillBoxTag = "KillBox";

    public static GameManager Instance;

    private void Awake() => Instance = this;

    public float cameraFollowSpeed = 0.1f;
    public Vector3 cameraOffset;

    public Vector3 centerOfMassOffset = new Vector3();
}