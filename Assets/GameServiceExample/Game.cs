using UnityEngine;
using UnityEngine.SceneManagement;

namespace GSE
{
    /// <summary>
    ///     Game Service locator
    /// </summary>
    public static class Game
    {
        private static ServiceLocator _serviceLocator;
        
        public static AssetService Assets => Services.Get<AssetService>();
        public static HeroService Hero => Services.Get<HeroService>();

        public static ServiceLocator Services
        {
            get
            {
                if (_serviceLocator == null)
                {
                    _serviceLocator = new ServiceLocator();
                }

                return _serviceLocator;
            }
        }

    }
}