using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinateBrick : BrickParent
{
    

    public override void TakeDamage(int damageAmount)
    {
        DamageBrick();
    }

}
