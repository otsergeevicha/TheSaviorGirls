using Plugins.MonoCache;
using Reflex.Core;

namespace Reflex
{
    public class GreetInstaller : MonoCache, IInstaller
    {
        public void InstallBindings(ContainerDescriptor descriptor)
        {
            descriptor.AddInstance("World");
            descriptor.AddSingleton(typeof(Greeter), typeof(IStartable));
        }
    }
}