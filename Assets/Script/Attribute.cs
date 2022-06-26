using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Attribute : MonoBehaviour
{
    [Flags]
    public enum characteristic
    {
        Light_armor=1,
        Mid_armor=2,
        Heavy_armor=4,
        warrier = 8,
        archer=16,
        knight=32,
    }
    public Collider _collider;
    public characteristic _characteristic;
    public string _name;
    public float NowHp;
    public float MaxHP;
    public float HpRegaintionRate;
    public float NowMp;
    public float MaxMp;
    public float MpRegaintionRate;
    public float PhysicsDefPercent;
    public float PhysicsDefNum;
    public float MagicDefPercent;
    public float MagicDefNum;
    public float MovementSpeed;
    public Image HPbar;
    public Image delayhpbar;
    void Start()
    {
        NowHp = MaxHP;
        NowMp = MaxMp;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayhpbar.fillAmount > HPbar.fillAmount)

        {
            //讓傷害量(紅色血條)逐漸追上當前血量
            delayhpbar.fillAmount += -0.05f * Time.deltaTime ;
        }
    }
    public void Takedamage(float damage)
    {
        NowHp -= damage;
        HPbar.fillAmount = (NowHp / MaxHP);
        if (NowHp <= 0)
        {
            Destroy(gameObject);

        }
    }
}
