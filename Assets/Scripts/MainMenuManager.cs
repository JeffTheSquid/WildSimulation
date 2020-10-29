using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Simulator")]
    [SerializeField]
    SimManger sm;

    [Header("Main Menus")]
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject configsMenu;
    [SerializeField]
    CreatureConfigs creatureConfigs;

    [Header("Config Menus")]
    [SerializeField]
    GameObject worldConfigsMenu;
    [SerializeField]
    GameObject metabolismConfigsMenu;
    [SerializeField]
    GameObject reproductionConfigsMenu;
    [SerializeField]
    GameObject metabolismWeightConfigsMenu;
    [SerializeField]
    GameObject mutationConfigsMenu;
    [SerializeField]
    GameObject eatingConfigsMenu;
    [SerializeField]
    GameObject creatureConfigsMenu;
    [SerializeField]
    GameObject speedConfigsMenu;

    [Header("Main Menu Text")]
    [SerializeField]
    TextMeshProUGUI worldSizeValue;
    [SerializeField]
    TextMeshProUGUI startingApplesValue;
    [SerializeField]
    TextMeshProUGUI minAppleSpawnValue;
    [SerializeField]
    TextMeshProUGUI maxAppleSpawnValue;
    [SerializeField]
    TextMeshProUGUI stomachSizeValue;
    [SerializeField]
    TextMeshProUGUI birthStomachFillValue;
    [SerializeField]
    TextMeshProUGUI carnivorePenaltyValue;
    [SerializeField]
    TextMeshProUGUI metabolsimReducerValue;
    [SerializeField]
    TextMeshProUGUI sizeMetabolismValue;
    [SerializeField]
    TextMeshProUGUI speedMetabolismValue;
    [SerializeField]
    TextMeshProUGUI mouthSizeMetabolismValue;
    [SerializeField]
    TextMeshProUGUI armorMetabolismValue;
    [SerializeField]
    TextMeshProUGUI camoMetabolismValue;
    [SerializeField]
    TextMeshProUGUI creatureConsumptionValue;
    [SerializeField]
    TextMeshProUGUI closestFoodProbValue;
    [SerializeField]
    TextMeshProUGUI healthDrainValue;
    [SerializeField]
    TextMeshProUGUI reproductionSpeedValue;
    [SerializeField]
    TextMeshProUGUI reproductionIntervalSizeValue;
    [SerializeField]
    TextMeshProUGUI babyMultiplierValue;
    [SerializeField]
    TextMeshProUGUI babyVolatilityValue;
    [SerializeField]
    TextMeshProUGUI reproduceMinStomachValue;
    [SerializeField]
    TextMeshProUGUI statMutationProbValue;
    [SerializeField]
    TextMeshProUGUI maxStatMutationValue;
    [SerializeField]
    TextMeshProUGUI maxArmorChangeValue;
    [SerializeField]
    TextMeshProUGUI maxCamoChangeValue;
    [SerializeField]
    TextMeshProUGUI omnivoreChanceValue;
    [SerializeField]
    TextMeshProUGUI turnSpeedValue;
    [SerializeField]
    TextMeshProUGUI speedMultiplierValue;
    [SerializeField]
    TextMeshProUGUI hungerSatisfiedValue;
    [SerializeField]
    TextMeshProUGUI healFromFoodValue;

    [Header("World Sliders")]
    [SerializeField]
    TextMeshProUGUI worldSizeSliderValue;
    [SerializeField]
    Slider worldSizeSlider;
    [SerializeField]
    TextMeshProUGUI startingApplesSliderValue;
    [SerializeField]
    Slider startingApplesSlider;
    [SerializeField]
    TextMeshProUGUI minAppleDelaySliderValue;
    [SerializeField]
    Slider minAppleDelaySlider;
    [SerializeField]
    TextMeshProUGUI maxAppleDelaySliderValue;
    [SerializeField]
    Slider maxAppleDelaySlider;

    [Header("Metabolism Sliders")]
    [SerializeField]
    TextMeshProUGUI stomachSizeSliderValue;
    [SerializeField]
    Slider stomachSizeSlider;
    [SerializeField]
    TextMeshProUGUI birthStomachFillSliderValue;
    [SerializeField]
    Slider birthStomachFillSlider;
    [SerializeField]
    TextMeshProUGUI carnivorePenaltySliderValue;
    [SerializeField]
    Slider carnivorePenaltySlider;
    [SerializeField]
    TextMeshProUGUI metabolsimReducerSliderValue;
    [SerializeField]
    Slider metabolsimReducerSlider;

    [Header("Reproduction Sliders")]
    [SerializeField]
    TextMeshProUGUI reproductionSpeedSliderValue;
    [SerializeField]
    Slider reproductionSpeedSlider;
    [SerializeField]
    TextMeshProUGUI reproductionIntervalSizeSliderValue;
    [SerializeField]
    Slider reproductionIntervalSizeSlider;
    [SerializeField]
    TextMeshProUGUI babyMultiplierSliderValue;
    [SerializeField]
    Slider babyMultiplierSlider;
    [SerializeField]
    TextMeshProUGUI babyVolatilitySliderValue;
    [SerializeField]
    Slider babyVolatilitySlider;
    [SerializeField]
    TextMeshProUGUI reproduceMinStomachSliderValue;
    [SerializeField]
    Slider reproduceMinStomachSlider;

    [Header("Metabolism Weight Sliders")]
    [SerializeField]
    TextMeshProUGUI sizeMetabolismSliderValue;
    [SerializeField]
    Slider sizeMetabolismSlider;
    [SerializeField]
    TextMeshProUGUI speedMetabolismSliderValue;
    [SerializeField]
    Slider speedMetabolismSlider;
    [SerializeField]
    TextMeshProUGUI mouthSizeMetabolismSliderValue;
    [SerializeField]
    Slider mouthSizeMetabolismSlider;
    [SerializeField]
    TextMeshProUGUI armorMetabolismSliderValue;
    [SerializeField]
    Slider armorMetabolismSlider;
    [SerializeField]
    TextMeshProUGUI camoMetabolismSliderValue;
    [SerializeField]
    Slider camoMetabolismSlider;

    [Header("Mutation Sliders")]
    [SerializeField]
    TextMeshProUGUI statMutationProbSliderValue;
    [SerializeField]
    Slider statMutationProbSlider;
    [SerializeField]
    TextMeshProUGUI maxStatMutationSliderValue;
    [SerializeField]
    Slider maxStatMutationSlider;
    [SerializeField]
    TextMeshProUGUI omnivoreChanceSliderValue;
    [SerializeField]
    Slider omnivoreChanceSlider;
    [SerializeField]
    TextMeshProUGUI maxArmorChangeSliderValue;
    [SerializeField]
    Slider maxArmorChangeSlider;
    [SerializeField]
    TextMeshProUGUI maxCamoChangeSliderValue;
    [SerializeField]
    Slider maxCamoChangeSlider;

    [Header("Eating Sliders")]
    [SerializeField]
    TextMeshProUGUI creatureConsumptionSliderValue;
    [SerializeField]
    Slider creatureConsumptionSlider;
    [SerializeField]
    TextMeshProUGUI closestFoodProbSliderValue;
    [SerializeField]
    Slider closestFoodProbSlider;
    [SerializeField]
    TextMeshProUGUI healthDrainSliderValue;
    [SerializeField]
    Slider healthDrainSlider;
    [SerializeField]
    TextMeshProUGUI hungerSatisfiedSliderValue;
    [SerializeField]
    Slider hungerSatisfiedSlider;
    [SerializeField]
    TextMeshProUGUI healFromFoodSliderValue;
    [SerializeField]
    Slider healFromFoodSlider;

    [Header("Speed Sliders")]
    [SerializeField]
    TextMeshProUGUI turnSpeedSliderValue;
    [SerializeField]
    Slider turnSpeedSlider;
    [SerializeField]
    TextMeshProUGUI speedMultiplierSliderValue;
    [SerializeField]
    Slider speedMultiplierSlider;


    bool showingConfigs = false;
    bool showingWorldConfigs = false;
    bool showingMetabolismConfigs = false;
    bool showingReproductionConfigs = false;
    bool showingMetabolismWeightConfigs = false;
    bool showingMutationConfigs = false;
    bool showingEatingConfigs = false;
    bool showingCreatureConfigs = false;
    bool showingSpeedConfigs = false;


    // Start is called before the first frame update
    void Start()
    {
        SetConfigBoard();
    }

    public void StartSim()
    {
        mainMenu.SetActive(false);
        sm.SetupSim();
    }

    void SetConfigBoard()
    {
        worldSizeValue.text = Configs.Instance.environmentSize.ToString();
        startingApplesValue.text = Configs.Instance.startingAppleCount.ToString();
        minAppleSpawnValue.text = Configs.Instance.appleMinSeconds.ToString();
        maxAppleSpawnValue.text = Configs.Instance.appleMaxSeconds.ToString();
        stomachSizeValue.text = Configs.Instance.stomachSizeMultiplier.ToString();
        birthStomachFillValue.text = Configs.Instance.birthStomachFill.ToString();
        carnivorePenaltyValue.text = Configs.Instance.warmBloodedPenalty.ToString();
        metabolsimReducerValue.text = Configs.Instance.metabolismReductionConstant.ToString();
        sizeMetabolismValue.text = Configs.Instance.sizeMetabolismWeight.ToString();
        speedMetabolismValue.text = Configs.Instance.speedMetabolismWeight.ToString();
        mouthSizeMetabolismValue.text = Configs.Instance.mouthMetabolismWeight.ToString();
        armorMetabolismValue.text = Configs.Instance.armorMetabolismWeight.ToString();
        camoMetabolismValue.text = Configs.Instance.camoMetabolismWeight.ToString();
        creatureConsumptionValue.text = Configs.Instance.creatureConsumptionRate.ToString();
        closestFoodProbValue.text = Configs.Instance.closestFoodProb.ToString();
        healthDrainValue.text = Configs.Instance.healthDrainRate.ToString();
        reproductionSpeedValue.text = Configs.Instance.matingMultiplier.ToString();
        reproductionIntervalSizeValue.text = Configs.Instance.matingIntervalMultiplier.ToString();
        babyMultiplierValue.text = Configs.Instance.babyMultiplier.ToString();
        babyVolatilityValue.text = Configs.Instance.babyCountVolatility.ToString();
        reproduceMinStomachValue.text = Configs.Instance.reproduceStomachFill.ToString();
        statMutationProbValue.text = Configs.Instance.mutationProbability.ToString();
        maxStatMutationValue.text = Configs.Instance.mutationPercentageChange.ToString();
        maxArmorChangeValue.text = Configs.Instance.maxArmorChange.ToString();
        maxCamoChangeValue.text = Configs.Instance.maxCamoChange.ToString();
        omnivoreChanceValue.text = Configs.Instance.omnivoreChance.ToString();
        turnSpeedValue.text = Configs.Instance.turnSpeed.ToString();
        speedMultiplierValue.text = Configs.Instance.speedMultiplier.ToString();
        hungerSatisfiedValue.text = Configs.Instance.satisfiedHunger.ToString();
        healFromFoodValue.text = Configs.Instance.healingFromFood.ToString();
    }

    public void ResetConfigs()
    {
        UpdateWorldSize(5f);
        UpdateStartingApples(20);
        UpdateMinAppleDelay(1f);
        UpdateMaxAppleDelay(3f);
        UpdateStomachSize(20f);
        UpdateBirthStomachFill(.75f);
        UpdateMetabolismReducer(22f);
        UpdateCarnivorePenalty(20f);
        UpdateSizeMetabolism(4f);
        UpdateSpeedMetabolism(3f);
        UpdateMouthSizeMetabolism(2f);
        UpdateArmorMetabolism(1f);
        UpdateCamoMetabolism(1f);
        UpdateConsumptionRate(3f);
        UpdateClosestFoodProb(60f);
        UpdateHealthDrainRate(5f);
        UpdateReproductionSpeed(1f);
        UpdateReproductionInterval(3f);
        UpdateBabyMultiplier(1f);
        UpdateBabyVolatility(.2f);
        UpdateReproduceStomachFill(.75f);
        UpdateMutationProbabilty(.6f);
        UpdateMutationChange(.1f);
        UpdateOmnivoreChance(.2f);
        UpdateMaxArmorDelta(5f);
        UpdateMaxCamoDelta(5f);
        UpdateTurnSpeed(7f);
        UpdateSpeed(2f);
        UpdateHungerSatisfied(.95f);
        UpdateSpeed(2f);
        UpdateHealFromFood(.5f);

        for (int i = 0; i < Configs.Instance.creatureCount.Count; i++)
        {
            Configs.Instance.creatureCount[i] = 0;
        }
    }

    public void ToggleConfigsMenu()
    {
        if(!showingConfigs)
        {
            mainMenu.SetActive(false);
            configsMenu.SetActive(true);

            showingConfigs = true;
        }
        else
        {
            mainMenu.SetActive(true);
            configsMenu.SetActive(false);

            showingConfigs = false;
        }
    }

    public void ToggleWorldConfigsMenu()
    {
        if (!showingWorldConfigs)
        {
            configsMenu.SetActive(false);
            worldConfigsMenu.SetActive(true);

            showingWorldConfigs = true;

            SetText(Configs.Instance.environmentSize, worldSizeValue, worldSizeSliderValue, worldSizeSlider);
            SetText(Configs.Instance.startingAppleCount, startingApplesValue, startingApplesSliderValue, startingApplesSlider);
            SetText(Configs.Instance.appleMinSeconds, minAppleSpawnValue, minAppleDelaySliderValue, minAppleDelaySlider);
            SetText(Configs.Instance.appleMaxSeconds, maxAppleSpawnValue, maxAppleDelaySliderValue, maxAppleDelaySlider);
        }
        else
        {
            configsMenu.SetActive(true);
            worldConfigsMenu.SetActive(false);

            showingWorldConfigs = false;
        }
    }

    public void ToggleMetabolismConfigsMenu()
    {
        if (!showingMetabolismConfigs)
        {
            configsMenu.SetActive(false);
            metabolismConfigsMenu.SetActive(true);

            showingMetabolismConfigs = true;

            SetText(Configs.Instance.stomachSizeMultiplier, stomachSizeValue, stomachSizeSliderValue, stomachSizeSlider);
            SetText(Configs.Instance.birthStomachFill, birthStomachFillValue, birthStomachFillSliderValue, birthStomachFillSlider);
            SetText(Configs.Instance.warmBloodedPenalty, carnivorePenaltyValue, carnivorePenaltySliderValue, carnivorePenaltySlider);
            SetText(Configs.Instance.metabolismReductionConstant, metabolsimReducerValue, metabolsimReducerSliderValue, metabolsimReducerSlider);
        }
        else
        {
            configsMenu.SetActive(true);
            metabolismConfigsMenu.SetActive(false);

            showingMetabolismConfigs = false;
        }
    }

    public void ToggleReproductionConfigsMenu()
    {
        if (!showingReproductionConfigs)
        {
            configsMenu.SetActive(false);
            reproductionConfigsMenu.SetActive(true);

            showingReproductionConfigs = true;

            SetText(Configs.Instance.matingMultiplier, reproductionSpeedValue, reproductionSpeedSliderValue, reproductionSpeedSlider);
            SetText(Configs.Instance.matingIntervalMultiplier, reproductionIntervalSizeValue, reproductionIntervalSizeSliderValue, reproductionIntervalSizeSlider);
            SetText(Configs.Instance.babyMultiplier, babyMultiplierValue, babyMultiplierSliderValue, babyMultiplierSlider);
            SetText(Configs.Instance.babyCountVolatility, babyVolatilityValue, babyVolatilitySliderValue, babyVolatilitySlider);
            SetText(Configs.Instance.reproduceStomachFill, reproduceMinStomachValue, reproduceMinStomachSliderValue, reproduceMinStomachSlider);
        }
        else
        {
            configsMenu.SetActive(true);
            reproductionConfigsMenu.SetActive(false);

            showingReproductionConfigs = false;
        }
    }

    public void ToggleMetabolsimWeightConfigsMenu()
    {
        if (!showingMetabolismWeightConfigs)
        {
            configsMenu.SetActive(false);
            metabolismWeightConfigsMenu.SetActive(true);

            showingMetabolismWeightConfigs = true;

            SetText(Configs.Instance.sizeMetabolismWeight, sizeMetabolismValue, sizeMetabolismSliderValue, sizeMetabolismSlider);
            SetText(Configs.Instance.speedMetabolismWeight, speedMetabolismValue, speedMetabolismSliderValue, speedMetabolismSlider);
            SetText(Configs.Instance.mouthMetabolismWeight, mouthSizeMetabolismValue, mouthSizeMetabolismSliderValue, mouthSizeMetabolismSlider);
            SetText(Configs.Instance.armorMetabolismWeight, armorMetabolismValue, armorMetabolismSliderValue, armorMetabolismSlider);
            SetText(Configs.Instance.camoMetabolismWeight, camoMetabolismValue, camoMetabolismSliderValue, camoMetabolismSlider);
        }
        else
        {
            configsMenu.SetActive(true);
            metabolismWeightConfigsMenu.SetActive(false);

            showingMetabolismWeightConfigs = false;
        }
    }

    public void ToggleMutationConfigsMenu()
    {
        if (!showingMutationConfigs)
        {
            configsMenu.SetActive(false);
            mutationConfigsMenu.SetActive(true);

            showingMutationConfigs = true;

            SetText(Configs.Instance.mutationProbability, statMutationProbValue, statMutationProbSliderValue, statMutationProbSlider);
            SetText(Configs.Instance.mutationPercentageChange, maxStatMutationValue, maxStatMutationSliderValue, maxStatMutationSlider);
            SetText(Configs.Instance.omnivoreChance, omnivoreChanceValue, omnivoreChanceSliderValue, omnivoreChanceSlider);
            SetText(Configs.Instance.maxArmorChange, maxArmorChangeValue, maxArmorChangeSliderValue, maxArmorChangeSlider);
            SetText(Configs.Instance.maxCamoChange, maxCamoChangeValue, maxCamoChangeSliderValue, maxCamoChangeSlider);
        }
        else
        {
            configsMenu.SetActive(true);
            mutationConfigsMenu.SetActive(false);

            showingMutationConfigs = false;
        }
    }

    public void ToggleEatingConfigsMenu()
    {
        if (!showingEatingConfigs)
        {
            configsMenu.SetActive(false);
            eatingConfigsMenu.SetActive(true);

            showingEatingConfigs = true;

            SetText(Configs.Instance.creatureConsumptionRate, creatureConsumptionValue, creatureConsumptionSliderValue, creatureConsumptionSlider);
            SetText(Configs.Instance.closestFoodProb, closestFoodProbValue, closestFoodProbSliderValue, closestFoodProbSlider);
            SetText(Configs.Instance.healthDrainRate, healthDrainValue, healthDrainSliderValue, healthDrainSlider);
            SetText(Configs.Instance.satisfiedHunger, hungerSatisfiedValue, hungerSatisfiedSliderValue, hungerSatisfiedSlider);
            SetText(Configs.Instance.healingFromFood, healFromFoodValue, healFromFoodSliderValue, healFromFoodSlider);
        }
        else
        {
            configsMenu.SetActive(true);
            eatingConfigsMenu.SetActive(false);

            showingEatingConfigs = false;
        }
    }

    public void ToggleCreatureConfigsMenu()
    {
        if (!showingCreatureConfigs)
        {
            configsMenu.SetActive(false);
            creatureConfigsMenu.SetActive(true);

            showingCreatureConfigs = true;

            creatureConfigs.SetText();
        }
        else
        {
            configsMenu.SetActive(true);
            creatureConfigsMenu.SetActive(false);

            showingCreatureConfigs = false;
        }
    }

    public void ToggleSpeedConfigsMenu()
    {
        if (!showingSpeedConfigs)
        {
            configsMenu.SetActive(false);
            speedConfigsMenu.SetActive(true);

            showingSpeedConfigs = true;

            SetText(Configs.Instance.turnSpeed, turnSpeedValue, turnSpeedSliderValue, turnSpeedSlider);
            SetText(Configs.Instance.speedMultiplier, speedMultiplierValue, speedMultiplierSliderValue, speedMultiplierSlider);
        }
        else
        {
            configsMenu.SetActive(true);
            speedConfigsMenu.SetActive(false);

            showingSpeedConfigs = false;
        }
    }

    public void SetText(float val, TextMeshProUGUI menuVal, TextMeshProUGUI sliderVal, Slider slider)
    {
        menuVal.text = val.ToString();
        sliderVal.text = val.ToString();
        slider.value = val;
    }

    public void UpdateWorldSize(float x)
    {
        Configs.Instance.environmentSize = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.environmentSize, worldSizeValue, worldSizeSliderValue, worldSizeSlider);
    }

    public void UpdateStartingApples(float x)
    {
        Configs.Instance.startingAppleCount = Mathf.CeilToInt(Mathf.Round(x * 10f) / 10f);
        SetText(Configs.Instance.startingAppleCount, startingApplesValue, startingApplesSliderValue, startingApplesSlider);
    }

    public void UpdateMinAppleDelay(float x)
    {
        Configs.Instance.appleMinSeconds = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.appleMinSeconds, minAppleSpawnValue, minAppleDelaySliderValue, minAppleDelaySlider);
    }

    public void UpdateMaxAppleDelay(float x)
    {
        Configs.Instance.appleMaxSeconds = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.appleMaxSeconds, maxAppleSpawnValue, maxAppleDelaySliderValue, maxAppleDelaySlider);
    }

    public void UpdateStomachSize(float x)
    {
        Configs.Instance.stomachSizeMultiplier = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.stomachSizeMultiplier, stomachSizeValue, stomachSizeSliderValue, stomachSizeSlider);
    }

    public void UpdateBirthStomachFill(float x)
    {
        Configs.Instance.birthStomachFill = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.birthStomachFill, birthStomachFillValue, birthStomachFillSliderValue, birthStomachFillSlider);
    }

    public void UpdateCarnivorePenalty(float x)
    {
        Configs.Instance.warmBloodedPenalty = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.warmBloodedPenalty, carnivorePenaltyValue, carnivorePenaltySliderValue, carnivorePenaltySlider);
    }

    public void UpdateMetabolismReducer(float x)
    {
        Configs.Instance.metabolismReductionConstant = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.metabolismReductionConstant, metabolsimReducerValue, metabolsimReducerSliderValue, metabolsimReducerSlider);
    }

    public void UpdateReproductionSpeed(float x)
    {
        Configs.Instance.matingMultiplier = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.matingMultiplier, reproductionSpeedValue, reproductionSpeedSliderValue, reproductionSpeedSlider);
    }

    public void UpdateReproductionInterval(float x)
    {
        Configs.Instance.matingIntervalMultiplier = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.matingIntervalMultiplier, reproductionIntervalSizeValue, reproductionIntervalSizeSliderValue, reproductionIntervalSizeSlider);
    }

    public void UpdateBabyMultiplier(float x)
    {
        Configs.Instance.babyMultiplier = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.babyMultiplier, babyMultiplierValue, babyMultiplierSliderValue, babyMultiplierSlider);
    }

    public void UpdateBabyVolatility(float x)
    {
        Configs.Instance.babyCountVolatility = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.babyCountVolatility, babyVolatilityValue, babyVolatilitySliderValue, babyVolatilitySlider);
    }

    public void UpdateReproduceStomachFill(float x)
    {
        Configs.Instance.reproduceStomachFill = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.reproduceStomachFill, reproduceMinStomachValue, reproduceMinStomachSliderValue, reproduceMinStomachSlider);
    }

    public void UpdateSizeMetabolism(float x)
    {
        Configs.Instance.sizeMetabolismWeight = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.sizeMetabolismWeight, sizeMetabolismValue, sizeMetabolismSliderValue, sizeMetabolismSlider);
    }

    public void UpdateSpeedMetabolism(float x)
    {
        Configs.Instance.speedMetabolismWeight = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.speedMetabolismWeight, speedMetabolismValue, speedMetabolismSliderValue, speedMetabolismSlider);
    }

    public void UpdateMouthSizeMetabolism(float x)
    {
        Configs.Instance.mouthMetabolismWeight = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.mouthMetabolismWeight, mouthSizeMetabolismValue, mouthSizeMetabolismSliderValue, mouthSizeMetabolismSlider);
    }

    public void UpdateArmorMetabolism(float x)
    {
        Configs.Instance.armorMetabolismWeight = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.armorMetabolismWeight, armorMetabolismValue, armorMetabolismSliderValue, armorMetabolismSlider);
    }

    public void UpdateCamoMetabolism(float x)
    {
        Configs.Instance.camoMetabolismWeight = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.camoMetabolismWeight, camoMetabolismValue, camoMetabolismSliderValue, camoMetabolismSlider);
    }

    public void UpdateMutationProbabilty(float x)
    {
        Configs.Instance.mutationProbability = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.mutationProbability, statMutationProbValue, statMutationProbSliderValue, statMutationProbSlider);
    }

    public void UpdateMutationChange(float x)
    {
        Configs.Instance.mutationPercentageChange = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.mutationPercentageChange, maxStatMutationValue, maxStatMutationSliderValue, maxStatMutationSlider);
    }

    public void UpdateOmnivoreChance(float x)
    {
        Configs.Instance.omnivoreChance = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.omnivoreChance, omnivoreChanceValue, omnivoreChanceSliderValue, omnivoreChanceSlider);
    }

    public void UpdateMaxArmorDelta(float x)
    {
        Configs.Instance.maxArmorChange = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.maxArmorChange, maxArmorChangeValue, maxArmorChangeSliderValue, maxArmorChangeSlider);
    }

    public void UpdateMaxCamoDelta(float x)
    {
        Configs.Instance.maxCamoChange = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.maxCamoChange, maxCamoChangeValue, maxCamoChangeSliderValue, maxCamoChangeSlider);
    }

    public void UpdateConsumptionRate(float x)
    {
        Configs.Instance.creatureConsumptionRate = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.creatureConsumptionRate, creatureConsumptionValue, creatureConsumptionSliderValue, creatureConsumptionSlider);
    }

    public void UpdateClosestFoodProb(float x)
    {
        Configs.Instance.closestFoodProb = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.closestFoodProb, closestFoodProbValue, closestFoodProbSliderValue, closestFoodProbSlider);
    }

    public void UpdateHealthDrainRate(float x)
    {
        Configs.Instance.healthDrainRate = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.healthDrainRate, healthDrainValue, healthDrainSliderValue, healthDrainSlider);
    }

    public void UpdateTurnSpeed(float x)
    {
        Configs.Instance.turnSpeed = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.turnSpeed, turnSpeedValue, turnSpeedSliderValue, turnSpeedSlider);
    }

    public void UpdateSpeed(float x)
    {
        Configs.Instance.speedMultiplier = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.speedMultiplier, speedMultiplierValue, speedMultiplierSliderValue, speedMultiplierSlider);
    }

    public void UpdateHungerSatisfied(float x)
    {
        Configs.Instance.satisfiedHunger = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.satisfiedHunger, hungerSatisfiedValue, hungerSatisfiedSliderValue, hungerSatisfiedSlider);
    }

    public void UpdateHealFromFood(float x)
    {
        Configs.Instance.healingFromFood = Mathf.Round(x * 10f) / 10f;
        SetText(Configs.Instance.healingFromFood, healFromFoodValue, healFromFoodSliderValue, healFromFoodSlider);
    }
}
