using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField]private DataBaseManager dataBaseManager;

    private void Awake()
    {
        dataBaseManager.Init();
        player.Init();
        platformManager.Init();
        cameraManager.Init();
        
    }
    private void Start()
    {
        platformManager.Active();
    }
}
