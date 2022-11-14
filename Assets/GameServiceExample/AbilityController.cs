using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSE
{
    public abstract class AbilityController : MonoBehaviour
    {
        protected AbilityData abilityData;
        
        public void Setup(AbilityData abilityData)
        {
            this.abilityData = abilityData;
        }
        
        public abstract void ActivateAbility();

       
    }
}
