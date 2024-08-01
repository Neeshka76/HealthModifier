using System.Collections;
using System.Collections.Generic;
using ThunderRoad;
using UnityEngine;

namespace HealthModifier;

public class HealthModifierEntryPoint : ThunderScript
{
    private static HealthModifierValue healthModifierValue = new HealthModifierValue();
    private static float tempHealthValueNPC;
    private static float tempHealthValuePlayer;
    private static float healthValueOfPlayer;
    private static float healthValueOfNPC;
    private static int[] selectorModifiersGetSet = new int[10];

    public override void ScriptEnable()
    {
        EventManager.onCreatureSpawn += EventManager_onCreatureSpawn;
        EventManager.onPossess += EventManager_onPossess;
        base.ScriptEnable();
    }

    public override void ScriptDisable()
    {
        EventManager.onCreatureSpawn -= EventManager_onCreatureSpawn;
        EventManager.onPossess -= EventManager_onPossess;
        base.ScriptDisable();
    }

    private void EventManager_onPossess(Creature creature, EventTime eventtime)
    {
        if (eventtime == EventTime.OnStart) return;
        //ConsoleCommands.ToggleInventoryWheel(Side.Left);
        //ConsoleCommands.ToggleOptionsMenu();
        if (playerHealthMode == PlayerHealthMode.Default) return;
        GameManager.local.StartCoroutine(IEUpdatePlayerHealth(playerHealthMode));
    }

    private void EventManager_onCreatureSpawn(Creature creature)
    {
        // If creature is not hidden and isn't the player and the selector not on default
        if (creature.isPlayer) return;
        if (npcHealthMode == NPCHealthMode.Default) return;
        // When a creature is spawning, start this coroutine
        GameManager.local.StartCoroutine(IEHealthModifierNPC(creature));
    }

    public static ModOptionFloat[] HealthPercentages()
    {
        List<ModOptionFloat> options = new List<ModOptionFloat>();
        float val = 0f;
        while (val < 100f)
        {
            options.Add(new ModOptionFloat(val.ToString("0"), val));
            val += 10f;
        }

        while (val >= 100f && val < 300f)
        {
            options.Add(new ModOptionFloat(val.ToString("0"), val));
            val += 50f;
        }

        while (val >= 300f && val < 1000f)
        {
            options.Add(new ModOptionFloat(val.ToString("0"), val));
            val += 100f;
        }

        while (val >= 1000f && val < 5000f)
        {
            options.Add(new ModOptionFloat(val.ToString("0"), val));
            val += 250f;
        }

        while (val >= 5000f && val <= 50000f)
        {
            options.Add(new ModOptionFloat(val.ToString("0"), val));
            val += 1000f;
        }

        return options.ToArray();
    }

    public static ModOptionInt[] Percentages()
    {
        List<ModOptionInt> options = new List<ModOptionInt>();
        int val = 0;
        while (val <= 100)
        {
            options.Add(new ModOptionInt(val.ToString("0"), val));
            val += 5;
        }

        return options.ToArray();
    }

