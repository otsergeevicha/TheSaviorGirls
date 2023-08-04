using Plugins.MonoCache;
using Reflex.Core;
using Services.Assets;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;

namespace Reflex
{
    public class MainSceneInstaller : MonoCache, IInstaller
    {
        public void InstallBindings(ContainerDescriptor descriptor) => 
            descriptor.OnContainerBuilt += LoadLevel;

        private void LoadLevel(Container container)
        {
            ISave save = container.Single<ISave>();
            IInputService input = container.Single<IInputService>();
            IAssetsProvider assetsProvider = container.Single<IAssetsProvider>();
            IWallet wallet = container.Single<IWallet>();
            IGameFactory gameFactory = container.Single<IGameFactory>();

            wallet.Construct(save);
            gameFactory.Construct(assetsProvider);

            print("здесь создается/инстантиируется/инжектируется игра");
        }
    }
}