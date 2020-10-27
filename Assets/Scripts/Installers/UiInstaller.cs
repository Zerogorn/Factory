using SystemUi;
using SystemUi.Hud;
using SystemUi.Hud.Bottom;
using SystemUi.Hud.Top;
using SystemUi.Popups.Info;
using Zenject;

namespace Installers
{
    public sealed class UiInstaller : Installer<UiInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UiCanvasController>()
                     .FromComponentInNewPrefabResource("Ui/Canvas")
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<UiManger>().AsSingle();

            Container.BindInterfacesAndSelfTo<BottomHudFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<TopHudFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<InfoPopupFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<UiCreator>().AsSingle();
        }
    }
}