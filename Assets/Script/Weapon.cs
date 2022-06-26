using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float actiontime = 0;
    public bool Directivity;
    public GameObject m_bullet=null;
    public Vector3 m_bulletborn;
    public float AttackPhysicsDamage;
    public float AttackMagicDamage;
    public float AttackSpeed;
    public float period;
    public bool CanAttack;
    public bool IsAttacking=false;
    public float AttackDistance;
    public float VsDamage_Light_armor;
    public float VsDamage_Mid_armor;
    public float VsDamage_Heavy_armor;
    public float VsDamage_Warrier;
    public float VsDamage_Archer;
    public float VsDamage_Knight;
    public GameObject Target = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  protected virtual void Update()
    {
        if (CanAttack == false)
            period += Time.deltaTime;
        if (period >= AttackSpeed)
        {
            period = 0;
            CanAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && CanAttack == true)
        {
            AttackProcess();
            CanAttack = false;
        }
        if (IsAttacking) {
            AttackAction(AttackSpeed);
        }
    }
    protected virtual void AttackProcess() {
        if (m_bullet == null)
        {
            IsAttacking = true;
            StartCoroutine(Waittime());          
        }
        else {
            SetBullet();
        }
    }
    protected virtual  IEnumerator Waittime() {
      yield return  new WaitForSeconds(actiontime);
        IsAttacking = false;
    }
    protected virtual void AttackAction(float time) { }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        AttackCheck(collider);
        
    }
    protected virtual void OnTriggerStay(Collider collider)
    {
        AttackCheck(collider);
    }
    protected virtual void AttackCheck(Collider collider) {
        if (IsAttacking)
        {
            IsAttacking = false;
            GameObject hit = collider.gameObject;
            Attribute attribute = hit.GetComponent<Attribute>();
            attribute.Takedamage(AttackPhysicsDamage);
        }
    }
    protected virtual void SetBullet()
    {
        GameObject g_bullet = Instantiate(m_bullet) as GameObject;
        g_bullet.transform.SetParent(transform, false);
        g_bullet.transform.localPosition =m_bulletborn;
        Bullet bullet = g_bullet.GetComponent<Bullet>();
        bullet.Directivity = Directivity;
        bullet.AttackPhysicsDamage=AttackPhysicsDamage;
        bullet.AttackMagicDamage=AttackMagicDamage;
        bullet.VsDamage_Light_armor = VsDamage_Light_armor;
        bullet.VsDamage_Mid_armor = VsDamage_Mid_armor;
        bullet.VsDamage_Heavy_armor = VsDamage_Heavy_armor;
        bullet.VsDamage_Warrier = VsDamage_Warrier;
        bullet.VsDamage_Archer = VsDamage_Archer;
        bullet.VsDamage_Knight = VsDamage_Knight;
        bullet.Target = Target;
    }
}
