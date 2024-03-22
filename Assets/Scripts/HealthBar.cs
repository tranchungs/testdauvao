using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image currentHP;

    public void SetHP(float value)
    {
        currentHP.fillAmount = value;
    }
}
