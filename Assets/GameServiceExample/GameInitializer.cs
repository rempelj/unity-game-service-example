using System.Collections.Generic;
using UnityEngine;

namespace GSE
{
    [DefaultExecutionOrder(-1)]
    public class GameInitializer : MonoBehaviour
    {
        public AssetServiceConfig assetConfig;

        private List<GameService> services;

        private void Awake()
        {
            services = new List<GameService>();

            Register(new AssetService(assetConfig));
            Register(new HeroService());

            foreach (var service in services)
            {
                service.OnAwake();
            }
        }

        private void Start()
        {
            foreach (var service in services)
            {
                service.OnStart();
            }
        }

        private void Register<T>(T service) where T : GameService
        {
            Game.Services.Register(service);
            services.Add(service);
        }
    }
}