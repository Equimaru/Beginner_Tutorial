using UnityEngine;

public class WeaponTest : MonoBehaviour
{
    public RangeWeapon crossbow;
    
    private MeleeWeapon _knife;
    private MeleeWeapon _longSword;
    void Start()
    {
        RangeWeapon bow = new RangeWeapon
        {
            name = "Bow",
            damage = 9,
            attackSpeed = 0.5f,
            weight = 2f
        };
        Debug.Log("New weapon created:" +
                  $"\nName: {bow.name}" +
                  $"\nDamage: {bow.damage}" +
                  $"\nAttack speed: {bow.attackSpeed}" +
                  $"\nWeight: {bow.weight}");
        
        
        _knife = new MeleeWeapon("Knife", 5, 2f, 0.5f);
        _longSword = new MeleeWeapon("Long sword", -11, 1f, 1.5f);

        MeleeWeapon stick = new MeleeWeapon();
    }
}
