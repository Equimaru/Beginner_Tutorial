using Catch;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [Header("Managers")] 
        [SerializeField] private LevelPlayAdsManager levelPlayAdsManager;
        [SerializeField] private AudioManager audioManager;
        public override void InstallBindings()
        {
            Container.BindInstance(levelPlayAdsManager);
            Container.BindInstance(audioManager);
        }
    }
}