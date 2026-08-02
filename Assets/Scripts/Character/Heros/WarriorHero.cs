using System;
using UnityEngine;
/*
The warrior is a master of attrition tactics. Resilient, he is the front line of any
army looking to control an objective and maintain said control. His shield provides defensive capabilities as well as
counter-measures to make the opponents think twice before engaging into battle

alter hero : Barbarian
*/
public class WarriorHero : BaseHero
{
    public void Awake()
    {
        SetBaseMaxHealth(150f);
        SetBaseSpeed(0.80f);
    }

    public override void Ability1()
    {
        //Swing : will deal damage in a frontal cone area. the center of the swing will deal more damage (Cleave like mechanic with reward for good aiming)
    }
    public override void Ability2()
    {
        //Block : raise your shield to gain bonus defensive stats 
    }

    public override void Ability3()
    {
        //shield bash : stuns a taget in a circle zone in front of the warrior
    }

    public override void Ability4()
    {
        //*Holdfast : gives bonus defence stats to nearby allies 
    }
}
