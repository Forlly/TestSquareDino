using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Sprite;
    public string Description;
    public int Damage;
    public WeaponType WeaponType;
    public float speed;
    public float lifeTime;
    public float reloadTime;
    public bool readyToShot;
}

public enum WeaponType
{
    gun,
    machineGun
}
