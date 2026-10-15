
using UnityEngine;

public interface IDamagable
{
    void GetDamage(float damage, DamageType dtype = DamageType.Pure);
}

public enum DamageType
{
    Physical,
    Pure,
    Saint,
    Fire,
    Frozen,
    Electro
}

public interface IShootModifier
{
    void OnShoot(MagicStuff weapon, Vector3 dir);
}

public interface IProjectileModifier
{
    void OnProjectileSpawn(MagicProjectile proj); 
}

