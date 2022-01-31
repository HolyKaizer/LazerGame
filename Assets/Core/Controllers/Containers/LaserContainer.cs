using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public sealed class LaserContainer : BaseContainer, ILaserContainer
    {
        [SerializeField] private LineRenderer _lineRenderer;

        private int _enemyLayer; 
        private int _wallsLayer; 
        
        protected override void OnAwake()
        {
            base.OnAwake();
            _enemyLayer = LayerMask.NameToLayer(Consts.Enemy); 
            _wallsLayer = LayerMask.NameToLayer(Consts.Walls); 
        }

        public void ProcessLaserShot(Vector3 origin, Vector3 direction, ILaserComponent component, HitInfo info)
        {
            var distance = component.LaserDistance;
            var result = Physics2D.Raycast(origin, direction, distance, _enemyLayer | _wallsLayer);
            if(result.collider != null)
            {
                var destinationPoint = result.point;
                _lineRenderer.SetPosition(0, origin);
                _lineRenderer.SetPosition(1, destinationPoint);
                ProceedHit(result.collider.gameObject, info);
            }
            else
            {
                _lineRenderer.SetPosition(0, origin);
                _lineRenderer.SetPosition(1, origin + (direction * distance));
            } 
        }
        
        private void ProceedHit(GameObject colliderObj, HitInfo info)
        {
            if (colliderObj.TryGetComponent<IHitContainer>(out var hitContainer))
            {
                hitContainer.HandelHit(info);
            }
        }
    }
}