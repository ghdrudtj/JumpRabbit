using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : MonoBehaviour
{
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
    
    private int platformNum;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    internal void Active()
    {
        Vector3 pos = SpawnPosTrf.position;
        int platformGroupSum = 0;

        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum : {platformGroupSum}");
            while (platformNum < platformGroupSum)
            {
                int platfromID = data.GetPlatformID();
                pos = ActiveOne(pos, platfromID);
                platformNum++;
            }
        }
    }
    private Vector3 ActiveOne(Vector3 pos, int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];
        Debug.Log($"Platform=  + [{platformID},{randID}]");

        Platform platform = Instantiate(randomplatform);

        if(platformNum != 0) 
            pos = pos + Vector3.right * platform.GetHalfSizeX();
        platform.Active(pos);

        float gap =Random.Range(DataBaseManager.Instance.GapIntervaMin, DataBaseManager.Instance.GapIntervaMax);
        pos = pos + Vector3.right * (platform.GetHalfSizeX()+gap);

        return pos;
    }
    internal void Init()
    {
        PlatformArrDic.Add(0, DataBaseManager.Instance.SmallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
    }
}
