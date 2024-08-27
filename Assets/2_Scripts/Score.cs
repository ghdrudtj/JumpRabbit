using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshPro tmp;
    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshPro>();
    }
    public void Active(string scoreTxt,Color color)
    {
        tmp.text = scoreTxt;
        tmp.color = color;
    }
    public void Deactive()
    {
        Destroy(gameObject);
    }
}
