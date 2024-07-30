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
        
        [Header("Shop Items")]
        public ConsumableItem consItem;
        public NonConsumableItem nConsItem;
        public SubscriptionItem subItem;
        
        public override void InstallBindings()
        {
            Container.BindInstance(shopManagerView);
            Container.BindInterfacesAndSelfTo<PremiumShop>()
                .AsSingle()
                .WithArguments(consItem, nConsItem, subItem);
            Container.Bind<CoinShop>()
                .AsSingle();
            Container.Bind<ShopManager>()
                .AsSingle();
            Container.BindInstance(levelPlayAds);
            Container.BindInstance(audioManager);
        }
    }
}