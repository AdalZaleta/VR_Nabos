using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Particles : MonoBehaviour
{
    public ParticleSystem pS;
    
    public void TurnON()
    {
        pS.Play();
    }

    public void TurnOFF()
    {
        pS.Stop();
    }
}
