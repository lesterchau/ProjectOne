using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public float maxEnergy;
    public float currEnergy;
    public float rechargeRate;
    public float degenerate;

    public HealthBar healthBar;
    public TextMeshProUGUI tempText;
    public Equipment[] equipments = new Equipment[System.Enum.GetValues(typeof(EquipmentSlot)).Length];

    private float finalRegenerate;

    // Start is called before the first frame update
    void Start()
    {
        CheckEquipmentSlot();
        ImportStatFromEquipment();
        ResetUI();
        PassWeapon();
        RenewUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

    }

    private void LateUpdate()
    {
        finalRegenerate = rechargeRate * currentHealth / maxHealth - degenerate;
        float generatedEnergyOnThisFrame = finalRegenerate * Time.deltaTime;
        if (maxEnergy - currEnergy > generatedEnergyOnThisFrame)
            currEnergy += generatedEnergyOnThisFrame;
        else
            currEnergy = maxEnergy;
        RenewUI();
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnValidate()
    {
        CheckEquipmentSlot();
        ImportStatFromEquipment();
        PassWeapon();
    }

    void CheckEquipmentSlot()
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

    void ImportStatFromEquipment()
    {
        Core core = (Core)equipments[(int)EquipmentSlot.Core];
        maxEnergy = core.MaximumEnergy;
        rechargeRate = core.RegenerateRate;

        Body body = (Body)equipments[(int)EquipmentSlot.Body];
        maxEnergy -= body.EnergyCost;
        maxHealth = body.HitPoint;
        currentHealth = maxHealth;

        Leg leg = (Leg)equipments[(int)EquipmentSlot.Leg];
        PassSpeed(leg.speed, leg.EnergyCostPerSecond);
        maxEnergy -= leg.EnergyCost;

        Head head = (Head)equipments[(int)EquipmentSlot.Head];
        PassViewDistance(head.ViewDistance);
        maxEnergy -= head.EnergyCost;

        currEnergy = maxEnergy;
    }

    void ResetUI()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    void PassSpeed(float speed, float costPerSecond)
    {
        GetComponent<PlayerMovement>().GetSpeedAndCost(speed, costPerSecond);
    }

    void PassViewDistance(float distance)
    {

    }

    void PassWeapon()
    {
        GetComponent<Shooting>().GetWeapon((Weapon) equipments[(int)EquipmentSlot.Weapon1], (Weapon) equipments[(int)EquipmentSlot.Weapon2]);
    }

    void RenewUI()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("HP: ");
        builder.Append(currentHealth);
        builder.Append("/");
        builder.Append(maxHealth);

        builder.Append("\nEnergy: ");
        builder.Append(System.Math.Ceiling(currEnergy * 10) / 10);
        builder.Append("/");
        builder.Append(maxEnergy);

        builder.Append("\nRechage Rate: ");
        builder.Append(finalRegenerate);
        builder.Append("/");
        builder.Append(rechargeRate);
        tempText.text = builder.ToString();
    }
}
