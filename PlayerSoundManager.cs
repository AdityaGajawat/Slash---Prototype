using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource katanaAudio;
    [SerializeField] private AudioSource hitAudio;
    public void katanaSound()
    {
        katanaAudio.pitch = Random.Range(.55f,.75f);
        katanaAudio.Play();
    }
    public void hitSound()
    {
        hitAudio.Play();
    }
}
