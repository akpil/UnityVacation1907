using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody mRB;
    public Transform BoltPos;
    public BoltPool pool;

    void Awake()
    {
        mRB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(AutoFire());
    }

    private IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.7f, 1.2f));
            Bolt bolt = pool.GetFromPool();
            bolt.transform.position = BoltPos.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
            other.gameObject.CompareTag("Player"))
        {
            //점수 올리기
            //이펙트
            //사운드
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
