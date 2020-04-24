using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public float maxEnergy;
    public float currEnergy;

    public HealthBar healthBar;
    public Equipment[] equipments = new Equipment[System.Enum.GetValues(typeof(EquipmentSlot)).Length];

    // Start is called before the first frame update
    void Start()
    {
        checkEquipmentSlot();
        importStatFromEquipment();
        ResetUI();
        passWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnValidate()
    {
        checkEquipmentSlot();
        importStatFromEquipment();
        passWeapon();
    }

    void checkEquipmentSlot()
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
    }

    void importStatFromEquipment()
    {
        maxEnergy = ((Core)equipments[(int)EquipmentSlot.Core]).MaximumEnergy;

        Body body = (Body)equipments[(int)EquipmentSlot.Body];
        maxEnergy -= body.EnergyCost;
        maxHealth = body.HitPoint;
        currentHealth = maxHealth;

        Leg leg = (Leg)equipments[(int)EquipmentSlot.Leg];
        passSpeed(leg.speed, leg.EnergyCostPerSecond);
        maxEnergy -= leg.EnergyCost;

        Head head = (Head)equipments[(int)EquipmentSlot.Head];
        passViewDistance(head.ViewDistance);
        maxEnergy -= head.EnergyCost;

        currEnergy = maxEnergy;
    }

    void ResetUI()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    void passSpeed(float speed, float costPerSecond)
    {
        GetComponent<PlayerMovement>().GetSpeedAndCost(speed, costPerSecond);
    }

    void passViewDistance(float distance)
    {

    }

    void passWeapon()
    {
        GetComponent<Shooting>().GetWeapon((Weapon) equipments[(int)EquipmentSlot.Weapon1], (Weapon) equipments[(int)EquipmentSlot.Weapon2]);
    }
}
