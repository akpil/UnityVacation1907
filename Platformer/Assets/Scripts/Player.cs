using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator mAnim;
    public int WalkHash;
    // Start is called before the first frame update
    void Start()
    {
        mAnim = GetComponent<Animator>();
        WalkHash = Animator.StringToHash("IsWalk");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            mAnim.SetBool(WalkHash, true);
        }
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            mAnim.SetBool(WalkHash, true);
        }
        else
        {
            mAnim.SetBool(WalkHash, false);
        }
        
    }
}
