using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody mRB;
    public Vector3 OriginalPos;
    public float Speed;
    public float BossPhaseZPos;
    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        transform.position = OriginalPos;
        StartCoroutine(BossMovement());
    }

    private IEnumerator BossMovement()
    {
        mRB.velocity = Vector3.back * Speed;
        while (transform.position.z > BossPhaseZPos)
        {
            yield return new WaitForFixedUpdate();
        }
        mRB.velocity = Vector3.zero;

        while (true)
        {
            mRB.velocity = Vector3.left * Speed;
            yield return new WaitForSeconds(2);
            mRB.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);
            mRB.velocity = Vector3.right * Speed;
            yield return new WaitForSeconds(4);
            mRB.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);
            mRB.velocity = Vector3.left * Speed;
            yield return new WaitForSeconds(2);
            mRB.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}

