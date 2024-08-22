using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;
    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;

    [Header("�÷���")]
    [Tooltip("ū �÷��� Prab")]public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷��� Prab")] public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷��� Prab")] public Platform[] SmallPlatformArr;
    [Tooltip("�÷��� ��ġ")] public PlatformManager.Data[] DataArr;

    [Tooltip("�÷��� �ּ� ����")] public float GapIntervaMin = 1;
    [Tooltip("�÷��� �ִ� ����")] public float GapIntervaMax = 3;
    [Tooltip("���ʽ� �߰� ����")] public float BonusValue = 0;

    [Header("ī�޶�")]
    public float followSpeed = 5f;
    public void Init()
    {
        Instance = this;
    }
}
