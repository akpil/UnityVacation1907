using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimHash
{
    public static readonly int Walk = Animator.StringToHash("IsWalk");
    public static readonly int Melee = Animator.StringToHash("IsMelee");
    public static readonly int Jump = Animator.StringToHash("Jump");
    public static readonly int StageNumber = Animator.StringToHash("ScreenNumber");
    public static readonly int Dead = Animator.StringToHash("IsDead");
}
