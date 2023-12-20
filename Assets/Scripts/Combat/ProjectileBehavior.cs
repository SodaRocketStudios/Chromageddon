using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.Combat
{
    [CreateAssetMenu(fileName = " New Projectile Behavior", menuName = "Combat/Attack Behavior/Projectile Behavior")]
    public class ProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;
    }
}