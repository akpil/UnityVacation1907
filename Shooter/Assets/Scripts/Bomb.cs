using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody mRB;
    public GameObject Effect;
    public float Speed;
    private SoundController mSoundController;


    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mSoundController = GameObject.FindGameObjectWithTag("GameController").
                           GetComponent<GameController>().
                           GetSoundController();
    }

    private void OnEnable()
    {
        mRB.velocity = transform.forward * Speed;
    }

    private void OnDisable()
    {
        Effect.transform.position = transform.position;
        Effect.SetActive(true);
        mSoundController.PlayEffectSound((int)eEffectSoundType.ExpPlayer);
    }
}
