using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GrozaGames
{
    [RequireComponent(typeof(Context))]
    public class ZenjectAutoSetup : MonoBehaviour
    {
        [SerializeField] private Context _context;

        private void Reset()
        {
            _context = GetComponent<Context>();
        }
        
        [Button("Setup Installers")]
        private void SetInstallers()
        {
            SortAllTransformChildrenByName();
            var installers = GetComponentsInChildren<MonoInstaller>();
            _context.Installers = installers;
        }

        [Button("Check Project Installers")]
        private void CheckInstallersInProject()
        {
            var contextInstallers = GetComponentsInChildren<MonoInstaller>();
            var allInstallers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes().Where(t => t.IsSubclassOf(typeof(MonoInstaller))));
            foreach (var installer in allInstallers)
            {
                if (installer.IsAbstract || installer == typeof(MonoInstaller) || installer == typeof(MonoInstaller<>))
                    continue;

                if (contextInstallers.All(x => x.GetType() != installer)) 
                    Debug.LogError($"Installer {installer.Name} not found in context");
            }
        }

        [Button("Add All Project Installers")]
        private void AddInstallersFromProject()
        {
            var contextInstallers = GetComponentsInChildren<MonoInstaller>();
            var allInstallers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes().Where(t => t.IsSubclassOf(typeof(MonoInstaller))));
            foreach (var installer in allInstallers)
            {
                if (installer.IsAbstract || installer == typeof(MonoInstaller) || installer == typeof(MonoInstaller<>))
                    continue;

                if (contextInstallers.All(x => x.GetType() != installer))
                {
                    var installerGameObject = new GameObject(installer.Name);
                    installerGameObject.transform.SetParent(transform);
                    installerGameObject.AddComponent(installer);
                }
            }
            
            SetInstallers();
        }
        
        private void SortAllTransformChildrenByName()
        {
            var list = transform.Cast<Transform>().ToList();
            foreach (var child in list.OrderByDescending(x => x.name))
            {
                child.gameObject.name = child.gameObject.name.Replace("_Installer", "").Replace("Installer", "");
                child.SetSiblingIndex(0);
            }
        }
    }
}