    #region Selectors

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Beggar value in %", tooltip: "Value of the Beggar selector in (%); HP from (50% - 100%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 1, saveValue = true)]
    [ModOptionSlider]
    private static int selectorBeggar = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Peasant value in %", tooltip: "Value of the Peasant selector in (%); HP from (100% - 150%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 2, saveValue = true)]
    [ModOptionSlider]
    private static int selectorPeasant = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Militia value in %", tooltip: "Value of the Militia selector in (%); HP from (150% - 200%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 3, saveValue = true)]
    [ModOptionSlider]
    private static int selectorMilitia = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Gladiator value in %", tooltip: "Value of the Gladiator selector in (%); HP from (200% - 300%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 4, saveValue = true)]
    [ModOptionSlider]
    private static int selectorGladiator = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Warrior value in %", tooltip: "Value of the Warrior selector in (%); HP from (300% - 400%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 5, saveValue = true)]
    [ModOptionSlider]
    private static int selectorWarrior = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Knight value in %", tooltip: "Value of the Knight selector in (%); HP from (400% - 500%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 6, saveValue = true)]
    [ModOptionSlider]
    private static int selectorKnight = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Lord value in %", tooltip: "Value of the Lord selector in (%); HP from (500% - 700%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 7, saveValue = true)]
    [ModOptionSlider]
    private static int selectorLord = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "King value in %", tooltip: "Value of the King selector in (%); HP from (700% - 1000%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 8, saveValue = true)]
    [ModOptionSlider]
    private static int selectorKing = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "DemiGod value in %", tooltip: "Value of the DemiGod selector in (%); HP from (1000% - 1500%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 9, saveValue = true)]
    [ModOptionSlider]
    private static int selectorDemiGod = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "God value in %", tooltip: "Value of the God selector in (%); HP from (1500% - 2000%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 10, saveValue = true)]
    [ModOptionSlider]
    private static int selectorGod = 0;

    [ModOptionCategory("NPC Weighted Random Mode", 3)]
    [ModOption(name: "Titan value in %", tooltip: "Value of the Titan selector in (%); HP from (2000% - 3000%)", valueSourceName: nameof(Percentages), defaultValueIndex = 0, order = 11, saveValue = true)]
    [ModOptionSlider]
    private static int selectorTitan = 0;

    #endregion


    [ModOptionCategory("Player Health Options", 1)]
    [ModOption(name: "Player Health", tooltip: "Change the player Health mode", saveValue = true, order = 1)]
    private static void UpdatePlayerHealthMode(PlayerHealthMode pHealthMode)
    {
        GameManager.local.StartCoroutine(IEUpdatePlayerHealth(pHealthMode));
    }

    [ModOptionCategory("Player Health Options", 1)]
    [ModOption(name: "Health Of Player in %", tooltip: "Value of the Player in %", valueSourceName: nameof(HealthPercentages), defaultValueIndex = 10, order = 2, saveValue = true)]
    [ModOptionSlider]
    private static void SetPlayerHealth(float value)
    {
        healthValueOfPlayer = value;
        if (Player.local == null) return;
        if (playerHealthMode == PlayerHealthMode.Default) return;
        HealthModifierPlayer();
    }

    private static IEnumerator IEUpdatePlayerHealth(PlayerHealthMode pHealthMode)
    {
        yield return new WaitUntil(() => Player.local is not null);
        yield return new WaitUntil(() => Player.local.creature is not null);
        playerHealthMode = pHealthMode;
        HealthModifierPlayer();
        yield return null;
    }

    private static void HealthModifierPlayer()
    {
        float healthToGive = healthModifierValue.GiveHealthValuePlayerMenu((int)playerHealthMode, healthValueOfPlayer);
        GiveHealthToPlayer(healthToGive);
        tempHealthValuePlayer = healthValueOfPlayer;
    }

    private static void GiveHealthToPlayer(float value)
    {
        float valueWithModifier = value * Player.local.creature.healthModifier;
        // Give health value to the player via the Selection Menu
        // Set health for player and if his maxvalue is not set
        if (Player.local.creature.isPlayer && !Mathf.Approximately(Player.local.creature._currentMaxHealth, value))
        {
            // Set the max health without the modifier (as the max health takes in account the HealthModifier of the creature)
            Player.local.creature._currentMaxHealth = value;
            // Set the current health with the modifier (as the current health doesn't take in account the HealthModifier of the creature)
            Player.local.creature._currentHealth = valueWithModifier;
            // Refresh the UI
            Player.local.creature.InvokeHealthChangeEvent(valueWithModifier, valueWithModifier);
        }
    }

    private enum PlayerHealthMode
    {
        Default,
        Custom
    }

    private static PlayerHealthMode playerHealthMode;

    private enum NPCHealthMode
    {
        Default,
        Custom,
        Random
    }

    [ModOptionCategory("NPC Health Options", 2)]
    [ModOption(name: "Health Of NPCs in %", tooltip: "Value of the NPCs in %", valueSourceName: nameof(HealthPercentages), defaultValueIndex = 10, order = 2, saveValue = true)]
    [ModOptionSlider]
    private static void SetNPCHealth(float value)
    {
        healthValueOfNPC = value;
        foreach (Creature creature in Creature.allActive)
        {
            if (creature.isPlayer) continue;
            // If creature is not hidden and isn't the player and the selector not on default
            if (!Mathf.Approximately(creature.maxHealth, creature.currentHealth)) continue;
            // When a creature is spawning, start this coroutine
            GameManager.local.StartCoroutine(IEHealthModifierNPC(creature));
        }

        tempHealthValueNPC = healthValueOfNPC;
    }

    private static NPCHealthMode npcHealthMode;

    public enum NPCRandomMode
    {
        PureRandom,
        WeightedDefault,
        WeightedCustom
    }

    [ModOptionCategory("NPC Weighted Random Mode", 3)] [ModOption(name: "NPC Random Mode", tooltip: "NPC Random Pure Random / Weighted Default / Weighted Custom", defaultValueIndex = 0, order = 0, saveValue = true)]
    private static NPCRandomMode nPCRandomMode;

    private static IEnumerator IEHealthModifierNPC(Creature creature)
    {
        yield return new WaitForSeconds(1.0f);
        GiveHealthToNPC(creature, healthValueOfNPC * 0.5f);
    }

    [ModOptionCategory("NPC Health Options", 2)]
    [ModOption(name: "NPC Health", tooltip: "Change the NPCs Health mode", saveValue = true, order = 1)]
    private static void UpdateNPCsHealthMode(NPCHealthMode NPCsHealthMode)
    {
        npcHealthMode = NPCsHealthMode;
        foreach (Creature creature in Creature.allActive)
        {
            if (creature.isPlayer) continue;
            // If creature is not hidden and isn't the player and the selector not on default
            if (!Mathf.Approximately(creature.maxHealth, creature.currentHealth)) continue;
            // When a creature is spawning, start this coroutine
            GameManager.local.StartCoroutine(IEHealthModifierNPC(creature));
        }
    }

    private static void GiveHealthToNPC(Creature creature, float value)
    {
        // If a enemy is spawning and it is not confirmed set to default !
        // Give health value to the enemy via the Selection Menu
        selectorModifiersGetSet = new int[]
        {
            selectorBeggar,
            selectorPeasant,
            selectorMilitia,
            selectorGladiator,
            selectorWarrior,
            selectorKnight,
            selectorLord,
            selectorKing,
            selectorDemiGod,
            selectorGod,
            selectorTitan
        };
        float healthValueNPC = healthModifierValue.GiveHealthValueEnemyMenu((int)npcHealthMode, nPCRandomMode, selectorModifiersGetSet, true, value);
        float valueWithModifier = healthValueNPC * creature.healthModifier;
        Snippet.DebugLog(
            $"BEFORE : Health of creature : _c {creature._currentHealth}; c {creature.currentHealth}; _m {creature._currentMaxHealth}; m {creature.maxHealth}; _s {healthValueNPC}; s {valueWithModifier}", "lime");
        // Set the max health without the modifier (as the max health takes in account the HealthModifier of the creature)
        creature._currentMaxHealth = healthValueNPC;
        // Set the current health with the modifier (as the current health doesn't take in account the HealthModifier of the creature)
        creature._currentHealth = valueWithModifier;
        // Refresh the UI
        creature.InvokeHealthChangeEvent(valueWithModifier, valueWithModifier);
        Snippet.DebugLog(
            $"AFTER : Health of creature : _c {creature._currentHealth}; c {creature.currentHealth}; _m {creature._currentMaxHealth}; m {creature.maxHealth}; _s {healthValueNPC}; s {valueWithModifier}", "red");
    }
}