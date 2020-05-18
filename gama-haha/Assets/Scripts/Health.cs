using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int HP = 100;
    [SerializeField]
    private int currentHP = 100;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DealDamage(Attack attack)
    {
        Debug.Log("Got damage from " + attack.GetDamage() + " | " + attack.GetPushBackPower());
        _animator.SetTrigger("hurt");
        currentHP -= attack.GetDamage();
        if (attack.GetPushBackPower() > 0)
        {
            float sign = Mathf.Sign(this.gameObject.transform.localScale.x);
            Vector2 attackVelocity = new Vector2((-1f * sign) * attack.GetPushBackPower(), 0f);
            _rigidbody2D.velocity += attackVelocity;
        }
    }

    public void Heal(int healing)
    {
        int health = currentHP + healing;
        if (health > HP)
        {
            currentHP = HP;
        }
        else
        {
            currentHP = health;
        }
    }

    public void RestoreHeath()
    {
        currentHP = HP;
    }
}

