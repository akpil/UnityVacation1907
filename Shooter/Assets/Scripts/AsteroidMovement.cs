using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody mRB;
    public float Speed;
    private EffectPool effect;
    private GameController gameController;

    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = Vector3.back * Speed;
        GameObject effectObj = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObj.GetComponent<EffectPool>();
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();
    }
    private void OnEnable()
    {
        mRB.angularVelocity = Random.onUnitSphere * 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
            other.gameObject.CompareTag("Player"))
        {
            gameController.AddScore(1);
            Timer newEffect = effect.GetFromPool((int)eEffectType.AsteroidExp);
            newEffect.transform.position = transform.position;
            //사운드
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
