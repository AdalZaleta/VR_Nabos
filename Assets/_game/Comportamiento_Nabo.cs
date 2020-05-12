using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public enum NaboState
{
    Ready,
    NoReady,
}

public class Comportamiento_Nabo : MonoBehaviour
{
    public NaboState mystate;
    public TextMeshProUGUI nabos;
    public ParticleSystem pS;


    private void Start() 
    {
        mystate = NaboState.Ready;
    }

    public void Cosechar()
    {
        pS.Play();
        nabos.text = (int.Parse(nabos.text) + 1).ToString();
        gameObject.transform.transform.localScale = (new Vector3(0.001f, 0.001f, 0.01f));
        gameObject.transform.DOScale(new Vector3(120f, 120f, 120f), 15.0f).OnComplete(() => ChangeState());
        DOTween.Play(gameObject);
    }

    public void ChangeState()
    {
        mystate = NaboState.Ready;
    }
}
