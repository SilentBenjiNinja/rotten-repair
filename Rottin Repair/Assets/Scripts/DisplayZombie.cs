using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collections;

public class DisplayZombie : MonoBehaviour
{
    public SpriteRenderer spr_head;
    public SpriteRenderer spr_body;
    public SpriteRenderer spr_armL;
    public SpriteRenderer spr_armR;
    public SpriteRenderer spr_legL;
    public SpriteRenderer spr_legR;

    public void Show(ZombieSetup setup)
    {
        spr_head.sprite = setup.parts[Parts.Head].sprite;
        spr_body.sprite = setup.parts[Parts.Body].sprite;
        spr_armL.sprite = setup.parts[Parts.ArmL].sprite;
        spr_armR.sprite = setup.parts[Parts.ArmR].sprite;
        spr_legL.sprite = setup.parts[Parts.LegL].sprite;
        spr_legR.sprite = setup.parts[Parts.LegR].sprite;
    }
}
