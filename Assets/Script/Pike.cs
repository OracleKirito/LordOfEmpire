using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : Weapon 
{

    protected override void AttackAction(float time)
    {
        this.transform.Translate(0, 0, (1 / time) * Time.deltaTime);

    }
    protected override IEnumerator Waittime()
    {
        yield return new WaitForSeconds(AttackSpeed);
        IsAttacking = false;
        this.transform.localPosition = new Vector3(0.6f,0,0.5f);
    }
}
