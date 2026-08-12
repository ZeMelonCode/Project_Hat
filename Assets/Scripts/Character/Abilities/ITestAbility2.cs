using UnityEngine;

public class ITestAbility2 : IBaseAbility
{
    public void activate()
    {
        Debug.Log("ITestAbility2 activated");
    }

    public void tick()
    {
        Debug.Log("ITestAbility2 ticked");
    }

    public bool canActivate()
    {
        Debug.Log("ITestAbility2 can activate");
        return true;
    }

    public float getRemainingCooldown()
    {
        float remainingCooldown = 0;
        canActivate();
        Debug.Log("ITestAbility2 Cooldown finished");
        return remainingCooldown;
    }
}
