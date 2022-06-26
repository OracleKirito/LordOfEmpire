using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool Directivity;
    public float AttackPhysicsDamage;
    public float AttackMagicDamage;
    public float VsDamage_Light_armor;
    public float VsDamage_Mid_armor;
    public float VsDamage_Heavy_armor;
    public float VsDamage_Warrier;
    public float VsDamage_Archer;
    public float VsDamage_Knight;
    public GameObject Target = null;
    public float BulletMovement=3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (Directivity) {
            GameObject hit = other.gameObject;
            Attribute attribute = hit.GetComponent<Attribute>();
            attribute.Takedamage(AttackPhysicsDamage);
            Destroy(this.gameObject);
        }
        if (other.gameObject == Target)
        {
            
            Attribute attribute = Target.GetComponent<Attribute>();
            attribute.Takedamage(AttackPhysicsDamage);
            Destroy(this.gameObject);
        }
    }
    protected virtual void Move() {
        if (Target) {
            Vector3 pos = (Target.gameObject.transform.position - this.gameObject.transform.position);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, pos, 1f, 0f);
            this.gameObject.transform.rotation= Quaternion.LookRotation(newDir);
            this.gameObject.transform.Translate(0,0f, BulletMovement * Time.deltaTime);

        }
        else if (Directivity) {
            this.gameObject.transform.Translate( 0, 0, BulletMovement * Time.deltaTime);
        }

    }
    
}
