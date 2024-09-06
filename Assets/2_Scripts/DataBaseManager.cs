using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("����")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopInterval = 0.2f;
    public Effect effect;

    [Header("������")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus = 0.25f;

    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;
    public float GameOverYHeight = -6.5f;

    [Header("�÷���")]
    [Tooltip("ū �÷��� Prab")]public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷��� Prab")] public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷��� Prab")] public Platform[] SmallPlatformArr;
    [Tooltip("�÷��� ��ġ")] public PlatformManager.Data[] DataArr;

    [Tooltip("�÷��� �ּ� ����")] public float GapIntervaMin = 1;
    [Tooltip("�÷��� �ִ� ����")] public float GapIntervaMax = 3;
    [Tooltip("���ʽ� �߰� ����")] public float BonusValue = 0;
    public int remainPlatformCount = 5;

    [Header("ī�޶�")]
    public float followSpeed = 5f;

    [Header("����")]
    public SfxData[] sfxDataArr;
    public BgmData[] bgaDataArr;
    private Dictionary<Define.SfxType, SfxData> sfxDataDic;
    private Dictionary<Define.BgmType, BgmData> bgmDataDic;
    public void Init()
    {
        Instance = this;
        sfxDataDic = new Dictionary<Define.SfxType, SfxData>();
        foreach(SfxData data in sfxDataArr)
        {
            sfxDataDic.Add(data.sfxType, data);
        }
        bgmDataDic = new Dictionary<Define.BgmType, BgmData>();
        foreach(BgmData data in bgaDataArr)
        {
            bgmDataDic.Add(data.bgmType, data);
        }
    }
    public SfxData GetSfxData(Define.SfxType type)
    {
        return sfxDataDic[type];
    }
    public BgmData GetBgaData(Define.BgmType type)
    {
        return bgmDataDic[type];
    }
    [System.Serializable]
    public class SfxData : SoundData
    {
        public Define.SfxType sfxType;
    }
    [System.Serializable]
    public class BgmData:SoundData
    {
        public Define.BgmType bgmType;
    }
    [System.Serializable]
    public class SoundData
    {
        public AudioClip clip;
        public float voIume = 1;
    }
}
