using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEnemyState
{
    Idle,
    Move,
    Chase,
    Attack,
    Dead
}

public class Enemy : MonoBehaviour
{
    private Rigidbody2D mRB2D;
    private Animator mAnim;

    public float MoveSpeed;

    private eEnemyState mState;

    private Transform mTarget;

    // Start is called before the first frame update
    void Start()
    {
        mRB2D = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();

        mState = eEnemyState.Idle;
        StartCoroutine(AI());
    }

    public void FinishAttack()
    {
        mAnim.SetBool(AnimHash.Melee, false);
        Debug.Log("Attack Finish");
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
        mState = eEnemyState.Chase;
    }

    public void RemoveTarget()
    {
        mTarget = null;
        mState = eEnemyState.Idle;
        // shift to Move
    }

    private IEnumerator AI()
    {
        while (true)
        {
            switch (mState)
            {
                case eEnemyState.Idle:
                    if (transform.rotation.y > 90)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    break;
                case eEnemyState.Move:
                    mAnim.SetBool(AnimHash.Walk, true);
                    mRB2D.velocity = transform.right * MoveSpeed;
                    break;
                case eEnemyState.Chase:
                    Vector2 direction = mTarget.position - transform.position;
                    if (direction.x < 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);                        
                    }
                    mAnim.SetBool(AnimHash.Walk, true);
                    mRB2D.velocity = transform.right * MoveSpeed;
                    break;
                case eEnemyState.Attack:
                    mAnim.SetBool(AnimHash.Melee, true);
                    break;
                case eEnemyState.Dead:

                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
