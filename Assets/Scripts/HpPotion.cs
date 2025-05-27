using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu (fileName = "Hp Potion", menuName = "Scriptable Objects/Hp Potion", order =1)]
public class HpPoint : ItemData
{
    public int Value;


    public override void Use(PlayerController2 controller)
    {
        controller.RecoveryHp(Value);
    }
}
