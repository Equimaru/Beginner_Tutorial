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
        [SerializeField] private ShopManagerBoot shopManagerBoot;
        public override void InstallBindings()
        {
            Container.BindInstance(levelPlayAds);
            Container.BindInstance(audioManager);
            Container.Bind<ShopManager>()
                .AsSingle()
                .WithArguments(shopManagerBoot);
        }
    }
}