using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.Combat
{
    public abstract class Weapon : MonoBehaviour
	{
		[SerializeField] private WeaponData weaponData;

		public virtual void Attack(StatContainer attackStats)
		{

		}
	}
}