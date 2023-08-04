using Infrastructure.Assets;
using Infrastructure.Factory;
using Infrastructure.SaveLoadLogic.Base;
using Plugins.MonoCache;
using Reflex.Core;
using Services.Assets;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;
using WalletLogic;

namespace Reflex
{
    public class ProjectInstaller : MonoCache, IInstaller
    {
        public void InstallBindings(ContainerDescriptor descriptor)
        {
            descriptor.AddInstance(new SaveLoad(), typeof(SaveLoad), typeof(ISave));
            descriptor.AddInstance(new InputService(), typeof(InputService), typeof(IInputService));
            descriptor.AddInstance(new AssetsProvider(), typeof(AssetsProvider), typeof(IAssetsProvider));
            descriptor.AddInstance(new Wallet(), typeof(Wallet), typeof(IWallet));
            descriptor.AddInstance(new GameFactory(), typeof(GameFactory), typeof(IGameFactory));
        }
    }
}