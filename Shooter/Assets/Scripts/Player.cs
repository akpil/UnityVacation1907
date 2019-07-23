using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody mRB;

    public Bomb bomb;

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

    public GameObject ChargingObj;
    public float ChargeMaxValue;
    private float currentChargeValue;

    private EffectPool effect;
    private GameController gameController;
    private SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        currentFireTimer = 0;
        currentChargeValue = 0;
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

        if (Input.GetButton("Fire3"))
        {
            ChargingObj.SetActive(true);
            currentChargeValue += Time.deltaTime;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            if (currentChargeValue >= ChargeMaxValue)
            {
                StartCoroutine(ChargingFire(20));
            }
            currentChargeValue = 0;
            ChargingObj.SetActive(false);
        }
        else if (Input.GetButton("Fire1") && currentFireTimer <= 0)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = BoltPos.position;
            currentFireTimer = FireRate;
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
        }

        if (Input.GetButton("Fire2") && !bomb.gameObject.activeInHierarchy)
        {
            bomb.transform.position = BoltPos.position;
            bomb.gameObject.SetActive(true);
        }
    }

    private IEnumerator ChargingFire(int boltCount)
    {
        int count = boltCount;
        while (count > 0)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = BoltPos.position;
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
            count--;
            yield return new WaitForFixedUpdate();
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
        gameController.GameOver();
    }
}
