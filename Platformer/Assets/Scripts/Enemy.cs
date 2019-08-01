using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D mRB2D;
    private Animator mAnim;

    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mRB2D = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();

        mAnim.SetBool(AnimHash.Walk, true);
        mRB2D.velocity = transform.right * MoveSpeed;
    }


}
