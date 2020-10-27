using Models;
using Zenject;

namespace Installers
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DesignModel>().AsSingle();
        }
    }
}