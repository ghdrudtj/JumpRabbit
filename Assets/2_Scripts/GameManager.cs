using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        dataBaseManager.Init();
        player.Init();
        platformManager.Init();
        cameraManager.Init();
        scoreManager.lnit();
    }
    private void Start()
    {
        platformManager.Active();
    }
}
