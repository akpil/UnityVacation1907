using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public string TargetTag;
    private int Damage;

    public void SetTargetTag(string tag)
    {
        TargetTag = tag;
    }

    public void SetDamage(int dmg)
    {
        Damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            collision.SendMessage("Hit", Damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
