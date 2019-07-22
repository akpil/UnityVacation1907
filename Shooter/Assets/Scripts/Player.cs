using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody mRB;

    public Transform BoltPos;
    public BoltPool boltPool;

    public float Speed;
    public float Tilt;

    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float FireRate;
    private float currentFireTimer;
    private EffectPool effect;
    private GameController gameController;
    private SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        currentFireTimer = 0;
        mRB = GetComponent<Rigidbody>();
        effect = GameObject.FindGameObjectWithTag("EffectPool").GetComponent<EffectPool>();
        GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
        gameController = controlObj.GetComponent<GameController>();
        soundController = gameController.GetSoundController();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal * Speed, 0, vertical * Speed);
        mRB.velocity = velocity;

        transform.rotation = Quaternion.Euler(0, 0, horizontal * -Tilt);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX),
                                          0,
                                         Mathf.Clamp(transform.position.z, MinZ, MaxZ));

        currentFireTimer = currentFireTimer - Time.deltaTime;

        if (Input.GetButton("Fire1") && currentFireTimer <= 0)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = BoltPos.position;
            currentFireTimer = FireRate;
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Timer newEffect = effect.GetFromPool((int)eEffectType.PlayerExp);
        newEffect.transform.position = transform.position;
        soundController.PlayEffectSound((int)eEffectSoundType.ExpPlayer);
        Debug.Log("GameOver");
    }
}
