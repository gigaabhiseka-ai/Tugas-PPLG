using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected int health = 100;

    // Virtual method (Polymorphism)
    public virtual void Attack()
    {
        Debug.Log("Enemy dasar menyerang!");
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " terkena damage! Sisa HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " mati!");
        Destroy(gameObject);
    }
}
