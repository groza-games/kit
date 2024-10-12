#if UNITY_EDITOR
using GrozaGames.Kit.Archetypes.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace GrozaGames.Kit.Archetypes.Editor
{
    public class ArchetypeCollectionEditorTool
    {
        [MenuItem("GrozaGames/Archetypes/Update Archetypes %&l")]
        public static void FillNewElements()
        {
            var archetypeCollection = AssetDatabaseUtils.FindObject<ArchetypeCollection>();
            archetypeCollection.FillWithNewElements();
            EditorUtility.SetDirty(archetypeCollection);
            Debug.Log("Archetypes updated");
        }
    }
}
#endif