using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffecter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.SendMessage("EnterBomb", 5, SendMessageOptions.DontRequireReceiver);
        }
    }
}
