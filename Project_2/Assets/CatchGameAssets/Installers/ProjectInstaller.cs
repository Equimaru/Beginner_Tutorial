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
        public override void InstallBindings()
        {
            Container.BindInstance(levelPlayAds);
            Container.BindInstance(audioManager);
        }
    }
}