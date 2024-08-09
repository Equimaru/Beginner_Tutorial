using System.Collections.Generic;
using Catch;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Managers")] 
        [SerializeField] private InGameAdsManager inGameAdsManager;
        
        [Header("Systems")] 
        [SerializeField] private SpawnSystem spawnSystem;
        [SerializeField] private HealthSystem healthSystem;
        
        [Header("Controllers")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private BackgroundController backgroundController;
        
        [Header("FillUpSystem Attributes")]
        [SerializeField] private Image minFillUpMarker;
        [SerializeField] private Image currentFillUpMarker;

        [Header("LevelController Attributes")]
        [SerializeField] private List<LevelSettings> levelSettings;

        [Header("View")] 
        [SerializeField] private InGameMenuManagerView inGameMenuManagerView;

        [Header("Factories")] 
        [SerializeField] private List<GameObject> goodItemPrefabs;
        [SerializeField] private List<GameObject> badItemPrefabs;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InGameMenuManager>()
                .AsSingle()
                .WithArguments(inGameMenuManagerView);
            Container.BindInstance(inGameAdsManager);

            Container.Bind<PauseSystem>().AsSingle();
            Container.BindInstance(spawnSystem);
            Container.Bind<ScoreSystem>().AsSingle();
            Container.BindInstance(healthSystem);
            Container.Bind<FillUpSystemUI>()
                .AsSingle()
                .WithArguments(minFillUpMarker, currentFillUpMarker);
            
            Container.BindInstance(playerController);
            Container.Bind<LevelController>()
                .AsSingle()
                .WithArguments(levelSettings);
            Container.BindInstance(backgroundController);

            Container.BindFactory<Transform, Vector3, GoodItem, GoodItem.Factory>().FromFactory<GoodItemFactory>();
            Container.BindFactory<Transform, Vector3, BadItem, BadItem.Factory>().FromFactory<BadItemFactory>();
            Container.Bind<GoodItemFactorySettings>()
                .AsSingle()
                .WithArguments(goodItemPrefabs);
            Container.Bind<BadItemFactorySettings>()
                .AsSingle()
                .WithArguments(badItemPrefabs);
        }
    }
}