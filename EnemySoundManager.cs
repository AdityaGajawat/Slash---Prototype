using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource attackAudio;
    [SerializeField] private AudioSource hitAudio;
    public void attackSound()
    {
        attackAudio.volume = Random.Range(0.5f, 1.0f);
        attackAudio.pitch = Random.Range(.45f, .55f);
        attackAudio.Play();
    }
    public void hitSound()
    {
        hitAudio.pitch = Random.Range(.55f, .65f);
        hitAudio.Play();
        
    }
}
