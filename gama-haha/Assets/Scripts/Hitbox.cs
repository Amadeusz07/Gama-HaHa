using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attack attack = collision.GetComponent<Attack>();
        if (attack != null)
        {
            GetComponentInParent<Health>().DealDamage(attack);
            if (collision.GetComponent<Blast>() != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
