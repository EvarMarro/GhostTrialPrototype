using UnityEngine;
using UnityEngine.EventSystems;

public class InvisibleEvent : MonoBehaviour
{

    public SimpleHealthBar energyBar;
    float currentEnergy = 100f;
    readonly float maxEnergy = 100f;
    bool useCooldown = false;
    bool reloadCooldown = false;
    // Use this for initialization
    void Start()
    {
        energyBar.UpdateBar(currentEnergy, maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (currentEnergy > 0)
            {
                if (!useCooldown)
                {
                    Invoke("ResetCooldown", 0.5f);
                    currentEnergy -= 10f;
                    energyBar.UpdateBar(currentEnergy, maxEnergy);
                    print("Gasto Energía");
                    useCooldown = true;
                }                
            }
        } else
        {
            if(currentEnergy < maxEnergy)
            {
                if (!reloadCooldown)
                {
                    Invoke("ResetReloadCooldown", 0.5f);
                    currentEnergy += 10f;
                    energyBar.UpdateBar(currentEnergy, maxEnergy);
                    print("Recargo Energía");
                    reloadCooldown = true;
                }
            }
        }
    }

    void ResetCooldown()
    {
        useCooldown = false;
    }

    void ResetReloadCooldown()
    {
        reloadCooldown = false;
    }
}
