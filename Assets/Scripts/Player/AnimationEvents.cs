using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    static public bool attackAnim;
    static public bool hasStopped;

    public void IsAttacking()
    {
        attackAnim = true;
    }

    public void AttackingEnd()
    {
        attackAnim = false;
    }

    public void Walk()
    {
        hasStopped = false;
    }

    public void Stand()
    {
        hasStopped = true;
    }
}
