using Catch;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [Header("Managers")] 
        [SerializeField] private LevelPlayAds levelPlayAds;
        [SerializeField] private AudioManager audioManager;
        
        [Header("Boot Menu")]
        [SerializeField] private ShopManagerView shopManagerView;
        
        public override void InstallBindings()
        {
            Container.BindInstance(shopManagerView);
            Container.Bind<ShopManager>()
                .AsSingle()
                .WithArguments(shopManagerView);
            Container.Bind<PremiumShop>().AsSingle();
            Container.Bind<CoinShop>().AsSingle();
            Container.BindInstance(levelPlayAds);
            Container.BindInstance(audioManager);
        }
    }
}