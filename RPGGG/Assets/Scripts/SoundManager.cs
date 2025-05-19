using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("-----Background Music-----")]
    [SerializeField] private AudioClip BGM;
    
    [Header("-----SFX-----")]
    [SerializeField] public AudioClip playerAttack;
    [SerializeField] public AudioClip enemyAttack;
    [SerializeField] public AudioClip playerScream;
    [SerializeField] public AudioClip playerDeath;
    [SerializeField] public AudioClip enemyScream;
    [SerializeField] public AudioClip enemyDeath;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceSFX;

    private void Start()
    {
        audioSource.clip = BGM;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSourceSFX.clip = clip;
        audioSourceSFX.PlayOneShot(clip);
    }
}
