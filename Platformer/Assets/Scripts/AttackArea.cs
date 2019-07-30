using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public string TargetTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            collision.SendMessage("Hit", 1, SendMessageOptions.DontRequireReceiver);
        }
    }
}
