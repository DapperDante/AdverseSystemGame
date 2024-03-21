using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager obj;
    public AudioClip rechargeStation;
    public AudioClip FireJumpPlayer;
    private AudioSource audiosrc;
    public void Awake() { obj = this; }
    private void Start()
    {
        audiosrc = gameObject.AddComponent<AudioSource>();
    }
    public void PlayRecharge() { Sound(rechargeStation); }
    public void PlayFireJump() { Sound(FireJumpPlayer);}
    public void Sound(AudioClip sound)
    {
        audiosrc.PlayOneShot(sound);
    }
}
