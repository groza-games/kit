using GrozaGames.Kit.Archetypes.ScriptableObjects;
using GrozaGames.Kit.Archetypes.Services;
using UnityEngine;
using Zenject;

namespace GrozaGames.Kit.Archetypes
{
    public class ArchetypesInstaller : MonoInstaller
    {
        [SerializeField] private ArchetypeCollection _archetypeCollection;
        
        public override void InstallBindings()
        {
            if (_archetypeCollection)
                Container.BindScriptableObject(_archetypeCollection);
            Container.BindService<ArchetypeService>();
        }
    }
}