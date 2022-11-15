# unity-game-service-example
Service Locator pattern example for Unity. With this you can do things like for example `Game.Hero.TakeDamage()` or `Game.Assets.GetPrefab()`, etc.

This is similar to the Singleton pattern, but a bit cleaner. The GameInitializer is a bit safer than having lazy instantiated singletons, because you can create and set up the services contextually. For example, if you have a test environment, you can create a custom initializer that injects test data into the services, or creates fake services.
