using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataBaseManager;
using static Define;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    public void lnit()
    {
        instance = this;
    }
    public void PlaySfx(Define.SfxType sfxType)
    {
        DataBaseManager.SfxData sfxData = DataBaseManager.Instance.GetSfxData(sfxType);
        sfxAudioSource.volume = sfxData.voIume;
        sfxAudioSource.PlayOneShot(sfxData.clip);
    }
    public void PlayBgm(Define.BgmType bgmtype)
    { 
        DataBaseManager.BgmData bgmData = DataBaseManager.Instance.GetBgaData(bgmtype);
        bgmAudioSource.clip = bgmData.clip;
        bgmAudioSource.volume = bgmData.voIume;
        bgmAudioSource.Play();
    }
}
