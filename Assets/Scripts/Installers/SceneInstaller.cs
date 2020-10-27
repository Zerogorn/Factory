using Models;
using Zenject;

namespace Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DesignModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<DesignModelHandler>().AsSingle();

            UnitsInstaller.Install(Container);
            UiInstaller.Install(Container);
            ProgressInstaller.Install(Container);
        }
    }
}