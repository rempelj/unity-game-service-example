using System.Collections.Generic;
using UnityEngine;

namespace GSE
{
    public class HeroService : GameService
    {
        public int maxHp;
        public int damageTaken;

        private Hero hero;
        private List<AbilityController> abilities = new List<AbilityController>();

        public override void OnStart()
        {
            base.OnStart();
            hero = GameObject.Instantiate(Game.Assets.GetPrefab<Hero>());

            var abilitiesDatas = new List<AbilityData>
            {
                Game.Assets.GetData<AbilityData>("FireballAbility"),
                Game.Assets.GetData<AbilityData>("HealAbility")
            };

            foreach (var abilityData in abilitiesDatas)
            {
                var controller = GameObject.Instantiate(abilityData.prefab);
                abilities.Add(controller);
            }
        }

        public void ActivateAbility(int idx)
        {
            abilities[idx].ActivateAbility();
        }
    }
}