
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public GameSettings Settings;

    public static GameManager Instance;
    
    private void Awake()
    {
        Instance = this;
        Settings = Resources.Load<GameSettings>("GameSettings");
    }
    
}