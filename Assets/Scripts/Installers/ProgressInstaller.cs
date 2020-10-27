using SystemProgress;
using Zenject;

namespace Installers
{
    public sealed class ProgressInstaller : Installer<ProgressInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LoadPlayerPrefs>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveToPlayerPrefs>().AsSingle();
        }
    }
}