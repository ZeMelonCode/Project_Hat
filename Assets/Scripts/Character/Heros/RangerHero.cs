using UnityEngine;

/*
 The ranger's sharp eyes provide excellent precision strikes against her foes. She is quick on her feet and can provide 
 a tactical advantage to her team by scouting ahead. 
 */


public class RangerHero : BaseHero
{   
    public void Awake()
    {
     SetBaseMaxHealth(0.8f);
     SetBaseSpeed(1.2f);
    }
    
    public override void Ability1()
    {
     //shoot : shoots an arrow in a straight line, the longer she pulls the arrow, the more damage she does
    }
    public override void Ability2()
    {
     //*volley : gain a small burst of movement speed and fire 3 quick consecutive arrows
    }
    
    public override void Ability3()
    {
     //setup trap : place a bear trap on the ground that becomes invisible after a short period. any enemy that steps on it will be rooted and take bleed damage  
    }
    
    public override void Ability4()
    {
     //*Track : marks an enemy as prey, dealing bonus damage to the enemy until they die. If the buff is still active, a new target will be picked
    }
}
