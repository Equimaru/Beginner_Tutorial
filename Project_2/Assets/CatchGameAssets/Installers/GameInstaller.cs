using System.Collections.Generic;
using Catch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Managers")] 
        [SerializeField] private ShopManager shopManager;
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
        
        [Header("InGameMenuManager Attributes")]
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private GameObject inGameMenuPanel;
        [SerializeField] private TextMeshProUGUI moneyAmountText;
        
        public override void InstallBindings()
        {
            Container.BindInstance(shopManager);
            Container.Bind<InGameMenuManager>()
                .AsSingle()
                .WithArguments(nextLevelButton, retryButton, menuButton, shopButton, inGameMenuPanel, moneyAmountText);
            Container.BindInstance(inGameAdsManager);

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
        }
    }
}