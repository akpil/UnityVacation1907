using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody mRB;
    public float Speed;
    private EffectPool effect;
    private GameController gameController;
    private SoundController soundController;

    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = Vector3.back * Speed;
        GameObject effectObj = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObj.GetComponent<EffectPool>();
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();
        soundController = gameController.GetSoundController();
    }
    private void OnEnable()
    {
        mRB.angularVelocity = Random.onUnitSphere * 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnterBomb(float damage)
    {
        Hit();
    }

    private void Hit()
    {
        gameController.AddScore(1);
        Timer newEffect = effect.GetFromPool((int)eEffectType.AsteroidExp);
        newEffect.transform.position = transform.position;
        soundController.PlayEffectSound((int)eEffectSoundType.ExpAst);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
            other.gameObject.CompareTag("Player"))
        {
            Hit();
            other.gameObject.SetActive(false);
        }
    }
}
