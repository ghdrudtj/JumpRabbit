using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;
    [System.Serializable]
    public class Data
    {
        [Tooltip("ÇÃ·§Æû ±×·ì °¹¼ö")]public int GroupCount;
        [Tooltip("Å« ÇÃ·§Æû ºñÀ² 0~1"),Range(0,1f)][SerializeField] private float LargePercent;
        [Tooltip("Áß°£ ÇÃ·§Æû ºñÀ² 0~1"),Range(0, 1f)][SerializeField] private float MiddlePercent;
        [Tooltip("ÀÛÀº ÇÃ·§Æû ºñÀ² 0~1"),Range(0, 1f)][SerializeField] private float SmallPercent;

        public int GetPlatformID()
        {
            float ranVal = UnityEngine.Random.value;
            int platformID;
            if(ranVal <= LargePercent)
            {
                platformID = 2;
            }
            else if(ranVal <= LargePercent + MiddlePercent) 
            { 
                platformID = 1;
            }
            else
            {
                platformID = 0;
            }
            return platformID;
        }
    }

    [SerializeField] private Transform SpawnPosTrf;
    private Vector3 spawnpos;
    private int platformNum;
    public int LandingPlatformNum;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    internal void Active()
    {
        spawnpos = SpawnPosTrf.position;
        int platformGroupSum = 0;

        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum : {platformGroupSum}");
            while (platformNum < platformGroupSum)
            {
                int platfromID = data.GetPlatformID();
                ActiveOne(platfromID);
            }
        }
    }
    private void ActiveOne(int platformID)
    {
        platformNum++;
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];
        Debug.Log($"Platform=  + [{platformID},{randID}]");

        Platform platform = Instantiate(randomplatform);

        if(platformNum > 1)
            spawnpos = spawnpos + Vector3.right * platform.GetHalfSizeX();
        platform.Active(spawnpos, platformNum);

        float gap =Random.Range(DataBaseManager.Instance.GapIntervaMin, DataBaseManager.Instance.GapIntervaMax);
        spawnpos = spawnpos + Vector3.right * (platform.GetHalfSizeX()+gap);
        return;
    }
    internal void Init()
    {
        instance = this;
        PlatformArrDic.Add(0, DataBaseManager.Instance.SmallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
    }
    public void Update()
    {
        if(platformNum - LandingPlatformNum < DataBaseManager.Instance.remainPlatformCount)
        {
            int lastindex = DataBaseManager.Instance.DataArr.Length - 1;
            Data lastData = DataBaseManager.Instance.DataArr[lastindex];

            for (int i = 0; i < lastData.GroupCount; i++)
            {
                int platfromID = lastData.GetPlatformID();
                ActiveOne(platfromID);
            }
        }
    }
}
