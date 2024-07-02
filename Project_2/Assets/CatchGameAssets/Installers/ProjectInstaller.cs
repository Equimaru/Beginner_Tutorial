using Catch;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LevelPlayAdsManager _levelPlayAdsManager;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_levelPlayAdsManager);
        }
    }
}