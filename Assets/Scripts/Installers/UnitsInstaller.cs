using SystemUnits;
using SystemUnits.Units.BulldozerUnit;
using SystemUnits.Units.ManufactoryUnit;
using SystemUnits.Units.TruckUnit;
using Zenject;

namespace Installers
{
    public sealed class UnitsInstaller : Installer<UnitsInstaller>
    {
        public override void InstallBindings() 
        {
            Container.BindInterfacesAndSelfTo<UnitsManger>().AsSingle();

            Container.BindInterfacesAndSelfTo<BulldozerFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ManufactoryFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<TruckFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<UnitsCreator>().AsSingle();
        }
    }
}