using System;
using UnityEngine;

namespace GrozaGames.MeshCombining
{
    public class MeshCombinerWrapper : MonoBehaviour
    {
        private void Start()
        {
            var meshCombiner = gameObject.AddComponent<MeshCombiner>();
            meshCombiner.CombineMeshes(false);
        }
    }
}