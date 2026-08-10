using System;
using UnityEngine;

/*
 The Barbarian is a shock trooper style hero. His sharp axe provide sustained damage and debuffs.
 Any enemy unprepared by his relentless assault will not stand a chance.
 
 
 alter hero : Warrior
 */



public class BarbarianHero : BaseHero
{
    public void Awake()
    {
        SetBaseMaxHealth(120f);
        SetBaseSpeed(0.90f);
    }

    public override void Ability1()
    {
        //hack : deals damage in a small frontal cone, applying a bleeding debuff
    }
    public override void Ability2()
    {
        //axe throw : throws an ax in a front line, dealing small damage and slowing down the first target it hits
    }

    public override void Ability3()
    {
        //leap : leap towards a target, damaging anyone in the radius of the landing zone
    }

    public override void Ability4()
    {
        //BattleShout : gives bonus attack and speed stats to nearby allies 
    }
}
