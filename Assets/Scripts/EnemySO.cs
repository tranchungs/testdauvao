using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObject/EnemySO")]
public class EnemySO : ScriptableObject
{
    public float HP;
    public float moveSpeed;
    public float distance;
}
