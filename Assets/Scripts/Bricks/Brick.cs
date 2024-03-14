using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : BrickParent
{
    
    [SerializeField] Transform explosion;
    [SerializeField] Transform content;

    public override void TakeDamage(int damageAmount)
    {
        print("taking damage in child");

        hitPoints -= damageAmount;

        if (hitPoints <= 0)
        {
            ApplyBrickEffect();
            DestroyBrick();
        }
        else
        {
            DamageBrick();
        }

        base.TakeDamage(damageAmount);
    }

    void ApplyBrickEffect()
    {
        if (Random.Range(0f, 1f) > .7)
        {
            Instantiate(content, transform.position, Quaternion.identity);
        }
    }

    void DestroyBrick()
    {
        //GameManager.i.UpdateNumberOfBricks();
        GameManager.i.UpdateNumberOfBricks();
        GameManager.i.UpdateScore(pointValue);
        var go = Instantiate(explosion, transform.position, transform.rotation);
        
        Destroy(go.gameObject,2.25f );
        Destroy(gameObject);
    }
}
