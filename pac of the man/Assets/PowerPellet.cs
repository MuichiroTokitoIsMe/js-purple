using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : pellet
{

    protected override void Eat()
    {
        base.Eat();

        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        foreach(GameObject ghpst in ghosts)
        {

        }
    }
}



