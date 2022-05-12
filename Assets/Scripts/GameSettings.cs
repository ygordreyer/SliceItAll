
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObject/GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    [Header("Camera Settings")]
    [Space] [Range(0f, 1f)]
    public float cameraFollowSpeed = 0.1f;
    public Vector3 cameraOffset = new(2f, 2f, 5f);
    
    [Header("Physics Settings")]
    [Space]
    public Vector3 centerOfMassOffset = new(0,0,0.13f);
    public Vector3 jumpForce = new (-1,2,0);
    
    
    [Header("Game Tags")]
    [Space]
    public string GroundTag = "Ground";
    public string KnifeTag = "Knife";
    public string KillBoxTag = "KillBox";
    
}
