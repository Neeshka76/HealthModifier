using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HealthModifier
{
    public class HealthModifierData
    {
        public int SelecModeSelectorEnemyGetSet { get; set; }
        
        public int SelecModeSelectorPlayerGetSet { get; set; }
        public int nbRankModifiersGetSet { get; set; }
        

        public float SliderValueHealthPlayerGetSet { get; set; }
        public float SliderValueHealthEnemyGetSet { get; set; }

        public bool PureRandomSelectionGetSet { get; set; }
        public bool isInWaveGetSet { get; set; }
        public bool SelectorHasChangedPlayerGetSet { get; set; }

        public bool SliderHasChangedPlayerGetSet { get; set; }
        public bool SliderHasChangedEnemyGetSet { get; set; }

        public bool SelectorModifiersConfirmGetSet { get; set; }

        public bool ErrorModifiersGetSet { get; set; }

        // Selector for changing the rank value
        // selectorModifiersGetSet[0] = Beggar
        // selectorModifiersGetSet[1] = Peasant
        // selectorModifiersGetSet[2] = Militia
        // selectorModifiersGetSet[3] = Gladiator
        // selectorModifiersGetSet[4] = Warrior
        // selectorModifiersGetSet[5] = Knight
        // selectorModifiersGetSet[6] = Lord
        // selectorModifiersGetSet[7] = King
        // selectorModifiersGetSet[8] = DemiGod
        // selectorModifiersGetSet[9] = God
        // selectorModifiersGetSet[10] = Titan
        public int[] selectorModifiersGetSet { get; set; }

    }

    public class HealthModifierController : MonoBehaviour
    {
        public HealthModifierData data = new HealthModifierData();
    }
}
