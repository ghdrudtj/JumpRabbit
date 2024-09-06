using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("¿¬Ãâ")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopInterval = 0.2f;
    public Effect effect;

    [Header("¾ÆÀÌÅÛ")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus = 0.25f;

    [Header("ÇÃ·¹ÀÌ¾î")]
    public float JumpPowerIncrease = 1;
    public float GameOverYHeight = -6.5f;

    [Header("ÇÃ·§Æû")]
    [Tooltip("Å« ÇÃ·§Æû Prab")]public Platform[] LargePlatformArr;
    [Tooltip("Áß°£ ÇÃ·§Æû Prab")] public Platform[] MiddlePlatformArr;
    [Tooltip("ÀÛÀº ÇÃ·§Æû Prab")] public Platform[] SmallPlatformArr;
    [Tooltip("ÇÃ·§Æû ¹èÄ¡")] public PlatformManager.Data[] DataArr;

    [Tooltip("ÇÃ·§Æû ÃÖ¼Ò °£°Ý")] public float GapIntervaMin = 1;
    [Tooltip("ÇÃ·§Æû ÃÖ´ë °£°Ý")] public float GapIntervaMax = 3;
    [Tooltip("º¸³Ê½º Ãß°¡ Á¡¼ö")] public float BonusValue = 0;
    public int remainPlatformCount = 5;

    [Header("Ä«¸Þ¶ó")]
    public float followSpeed = 5f;

    [Header("»ç¿îµå")]
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
