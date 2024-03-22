using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerSO",menuName ="ScriptableObject/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public float HP;
    public float RangeDamage;
    public float SpeedAttack;
}

