using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip enemyShootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damagevolume = 1f;

    public void PlayShootingClip()
    {
        playAudio(shootingClip, shootingVolume);
    }

    public void PlayEnemyShootingClip()
    {
        playAudio(enemyShootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        playAudio(damageClip, damagevolume);
    }

    private void playAudio(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,
            Camera.main.transform.position,
            volume);
        }
    }
}
