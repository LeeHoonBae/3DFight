using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Resource : MonoBehaviour
{
    [SerializeField]
    float P_HP;
    [SerializeField]
    float P_MaxHP;

    [SerializeField]
    float P_MP;
    [SerializeField]
    float P_MaxMP;

    [SerializeField]
    float P_Ammo;
    [SerializeField]
    float P_MaxAmmo;

    [SerializeField]
    Slider HpGauge;

    [SerializeField]
    Slider MpGauge;

    [SerializeField]
    Slider AmmoGauge;

    // Start is called before the first frame update
    void Start()
    {
        P_HP = P_MaxHP;
        P_MP = P_MaxMP;
        P_Ammo = P_MaxAmmo;
        HP_set();
        MP_set();
        Ammo_set();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int dam)
    {
        P_HP -= dam;
        HP_set();
    }

    void HP_set()
    {
        HpGauge.value = P_HP / P_MaxHP;
    }
    void MP_set()
    {
        MpGauge.value = P_MP / P_MaxMP;
    }
    void Ammo_set()
    {
        AmmoGauge.value = P_Ammo / P_MaxAmmo;
    }
}
