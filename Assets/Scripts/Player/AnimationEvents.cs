using Unity.VisualScripting;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceStep;
    static public bool attackAnim;

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
        if(audioSourceStep != null)
        {
            audioSourceStep.Stop();
            audioSourceStep.PlayOneShot(BiomeDetector.currentWalkClip, 1);
        }
    }

    public void StopWalk()
    {
        if(audioSourceStep != null)
        {
            audioSourceStep.Stop();
        }
    }
}
