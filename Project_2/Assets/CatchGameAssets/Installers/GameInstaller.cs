using Catch;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Managers")] 
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private UIManager uIManager;
        [SerializeField] private AdManager adManager;
        
        [Header("Systems")] 
        [SerializeField] private SpawnSystem spawnSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private HealthSystem healthSystem;
        [SerializeField] private FillUpSystemUI fillUpSystemUI;
        
        [Header("Controllers")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private LevelController levelController;
        [SerializeField] private BackgroundController backgroundController;
        public override void InstallBindings()
        {
            Container.BindInstance(shopManager);
            Container.BindInstance(uIManager);
            Container.BindInstance(adManager);

            Container.BindInstance(spawnSystem);
            Container.BindInstance(scoreSystem);
            Container.BindInstance(healthSystem);
            Container.BindInstance(fillUpSystemUI);
            
            Container.BindInstance(playerController);
            Container.BindInstance(levelController);
            Container.BindInstance(backgroundController);
        }
    }
}