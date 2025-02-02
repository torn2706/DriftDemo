using Services.Input;
using Zenject;
using UnityEngine;
using Cinemachine;
using Services.Camera;
using Services;
using Logic;

namespace Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private HudMediator _hudMediator;
        [SerializeField] private StartPoint _startPoint;
        public override void InstallBindings()
        {
            InstallInfrastructureBindings();
            InstallInputBindings();
            InstallCameraBindings();
            InstallHudBindings();
            InstallServiceBindings();
            InstallLocationBindings();
        }

        private void InstallInputBindings()
        {
            Container.Bind<PlayerInput>()
                .To<PlayerInput>()
                .AsSingle();

            Container.BindInterfacesTo<InputService>()
                .AsSingle();
        }

        private void InstallInfrastructureBindings()
        {
            Container.Bind<IGameplayFactory>()
                .To<GameplayFactory>()
                .AsSingle();
        }

        private void InstallCameraBindings()
        {
            Container.Bind<CinemachineVirtualCamera>()
                .FromInstance(_virtualCamera)
                .AsSingle();

            Container.Bind<ICameraFollowService>()
                .To<CameraFollowService>()
                .AsSingle();
        }

        private void InstallHudBindings()
        {
            Container.Bind<HudMediator>()
                .FromInstance(_hudMediator) 
                .AsSingle();
        }

        private void InstallServiceBindings()
        {
            Container.BindInterfacesTo<ScoreService>()
                .AsSingle();
        }

        private void InstallLocationBindings()
        {
            Container.Bind<StartPoint>()
                .FromInstance(_startPoint) 
                .AsSingle();
        }
    }
}

