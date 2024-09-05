using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void Active(Vector3 pos)
    {
        transform.position = pos;
    }
    public void CallAni()
    {
        Destroy(gameObject);
    }
}
