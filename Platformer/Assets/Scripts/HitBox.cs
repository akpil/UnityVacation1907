using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int TargetHitCount;
    public int currentHitCount;
    private BoxCollider2D mCollider;

    // Start is called before the first frame update
    void Start()
    {
        currentHitCount = 0;
        mCollider = GetComponent<BoxCollider2D>();
    }

    public void Hit(int value)
    {
        Debug.Log(value);
        currentHitCount++;
        if (currentHitCount == TargetHitCount)
        {
            StartCoroutine(CheckUP());
        }
    }

    private IEnumerator CheckUP()
    {
        yield return new WaitForSeconds(5);
        if (currentHitCount == TargetHitCount)
        {
            Debug.Log("to NextStage");
            mCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
