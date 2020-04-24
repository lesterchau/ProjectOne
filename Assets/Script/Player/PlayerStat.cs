using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Equipment[] equipments = new Equipment[System.Enum.GetValues(typeof(EquipmentSlot)).Length];

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnValidate()
    {
        int equipmentMaxLength = System.Enum.GetValues(typeof(EquipmentSlot)).Length;
        if (equipments.Length == 0)
            equipments = new Equipment[equipmentMaxLength];
        else if (equipments.Length != equipmentMaxLength)
        {
            Equipment[] newEquipment = new Equipment[equipmentMaxLength];
            if (equipments.Length > equipmentMaxLength)
                for (int i = 0; i < equipmentMaxLength; i++)
                    newEquipment[i] = equipments[i];
            else if (equipments.Length < equipmentMaxLength)
                for (int i = 0; i < equipments.Length; i++)
                    newEquipment[i] = equipments[i];
            equipments = newEquipment;
        }

        PassWeapon();
    }

    void PassWeapon()
    {
        GetComponent<Shooting>().GetWeapon((Weapon) equipments[(int)EquipmentSlot.Weapon1], (Weapon) equipments[(int)EquipmentSlot.Weapon2]);
    }
}
