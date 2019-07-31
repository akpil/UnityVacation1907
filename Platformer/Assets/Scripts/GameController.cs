using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Animator CameraAnim;
    private int currentStageNumber;

    // Start is called before the first frame update
    void Start()
    {
        currentStageNumber = 0;
    }

    public void AddStageNumber()
    {
        currentStageNumber++;
        CameraAnim.SetInteger(AnimHash.StageNumber, currentStageNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
