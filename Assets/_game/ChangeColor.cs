using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum Herramienta
{
    Regadera,
    Guante,
    Semillas,
    Nabo,
    Radio
}

public class ChangeColor : MonoBehaviour
{
    public float timeToWait;
    public Herramienta miHerramienta;
    public TextMeshProUGUI info;
    public AudioClip[] music;
    public int idexSong;
    public Transform pivot;
    public Animator animator;
    public GameObject nabo;

    public void AlSalir()
    {
        //GetComponent<Renderer>().material.color = Color.red;
        StopCoroutine("PowerUP");
    }

    public void AlEntrar()
    {
        //GetComponent<Renderer>().material.color = Color.blue;
        StartCoroutine("PowerUP", timeToWait);
    }

    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    public IEnumerator PowerUP(float _t)
    {
        yield return new WaitForSeconds(_t);
        Debug.Log("Ya pasaron los 2 segundos");
        //GetComponent<Renderer>().material.color = Color.green;
        //info.text = "Herramienta: " + miHerramienta.ToString();
        if(miHerramienta == Herramienta.Radio)
        {
            ChangeSong();
        }
        if(miHerramienta == Herramienta.Nabo)
        {
            FarmNabo();
        }
        if(miHerramienta == Herramienta.Regadera)
        {
            MakeRefresh();
        }
    }

    public void ChangeSong()
    {
        idexSong = (idexSong < music.Length - 1  ? idexSong + 1 : 0);
        GetComponent<AudioSource>().clip = music[idexSong];
        GetComponent<AudioSource>().Play(0);
        miHerramienta = Herramienta.Semillas;
    }

    public void FarmNabo()
    {
        Comportamiento_Nabo temp = gameObject.GetComponent<Comportamiento_Nabo>();
        if(temp.mystate == NaboState.Ready)
        {
            GameObject go = Instantiate(nabo, pivot.position + Vector3.up * 2.0f, Quaternion.identity);
            temp.Cosechar();
        }
        miHerramienta = Herramienta.Semillas;
    }

    public void MakeRefresh()
    {
        animator.SetTrigger("Make");
        miHerramienta = Herramienta.Semillas;
    }
}
