using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    private float JumpPower = 0;
    private Platform landedPlatform;

    private Animator anim;
    private Rigidbody2D rigd;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    internal void Init()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("StateID", 1);
        }
        else if (Input.GetKeyUp(KeyCode.Space)) 
        {
            rigd.AddForce(Vector2.one*JumpPower);
            anim.SetInteger("StateID", 2);
            JumpPower = 0;

            Define.SfxType sfxType = Random.value < 0.5f ? Define.SfxType.Jump1 : Define.SfxType.Jump2;
            SoundManager.instance.PlaySfx(sfxType);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrease;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);

        CameraManager.Instance.OnFollow(transform.position);

        if (collision.transform.parent.TryGetComponent(out Platform platform))
        {
            if (landedPlatform != platform)
            {
                ScoreManager.instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
            }
            else
            {
                ScoreManager.instance.ResetBonus(transform.position);
            }
            ScoreManager.instance.AddScore(platform.Score,platform.transform.position);

            landedPlatform = platform;
        }
    }
}
