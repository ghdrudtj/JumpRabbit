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
    private bool isJumpReady;

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
        if (isJumpReady == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumpReady = true;
                anim.SetInteger("StateID", 1);
            }
        }
        else
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrease * Time.deltaTime;
            if(JumpPower > DataBaseManager.Instance.maxJumpPower)
            {
                SetIdleState();
                return;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumpReady = false;
                if (JumpPower < DataBaseManager.Instance.minJumpPower)
                {
                    SetIdleState();
                }
                else
                {
                    rigd.AddForce(Vector2.one * JumpPower);
                    anim.SetInteger("StateID", 2);
                    JumpPower = 0;

                    Define.SfxType sfxType = Random.value < 0.5f ? Define.SfxType.Jump1 : Define.SfxType.Jump2;
                    SoundManager.instance.PlaySfx(sfxType);

                    Effect effect = Instantiate(DataBaseManager.Instance.effect);
                    effect.Active(transform.position);
                }
            }
        }
        if (transform.position.y < DataBaseManager.Instance.GameOverYHeight)
        {
            GameManager.instance.OnGameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetIdleState();

        CameraManager.Instance.OnFollow(transform.position);

        if (collision.transform.TryGetComponent(out Platform platform))
        {
            PlatformManager.instance.LandingPlatformNum = platform.number;
            platform.OnLandingAnim();
            if (landedPlatform == null)
            {
                landedPlatform = platform;
                return;
            }
            if (landedPlatform != platform)
            {
                ScoreManager.instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
            }
            else
            {
                ScoreManager.instance.ResetBonus(transform.position);
            }
            ScoreManager.instance.AddScore(platform.Score, platform.transform.position);

            landedPlatform = platform;
        }
    }

    private void SetIdleState()
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);
        JumpPower = 0;
        isJumpReady = false;
    }
}
