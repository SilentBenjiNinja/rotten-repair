using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource src_salvage;
    public AudioSource src_ship;
    public AudioSource src_win;
    public AudioSource src_remove;
    public AudioSource src_ambient;

    public void PlaySound(string sound) {
        switch (sound)
        {
            case "salvage":
                src_salvage.Play();
                break;
            case "ship":
                src_ship.Play();
                break;
            case "win":
                src_win.Play();
                break;
            case "remove":
                src_remove.Play();
                break;
            default:
                break;
        }
    }
}
