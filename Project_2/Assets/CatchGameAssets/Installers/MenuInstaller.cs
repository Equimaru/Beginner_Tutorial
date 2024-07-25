using Catch;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MenuInstaller : MonoInstaller
    {
        [Header("Managers")] 
        [SerializeField] private InMenuAdsManager inMenuAdsManager;
        [SerializeField] private MainMenuManager mainMenuManager;

        public override void InstallBindings()
        {
            Container.BindInstance(inMenuAdsManager);
            Container.BindInstance(mainMenuManager);
        }
    }
}

