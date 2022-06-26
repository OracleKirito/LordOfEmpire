using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon 
{

    private GameObject point;
    private void Start()
    {
        point = this.gameObject.transform.parent.gameObject;
    }

    protected override void AttackProcess()
    {
        point.transform.localPosition = new Vector3(point.transform.localPosition.x, 0f, point.transform.localPosition.z+0.3f);
        base.AttackProcess();
        
    }
    protected override void AttackAction(float time)
    {       
         if (point.transform.rotation.x < 60 && point.transform.rotation.x >= 0)
        {
                point.transform.Rotate((60/time) * Time.deltaTime, 0, 0);     
        }

    }
    protected override IEnumerator Waittime( )
    {
        yield return new WaitForSeconds(AttackSpeed);
        IsAttacking = false;
        point.transform.localPosition = new Vector3(point.transform.localPosition.x, 0f, point.transform.localPosition.z-0.3f);
        point.transform.localRotation = Quaternion.identity;
    }

}
