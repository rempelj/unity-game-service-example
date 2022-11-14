using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSE
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameServiceExample/AbilityData", order = 1)]
    public class AbilityData : ScriptableObject
    {
        public AbilityController prefab;
    }
}
