using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D cof;

    public float GetHalfSizeX()
    {
        return cof.size.x*0.5f;
    } 
    private void Awake()
    {
        cof= GetComponentInChildren<BoxCollider2D>();
    }
    public void Active(Vector2 pos)
    {
        transform.position = pos;   
    }
}
