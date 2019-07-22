﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody mRB;
    public Transform BoltPos;
    public float Speed;
    private BoltPool mPool;
    private Transform mPlayerTransform;
    private EffectPool effect;
    private GameController gameController;
    private SoundController soundController;

    void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = Vector3.back * Speed;
        GameObject effectObj = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObj.GetComponent<EffectPool>();
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();
        soundController = gameController.GetSoundController();
    }

    private void OnEnable()
    {
        StartCoroutine(AutoFire());
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            mPlayerTransform = player.transform;
        }
        else
        {
            mPlayerTransform = transform;
        }
        StartCoroutine(SideMovement());
    }

    public void SetUP(BoltPool pool)
    {
        mPool = pool;
    }

    private IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.7f, 1.2f));
            Bolt bolt = mPool.GetFromPool();
            bolt.transform.position = BoltPos.position;
            soundController.PlayEffectSound((int)eEffectSoundType.FireEnemy);
        }
    }

    private IEnumerator SideMovement()
    {
        while (true)
        {
            float playerX = mPlayerTransform.position.x;
            Vector3 currentVel = mRB.velocity;

            currentVel.x = playerX - currentVel.x;
            mRB.velocity = currentVel;
            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
            other.gameObject.CompareTag("Player"))
        {
            gameController.AddScore(1);
            Timer newEffect = effect.GetFromPool((int)eEffectType.EnemyExp);
            newEffect.transform.position = transform.position;
            soundController.PlayEffectSound((int)eEffectSoundType.ExpEnemy);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
