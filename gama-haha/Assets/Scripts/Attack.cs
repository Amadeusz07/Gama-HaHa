using UnityEngine;

public class Attack : MonoBehaviour
{
    private int damage = 15;
    private float pushBackPower = 1f;

    public void SetNextAttack(int damage, float pushBackPower)
    {
        this.damage = damage;
        this.pushBackPower = pushBackPower;
    }

    public int GetDamage() => damage;
    public float GetPushBackPower() => pushBackPower;
}
