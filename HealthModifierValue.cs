using ThunderRoad;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HealthModifier
{
    public class HealthModifierValue
    {
        // Variables 

        // Default Health Values
        private float healthDefaultEnemy = 50.0f;
        private float healthDefaultPlayer = 100.0f;

        // Health Value for Enemy Random Mode Min - Max
        private float healthValueEnemyRandom = 50.0f;
        private float healthValueEnemyRandomMin = 25.0f;
        private float healthValueEnemyRandomMax = 1500.0f;

        // Health Value for Enemy Selection Mode
        private float healthValueEnemySelect = 50.0f;

        // Health Value for Player Selection Mode
        private float healthValuePlayerSelect = 100.0f;

        // Temp for calculus
        private float tempHealthValueRandomToRound = 0.0f;

        // Selector for pure random
        private float randomSelector = 1.0f;
        private float randomSelectorMax = 100.0f;
        private float randomSelectorMin = 0.0f;

        // Selector  Default Values for Ranks
        private float selectorBeggarLow = 0.0f;
        private float selectorBeggar = 5.0f;
        private float selectorBeggarHigh = 5.0f;
        private float selectorPeasantLow = 5.0f;
        private float selectorPeasant = 20.0f;
        private float selectorPeasantHigh = 25.0f;
        private float selectorMilitiaLow = 25.0f;
        private float selectorMilitia = 15.0f;
        private float selectorMilitiaHigh = 40.0f;
        private float selectorGladiatorLow = 40.0f;
        private float selectorGladiator = 20.0f;
        private float selectorGladiatorHigh = 60.0f;
        private float selectorWarriorLow = 60.0f;
        private float selectorWarrior = 15.0f;
        private float selectorWarriorHigh = 75.0f;
        private float selectorKnightLow = 75.0f;
        private float selectorKnight = 7.0f;
        private float selectorKnightHigh = 82.0f;
        private float selectorLordLow = 82.0f;
        private float selectorLord = 7.0f;
        private float selectorLordHigh = 89.0f;
        private float selectorKingLow = 89.0f;
        private float selectorKing = 5.0f;
        private float selectorKingHigh = 94.0f;
        private float selectorDemiGodLow = 94.0f;
        private float selectorDemiGod = 3.0f;
        private float selectorDemiGodHigh = 97.0f;
        private float selectorGodLow = 97.0f;
        private float selectorGod = 2.0f;
        private float selectorGodHigh = 99.0f;
        private float selectorTitanLow = 99.0f;
        private float selectorTitan = 1.0f;
        private float selectorTitanHigh = 100.0f;

        // Health Ranks Values
        private float healthValueBeggarLow = 25.0f;
        private float healthValueBeggarHigh = 50.0f;
        private float healthValuePeasantLow = 50.0f;
        private float healthValuePeasantHigh = 75.0f;
        private float healthValueMilitiaLow = 75.0f;
        private float healthValueMilitiaHigh = 100.0f;
        private float healthValueGladiatorLow = 100.0f;
        private float healthValueGladiatorHigh = 150.0f;
        private float healthValueWarriorLow = 150.0f;
        private float healthValueWarriorHigh = 200.0f;
        private float healthValueKnightLow = 200.0f;
        private float healthValueKnightHigh = 250.0f;
        private float healthValueLordLow = 250.0f;
        private float healthValueLordHigh = 350.0f;
        private float healthValueKingLow = 350.0f;
        private float healthValueKingHigh = 500.0f;
        private float healthValueDemiGodLow = 500.0f;
        private float healthValueDemiGodHigh = 750.0f;
        private float healthValueGodLow = 750.0f;
        private float healthValueGodHigh = 1000.0f;
        private float healthValueTitanLow = 1000.0f;
        private float healthValueTitanHigh = 1500.0f;

        // To calculate the random value of Health
        private float CalculateRandomEnemyValue(bool pureRandomMode, int[] valueTab, bool confirmWithModifiers)
        {
            // Pure random between 25 - 500 Health
            if (pureRandomMode == true && confirmWithModifiers == true)
            {
                healthValueEnemyRandom = Random.Range(healthValueEnemyRandomMin, healthValueEnemyRandomMax);
                if (healthValueEnemyRandom % 5.0f != 0.0f)
                {
                    tempHealthValueRandomToRound = healthValueEnemyRandom;
                    healthValueEnemyRandom = 5 * (Mathf.Round(tempHealthValueRandomToRound / 5));
                }
            }
            // Weighted Random Value
            else
            {

                /*
                Selector value 0 = default value
                Selector value 1 = 0%
                Selector value 2 = 5%
                Selector value 3 = 10%
                Selector value 4 = 15%
                Selector value 5 = 20%
                Selector value 6 = 25%
                Selector value 7 = 30%
                Selector value 8 = 35%
                Selector value 9 = 40%
                Selector value 10 = 45%
                Selector value 11 = 50%
                Selector value 12 = 55%
                Selector value 13 = 60%
                Selector value 14 = 65%
                Selector value 15 = 70%
                Selector value 16 = 75%
                Selector value 17 = 80%
                Selector value 18 = 85%
                Selector value 19 = 90%
                Selector value 20 = 95%
                Selector value 21 = 100%
                */


                //When i = 0; value for Beggar
                //When i = 1; value for Peasant
                //When i = 2; value for Militia
                //When i = 3; value for Gladiator
                //When i = 4; value for Warrior
                //When i = 5; value for Knight
                //When i = 6; value for Lord
                //When i = 7; value for King
                //When i = 8; value for DemiGod
                //When i = 9; value for God
                //When i = 10; value for Titan
                
                int value = 0;
                for(int i = 0; i <= 10; i++)
                {
                    // Use the values of the modifiers only if confirmed
                    if (confirmWithModifiers == false)
                    {
                        value = 0;
                    }
                    else
                    {
                        value = valueTab[i];
                    }
                    // Default values
                    if (value == 0)
                    {
                        switch(i)
                        {
                            case 0:
                                selectorBeggar = 5.0f;
                                break;
                            case 1:
                                selectorPeasant = 20.0f;
                                break;
                            case 2:
                                selectorMilitia = 15.0f;
                                break;
                            case 3:
                                selectorGladiator = 20.0f;
                                break;
                            case 4:
                                selectorWarrior = 15.0f;
                                break;
                            case 5:
                                selectorKnight = 7.0f;
                                break;
                            case 6:
                                selectorLord = 7.0f;
                                break;
                            case 7:
                                selectorKing = 5.0f;
                                break;
                            case 8:
                                selectorDemiGod = 3.0f;
                                break;
                            case 9:
                                selectorGod = 2.0f;
                                break;
                            case 10:
                                selectorTitan = 1.0f;
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                selectorBeggar = value * 5.0f - 5.0f;
                                break;
                            case 1:
                                selectorPeasant = value * 5.0f - 5.0f;
                                break;
                            case 2:
                                selectorMilitia = value * 5.0f - 5.0f;
                                break;
                            case 3:
                                selectorGladiator = value * 5.0f - 5.0f;
                                break;
                            case 4:
                                selectorWarrior = value * 5.0f - 5.0f;
                                break;
                            case 5:
                                selectorKnight = value * 5.0f - 5.0f;
                                break;
                            case 6:
                                selectorLord = value * 5.0f - 5.0f;
                                break;
                            case 7:
                                selectorKing = value * 5.0f - 5.0f;
                                break;
                            case 8:
                                selectorDemiGod = value * 5.0f - 5.0f;
                                break;
                            case 9:
                                selectorGod = value * 5.0f - 5.0f;
                                break;
                            case 10:
                                selectorTitan = value * 5.0f - 5.0f;
                                break;
                        }
                    }
                }
                
                // Selector Values Calculus

                selectorBeggarLow = 0.0f; // Always at 0 (%)
                selectorBeggarHigh = selectorBeggarLow + selectorBeggar;
                selectorPeasantLow = selectorBeggarHigh;
                selectorPeasantHigh = selectorPeasantLow + selectorPeasant;
                selectorMilitiaLow = selectorPeasantHigh;
                selectorMilitiaHigh = selectorMilitiaLow + selectorMilitia;
                selectorGladiatorLow = selectorMilitiaHigh;
                selectorGladiatorHigh = selectorGladiatorLow + selectorGladiator;
                selectorWarriorLow = selectorGladiatorHigh;
                selectorWarriorHigh = selectorWarriorLow + selectorWarrior;
                selectorKnightLow = selectorWarriorHigh;
                selectorKnightHigh = selectorKnightLow + selectorKnight;
                selectorLordLow = selectorKnightHigh;
                selectorLordHigh = selectorLordLow + selectorLord;
                selectorKingLow = selectorLordHigh;
                selectorKingHigh = selectorKingLow + selectorKing; 
                selectorDemiGodLow = selectorKingHigh;
                selectorDemiGodHigh = selectorDemiGodLow + selectorDemiGod; 
                selectorGodLow = selectorDemiGodHigh;
                selectorGodHigh = selectorGodLow + selectorGod;
                selectorTitanLow = selectorGodHigh;
                selectorTitanHigh = selectorTitanLow + selectorTitan; // Should always equals 100 (%)

                // By default Health Values
                healthValueBeggarLow = 25.0f;
                healthValueBeggarHigh = 50.0f;
                healthValuePeasantLow = healthValueBeggarHigh;
                healthValuePeasantHigh = 75.0f;
                healthValueMilitiaLow = healthValuePeasantHigh;
                healthValueMilitiaHigh = 100.0f;
                healthValueGladiatorLow = healthValueMilitiaHigh;
                healthValueGladiatorHigh = 150.0f;
                healthValueWarriorLow = healthValueGladiatorHigh;
                healthValueWarriorHigh = 200.0f;
                healthValueKnightLow = healthValueWarriorHigh;
                healthValueKnightHigh = 250.0f;
                healthValueLordLow = healthValueKnightHigh;
                healthValueLordHigh = 350.0f;
                healthValueKingLow = healthValueLordHigh;
                healthValueKingHigh = 500.0f;
                healthValueDemiGodLow = healthValueKingHigh;
                healthValueDemiGodHigh = 750.0f;
                healthValueGodLow = healthValueDemiGodHigh;
                healthValueGodHigh = 1000.0f;
                healthValueTitanLow = healthValueGodHigh;
                healthValueTitanHigh = 1500.0f;

                /* By default Ranks for random enemies :
                 _____________________________________________________________________________________________________
                *|Beggar           % Chances of enemies with 25 - 50    Health Points (50% - 100%)       :5%       |4|
                *|Peasant          % Chances of enemies with 50 - 75    Health Points (100% - 150%)      :20%      |0|
                *|Militia          % Chances of enemies with 75 - 100   Health Points (150% - 200%)      :15%      |%|
                 |__________                                                                                       __|
                *|Gladiator        % Chances of enemies with 100 - 150  Health Points (200% - 300%)      :20%      |3|
                 |   |                                                                                             |5|
                *|Warrior          % Chances of enemies with 150 - 200  Health Points (300% - 400%)      :15%      |%|
                 |__________                                                                                       __|
                *|Knight           % Chances of enemies with 200 - 250  Health Points (400% - 500%)      :7%       |1|
                *|Lord             % Chances of enemies with 250 - 350  Health Points (500% - 700%)      :7%       |9|
                *|King             % Chances of enemies with 350 - 500  Health Points (700% - 1000%)     :5%       |%|
                 |__________                                                                                       __|
                *|DemiGod          % Chances of enemies with 500 - 750  Health Points (1000% - 1500%)    :3%       |0|
                *|God              % Chances of enemies with 750 - 1000  Health Points (1500% - 2000%)   :2%       |6|
                *|Titan            % Chances of enemies with 1000 - 1500  Health Points (2000% - 3000%)  :1%       |%|
                 _____________________________________________________________________________________________________
                */

                randomSelector = Mathf.Ceil(Random.Range(randomSelectorMin, randomSelectorMax));

                // Default Beggar 5% of chance 25 - 50
                if (randomSelector >= selectorBeggarLow && randomSelector < selectorBeggarHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueBeggarLow, healthValueBeggarHigh);
                }
                // Default Peasant 20% of chance 50 - 75
                if (randomSelector >= selectorPeasantLow && randomSelector < selectorPeasantHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValuePeasantLow, healthValuePeasantHigh);
                }
                // Default Militia 15% of chance 75 - 100
                if (randomSelector >= selectorMilitiaLow && randomSelector < selectorMilitiaHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueMilitiaLow, healthValueMilitiaHigh);
                }
                // Default Gladiator 20% of chance 100 - 150
                if (randomSelector >= selectorGladiatorLow && randomSelector < selectorGladiatorHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueGladiatorLow, healthValueGladiatorHigh);
                }
                // Default Warrior 10% of chance 150 - 200
                if (randomSelector >= selectorWarriorLow && randomSelector < selectorWarriorHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueWarriorLow, healthValueWarriorHigh);
                }
                // Default Knight 10% of chance 200 - 250
                if (randomSelector >= selectorKnightLow && randomSelector < selectorKnightHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueKnightLow, healthValueKnightHigh);
                }
                // Default Lord 10% of chance 250 - 350
                if (randomSelector >= selectorLordLow && randomSelector < selectorLordHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueLordLow, healthValueLordHigh);
                }
                // Default King 5% of chance 350 - 500
                if (randomSelector >= selectorKingLow && randomSelector < selectorKingHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueKingLow, healthValueKingHigh);
                }
                // Default DemiGod 3% of chance 500 - 750
                if (randomSelector >= selectorDemiGodLow && randomSelector < selectorDemiGodHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueDemiGodLow, healthValueDemiGodHigh);
                }
                // Default God 2% of chance 750 - 1000
                if (randomSelector >= selectorGodLow && randomSelector < selectorGodHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueGodLow, healthValueGodHigh);
                }
                // Default Titan 1% of chance 1000 - 1500
                if (randomSelector >= selectorTitanLow && randomSelector < selectorTitanHigh)
                {
                    tempHealthValueRandomToRound = Random.Range(healthValueTitanLow, healthValueTitanHigh);
                }
                // Calculus for round up value (every 5) ===> If value is at 173, it'll be 175 at the end of calculus
                if (tempHealthValueRandomToRound % 5.0f != 0.0f)
                {
                    healthValueEnemyRandom = 5 * (Mathf.Round(tempHealthValueRandomToRound / 5));
                }
            }
            return healthValueEnemyRandom;
        }

        /* Values Selectable for enemies :
       *   Value00 at 50;  100%
       *   Value01 at Slider Value / 2;  Slider%
       *   Value02 at null ; Random mode
       *   Default at 50;  100%
       */

        public float GiveHealthValueEnemyMenu(int SelecModeSelectorEnemy, bool pureRandomMode, int[] valueSelectorTab, bool confirmValueSelector, float valuetoGive)
        {
            // For button switch
            switch (SelecModeSelectorEnemy)
            {
                case 0:
                    healthValueEnemySelect = healthDefaultEnemy;
                    break;
                case 1:
                    healthValueEnemySelect = valuetoGive;
                    break;
                case 2:
                    // Give a value round up at base 5 of value between the min value and the max value + classes of enemies or not
                    // Example : Min 50, Max 500. If the value is 373, it'll be 375
                    healthValueEnemySelect = CalculateRandomEnemyValue(pureRandomMode, valueSelectorTab, confirmValueSelector);
                    break;
                default:
                    healthValueEnemySelect = healthDefaultEnemy;
                    break;
            }
            return healthValueEnemySelect;
        }

        /* Values Selectable for player :
        *   Value00 at 100; 100%
        *   Value01 at Slider Value;  Slider%
        *   Default at 100;  100%
        */
        public float GiveHealthValuePlayerMenu(int SelecModeSelectorPlayer, float valuetoGive)
        {
            // For button switch
            switch (SelecModeSelectorPlayer)
            {
                case 0:
                    healthValuePlayerSelect = healthDefaultPlayer;
                    break;
                case 1:
                    healthValuePlayerSelect = valuetoGive;
                    break;
                default:
                    healthValuePlayerSelect = healthDefaultPlayer;
                    break;
            }
            return healthValuePlayerSelect;
        }
    }
}
