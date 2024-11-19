using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GrozaGames.Kit
{
    public class CenterTransformToChildren : MonoBehaviour
    {
        [SerializeField] private Vector3 _centerRatio = new Vector3(0.5f, 0.5f, 0.5f);
        [SerializeField] private Vector3 _offset = new Vector3(0, 0, 0);
        [SerializeField] private bool _useRendererBounds = true;

        [Button]
        private void Center()
        {
            var result = transform.position;
            
            if (_useRendererBounds)
            {
                var renderers = GetComponentsInChildren<Renderer>().ToList();
                var bounds = renderers.First().bounds;
                foreach (var r in renderers) 
                    bounds.Encapsulate(r.bounds);
                result = GetBoundsPivot(bounds) + _offset;
            }
            else
            {
                var children = GetComponentsInChildren<Transform>().ToList();
                children.Remove(transform);
                var bounds = new Bounds(children.First().position, Vector3.zero);
                foreach (var child in children) 
                    bounds.Encapsulate(child.position);
                result = GetBoundsPivot(bounds) + _offset;
            }
            
            var topLevel = GetComponentsInChildren<Transform>().Where(child => child.parent == transform).ToList();

            var tempParent = new GameObject("TempParent").transform;
            tempParent.position = transform.position;

            foreach (var child in topLevel) 
                child.SetParent(tempParent, true);
            
            transform.position = result;
            
            foreach (var child in topLevel) 
                child.SetParent(transform, true);
            
            DestroyImmediate(tempParent.gameObject);
        }

        private Vector3 GetBoundsPivot(Bounds bounds)
        {
            return new Vector3(
                Mathf.Lerp(bounds.min.x, bounds.max.x, _centerRatio.x),
                Mathf.Lerp(bounds.min.y, bounds.max.y, _centerRatio.y),
                Mathf.Lerp(bounds.min.z, bounds.max.z, _centerRatio.z)
            );
        }
    }
}