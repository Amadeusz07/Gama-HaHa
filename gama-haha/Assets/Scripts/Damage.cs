using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    public List<int> damagePerPunchCombo;
    [SerializeField]
    public List<float> pushBackPowerPerPunchCombo;
    [SerializeField]
    public int blastDamage = 25;
    [SerializeField]
    public float blastPushBackPower = 1f;
}
