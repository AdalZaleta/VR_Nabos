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
    }

    public void ChangeSong()
    {
        Debug.Log(music.Length.ToString());
        idexSong = (idexSong < music.Length - 1  ? idexSong + 1 : 0);
        GetComponent<AudioSource>().clip = music[idexSong];
        Debug.Log("Rola actual: " + music[idexSong].name);
        GetComponent<AudioSource>().Play(0);
    }
}
