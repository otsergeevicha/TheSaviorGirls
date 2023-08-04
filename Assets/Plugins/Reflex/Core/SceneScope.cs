using Reflex.Logging;
using UnityEngine;

namespace Reflex.Core
{
    public sealed class SceneScope : MonoBehaviour
    {
        public void InstallBindings(ContainerDescriptor descriptor)
        {
            foreach (var nestedInstaller in GetComponentsInChildren<IInstaller>())
            {
                nestedInstaller.InstallBindings(descriptor);
            }
        }
    }
}