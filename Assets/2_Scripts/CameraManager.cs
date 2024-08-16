using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    [SerializeField] private float follSpeed = 5f;
    public void Init()
    {
        Instance = this;
    }
    public IEnumerator OnFollowCor(Vector2 targePos)
    {
        while(0.1f < Vector3.Distance(transform.position, targePos))
        {
            transform.position = Vector3.Lerp(transform.position, targePos, Time.deltaTime * follSpeed);
            yield return null;
        }
    }
    public void OnFollow(Vector2 targePos)
    {
        StartCoroutine(OnFollowCor(targePos));
    }


}
