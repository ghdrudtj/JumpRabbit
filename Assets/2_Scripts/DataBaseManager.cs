using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;
    [Header("ÇÃ·¹ÀÌ¾î")]
    public float JumpPowerIncrease = 1;

    [Header("ÇÃ·§Æû")]
    [Tooltip("Å« ÇÃ·§Æû Prab")]public Platform[] LargePlatformArr;
    [Tooltip("Áß°£ ÇÃ·§Æû Prab")] public Platform[] MiddlePlatformArr;
    [Tooltip("ÀÛÀº ÇÃ·§Æû Prab")] public Platform[] SmallPlatformArr;
    [Tooltip("ÇÃ·§Æû ¹èÄ¡")] public PlatformManager.Data[] DataArr;

    [Tooltip("ÇÃ·§Æû ÃÖ¼Ò °£°Ý")] public float GapIntervaMin = 1;
    [Tooltip("ÇÃ·§Æû ÃÖ´ë °£°Ý")] public float GapIntervaMax = 3;
    [Tooltip("º¸³Ê½º Ãß°¡ Á¡¼ö")] public float BonusValue = 0;

    [Header("Ä«¸Þ¶ó")]
    public float followSpeed = 5f;
    public void Init()
    {
        Instance = this;
    }
}
