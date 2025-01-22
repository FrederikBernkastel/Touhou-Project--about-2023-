using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable
public static class GlobalVarybles
{
    public static CameraArray CameraArray = default!;
    public static StorageArray StorageArray = default!;
    public static GameObject Player = default!;
    public static GameObject? MainEnemy;
} 
public class GlobalVaryblesScript : MonoBehaviour
{
    public CameraArray CameraArray = default!;
    public StorageArray StorageArray = default!;
    public GameObject Player = default!;
    public ScriptingFullScript Script = default!;

    private void Awake()
    {
        GlobalVarybles.CameraArray = CameraArray;
        GlobalVarybles.Player = Player;
        GlobalVarybles.StorageArray = StorageArray;
    }
    private void Start()
    {
        Script.OnStartScript(null, transform);
    }
}
[System.Serializable]
public class CameraArray
{
    public GameObject GameCamera = default!;
    public GameObject LevelCamera = default!;
}
[System.Serializable]
public class StorageArray
{
    public GameObject StorageEnemys = default!;
    public GameObject StorageItems = default!;
    public GameObject StorageEffects = default!;
    public GameObject StorageBullets = default!;
}
