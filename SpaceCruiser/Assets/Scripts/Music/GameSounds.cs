using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _explosionSound;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventsObserver.AddEventListener<PlayerDeathEvent>(PlayExplosionSound);
    }
    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<PlayerDeathEvent>(PlayExplosionSound);
    }

    private void PlayExplosionSound(PlayerDeathEvent e)
    {
        _audioSource.PlayOneShot(_explosionSound);
    }
}
