using Services.Assets;

namespace Services.Factory
{
    public interface IGameFactory
    {
        void Construct(IAssetsProvider assetsProvider);
    }
}