using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;
using SRS.Extensions.Vector;

namespace SRS.LevelSystem
{
    public class XPAttractor : MonoBehaviour
    {
        private CharacterStats stats;

        private LinkedList<XPPickup> TrackedPickups = new LinkedList<XPPickup>();

        private void Start()
        {
            stats = GetComponent<CharacterStats>();
        }

        private void Update() 
        {
            float pickupRangeSquared = Mathf.Pow(stats["Pickup Range"], 2);

            foreach(XPPickup pickup in TrackedPickups)
            {
                if(VectorExtensions.SquareDistance(transform.position, pickup.transform.position) <= pickupRangeSquared)
                {
                    pickup.Target = transform;
                }
            }   
        }

        public void TrackPickup(XPPickup pickup)
        {
            TrackedPickups.AddFirst(pickup);
        }

        public void StopTracking(XPPickup pickup)
        {
            TrackedPickups.Remove(pickup);
        }
    }
}
