using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D cof;
    [SerializeField] private int score;
    public int Score => score;

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

        if(Random.value < DataBaseManager.Instance.itemSpawnPer)
        {
            Item item = Instantiate<Item>(DataBaseManager.Instance.baseItem);
            item.Active(transform.position, GetHalfSizeX());
        }
    }
    internal void OnLanding()
    {
        ScoreManager.instance.AddScore(score, transform.position);
    }
}
