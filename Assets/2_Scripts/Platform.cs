using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D cof;
    private Animation anim;
    public int number;
    [SerializeField] private int score;
    public int Score => score;

    public float GetHalfSizeX()
    {
        return cof.size.x*0.5f;
    } 
    private void Awake()
    {
        cof= GetComponentInChildren<BoxCollider2D>();
        anim= GetComponent<Animation>();
    }
    public void Active(Vector2 pos, int platformNum)
    {
        transform.position = pos;
        number = platformNum;
        if (platformNum==1)
            return;
        if(Random.value < DataBaseManager.Instance.itemSpawnPer)
        {
            Item item = Instantiate<Item>(DataBaseManager.Instance.baseItem);
            item.Active(transform.position, GetHalfSizeX());
        }
    }
    internal void OnLandingAnim()
    {
        anim.Play();
    }
}
