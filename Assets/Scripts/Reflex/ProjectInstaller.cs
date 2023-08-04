using Plugins.MonoCache;
using Reflex.Core;

namespace Reflex
{
    public class ProjectInstaller : MonoCache, IInstaller
    {
        public void InstallBindings(ContainerDescriptor descriptor) => 
            descriptor.AddInstance("Hello");
    }
}