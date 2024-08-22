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
    public void Active(int score)
    {
        tmp.text = score.ToString();
    }
    public void Deactive()
    {
        Destroy(gameObject);
    }
}
