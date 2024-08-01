using UnityEngine;

namespace HealthModifier
{
    public class HealthModifierData
    {
        public int SelecModeSelectorEnemyGetSet { get; set; }

        public int SelecModeSelectorPlayerGetSet { get; set; }
        public int nbRankModifiersGetSet { get; set; }


        public float ValueHealthPlayerGetSet { get; set; }
        public float ValueHealthEnemyGetSet { get; set; }

        public bool PureRandomSelectionGetSet { get; set; }
        public bool isInWaveGetSet { get; set; }
        public bool SelectorHasChangedPlayerGetSet { get; set; }

        public bool ValueHasChangedPlayerGetSet { get; set; }
        public bool ValueHasChangedEnemyGetSet { get; set; }

        public bool SelectorModifiersConfirmGetSet { get; set; }

        public bool ErrorModifiersGetSet { get; set; }

        // Set if Keyboard has pressed enter button finish
        public bool KeyboardFinishEnterButtonPressedGetSet { get; set; }
        // Set if the value to assign is a int
        public bool ValueToAssignIsInt { get; set; }
        // Set if the value to assign is a float
        public bool ValueToAssignIsFloat { get; set; }
        // Set if the value to assign is uint
        public bool ValueToAssignIsUint { get; set; }
        // Value to pass from the Keyboard in Uint
        public uint ValueToAssignedUintGetSet { get; set; }
        // Value to pass from the Keyboard in Int
        public int ValueToAssignedIntGetSet { get; set; }
        // Value to pass from the Keyboard in float
        public float ValueToAssignedFloatGetSet { get; set; }
        public bool ButtonPlayerHealthPressedGetSet { get; set; }
        public bool ButtonEnemyHealthPressedGetSet { get; set; }

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
