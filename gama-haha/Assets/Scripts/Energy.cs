using UnityEngine;

public class Energy : MonoBehaviour
{
    [Header("Charging")]
    public bool charging = false;
    [SerializeField]
    private int startingEnergy = 100;
    [SerializeField]
    private int currentEnergy = 100;
    [SerializeField]
    private float chargingTimeRate = 0.1f;
    [SerializeField]
    private int chargingRate = 1;

    [Header("Blast")]
    [SerializeField]
    private int blastEnergyCost = 50;
    [SerializeField]
    private GameObject blast;
    [SerializeField]
    private GameObject blastSource;

    private float tempTime = 0;

    private Damage _damage;

    private void Start()
    {
        _damage = GetComponent<Damage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charging)
        {
            tempTime += Time.deltaTime;
            if (tempTime > chargingTimeRate)
            {
                currentEnergy += chargingRate;
                tempTime = 0;
            }
        }
        if (currentEnergy > startingEnergy)
        {
            currentEnergy = startingEnergy;
        }
    }

    private void SpendEnergy(int energy)
    {
        currentEnergy -= energy;
        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }

    private bool IsEnoughEnergy(int energyToSpend)
    {
        return currentEnergy >= energyToSpend;
    }
    private void ShootBlast()
    {
        if (IsEnoughEnergy(blastEnergyCost))
        {
            SpendEnergy(blastEnergyCost);
            GameObject spawnedBlast = Instantiate(blast, blastSource.transform.position, Quaternion.identity);
            spawnedBlast.GetComponent<Blast>().SetDirection(this.gameObject.transform.localScale.x);
            spawnedBlast.GetComponent<Attack>().SetNextAttack(_damage.blastDamage, _damage.blastPushBackPower);
        }
    }
}
