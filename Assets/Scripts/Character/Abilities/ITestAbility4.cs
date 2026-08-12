using UnityEngine;

public class ITestAbility4 : IBaseAbility
{
    public void activate()
    {
        Debug.Log("ITestAbility4 activated");
    }

    public void tick()
    {
        Debug.Log("ITestAbility4 ticked");
    }

    public bool canActivate()
    {
        Debug.Log("ITestAbility4 can activate");
        return true;
    }

    public float getRemainingCooldown()
    {
        float remainingCooldown = 0;
        canActivate();
        Debug.Log("ITestAbility4 Cooldown finished");
        return remainingCooldown;
    }
}
