using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_EnemyType1 : MonoBehaviour, IHitboxResponder
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    int damage = 1;
    [SerializeField]
    HitBox hitbox;

    float timer = 0;
    bool attack;

    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            animator.SetTrigger("Attack");
            hitbox.useResponder(this);
            timer = 0;
        }
    }

    public void CollisionedWith(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
            if (hurtbox != null)
                hurtbox.TakeDamage(damage);
            Debug.Log("hit player");
        }
    }

    public void StartAttack()
    {
        hitbox.EnableCheckCollision();
    }

    public void StopAttack()
    {
        hitbox.DisableCheckCollision();
    }
}
