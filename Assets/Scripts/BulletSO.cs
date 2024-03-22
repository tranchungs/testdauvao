using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObject/BulletSO")]
public class BulletSO : ScriptableObject
{
    public Transform prefab;
    public float speed;
    public float RangeDame;
}
