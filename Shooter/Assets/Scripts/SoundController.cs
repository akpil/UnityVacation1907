using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectSoundType
{
    ExpAst,
    ExpEnemy,
    ExpPlayer,
    FireEnemy,
    FirePlayer
}

public class SoundController : MonoBehaviour
{
    public AudioClip[] EffectSoundArr;
    public AudioClip[] BGMArr;

    public AudioSource BGMSource;
    public AudioSource EffectSource;

    // Start is called before the first frame update
    void Start()
    {
        BGMSource.clip = BGMArr[0];
        BGMSource.Play();
    }

    public void PlayEffectSound(int effectSoundID)
    {
        EffectSource.PlayOneShot(EffectSoundArr[effectSoundID]);
    }
}
