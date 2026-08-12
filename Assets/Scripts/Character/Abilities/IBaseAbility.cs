using UnityEngine;

public interface IBaseAbility
{
    // Activate starts the ability logic
    public void activate();
    
    // anything related to overtime , including cooldown
    public void tick();
    
    // a simple bool to check if the player can use the ability (on cooldown, stunned, silenced, etc)
    public bool canActivate();
    
    // return the current cooldown 
    public float getRemainingCooldown();
}
