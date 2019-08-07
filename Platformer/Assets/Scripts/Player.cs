using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator mAnim;
    private Rigidbody2D mRB2D;

    public GaugeBar HPbar;

    public float Speed;
    public float JumpSpeed;

    private bool mbGround;

    public AttackArea attackArea;
    public int AttackPower;
    public string TargetName;

    public int MaxHP;
    private int mCurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        mCurrentHP = MaxHP;
        HPbar.ShowGauge(mCurrentHP, MaxHP);

        mAnim = GetComponent<Animator>();
        mRB2D = GetComponent<Rigidbody2D>();
        mbGround = true;
        attackArea.SetTargetTag(TargetName);
        attackArea.SetDamage(AttackPower);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            mAnim.SetBool(AnimHash.Walk, true);
        }
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            mAnim.SetBool(AnimHash.Walk, true);
        }
        else
        {
            mAnim.SetBool(AnimHash.Walk, false);
        }
        mRB2D.velocity = new Vector2(horizontal * Speed, mRB2D.velocity.y);

        if (Input.GetButtonDown("Jump") && mbGround)
        {
            mRB2D.velocity = mRB2D.velocity + new Vector2(0, JumpSpeed);
            mbGround = false;
        }
        mAnim.SetFloat(AnimHash.Jump, mRB2D.velocity.y);

        if (Input.GetButtonDown("Fire1"))
        {
            mAnim.SetBool(AnimHash.Melee, true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            mAnim.SetBool(AnimHash.Melee, false);
        }
    }

    public void Hit(int damage)
    {
        Debug.Log(damage);
        mCurrentHP = mCurrentHP - damage;
        
        if (mCurrentHP <= 0)
        {
            mAnim.SetBool(AnimHash.Dead, true);
            mCurrentHP = 0;
        }

        HPbar.ShowGauge(mCurrentHP, MaxHP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.enabled)
        {
            mbGround = true;
        }
    }
}
