using Services.Assets;
using Services.Factory;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssetsProvider _assetsProvider;
        
        public void Construct(IAssetsProvider assetsProvider) => 
            _assetsProvider = assetsProvider;
    }
}