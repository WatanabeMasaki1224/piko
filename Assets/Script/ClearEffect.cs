using UnityEngine;

public class ClearEffect : MonoBehaviour
{
    public ParticleSystem leftConfetti;
    public ParticleSystem rightConfetti;

    public void PlayConfetti()
    {
        if (leftConfetti != null)
        {
            leftConfetti.Play();
        }

        if (rightConfetti != null)
        {
            rightConfetti.Play();
        }
    }
}
