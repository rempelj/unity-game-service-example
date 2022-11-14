using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSE
{
    public class Hero : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Game.Hero.ActivateAbility(0);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Game.Hero.ActivateAbility(1);
            }
        }
    }
}
