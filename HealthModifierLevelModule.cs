using System.Collections;
using ThunderRoad;
using UnityEngine;


namespace HealthModifier
{
    public class HealthModifierLevelModule : LevelModule
    {
     
        private HealthModifierController healthModifierController;
        private HealthModifierValue healthModifierValue = new HealthModifierValue();
        // How to send arguments for selectable values of selectors ?
        private int selectorEnemy;
        private int selectorPlayer;
        private int nbRankRandomMode;
        private bool pureRandomSelection;
        private float healthValueEnemy;
        private float healthValuePlayer;

    // Execute at the loading of the level
    public override System.Collections.IEnumerator OnLoadCoroutine()
        {
            healthModifierController = GameManager.local.gameObject.GetComponent<HealthModifierController>();
            // Create an event manager on creature spawn
            EventManager.onCreatureSpawn += EventManager_onCreatureSpawn;
            //EventManager.onCreatureHit += EventManager_onCreatureHit;

            return base.OnLoadCoroutine();
        }

        public override void Update()
        {
            if (healthModifierController == null)
            {
                healthModifierController = GameManager.local.gameObject.GetComponent<HealthModifierController>();
                return;
            }
            else
            {
                if (healthModifierController.data.ValueHasChangedPlayerGetSet)
                {
                    selectorPlayer = healthModifierController.data.SelecModeSelectorPlayerGetSet;
                    giveHealthToPlayer(selectorPlayer, healthModifierController.data.ValueHealthPlayerGetSet); 
                }
                if (healthModifierController.data.SelectorModifiersConfirmGetSet == true || healthModifierController.data.ValueHasChangedEnemyGetSet)
                {
                    foreach (Creature creature in Creature.allActive)
                    {
                        selectorEnemy = healthModifierController.data.SelecModeSelectorEnemyGetSet;
                        // If creature is not hidden and isn't the player and the selector not on default
                        if (!creature.isPlayer && !creature.hidden && selectorEnemy != 0 && creature.maxHealth == creature.currentHealth)
                        {
                            // When a creature is spawning, start this coroutine
                            GameManager.local.StartCoroutine(IEHealthModifier(creature));

                        }
                    }
                }
            }
        }

        private IEnumerator IEHealthModifier(Creature creature)
        {
            float tempoTime = 1.0f;
            yield return (object)new WaitForSeconds(tempoTime);
            
            selectorEnemy = healthModifierController.data.SelecModeSelectorEnemyGetSet;
            selectorPlayer = healthModifierController.data.SelecModeSelectorPlayerGetSet;
            giveHealthToEnemy(creature, selectorEnemy, healthModifierController.data.ValueHealthEnemyGetSet / 2);
            if (creature.isPlayer)
            {
                giveHealthToPlayer(selectorPlayer, healthModifierController.data.ValueHealthPlayerGetSet);
            }
            yield return (object)null;
        }

        public void giveHealthToPlayer(int selectPlayer, float value)
        {
            // Give health value to the player via the Selection Menu
            healthValuePlayer = healthModifierValue.GiveHealthValuePlayerMenu(selectPlayer, value);
            // Set health for player and if his maxvalue is not set
            if (Player.local.creature.isPlayer && Player.local.creature.maxHealth != healthValuePlayer)
            {
                Player.local.creature.currentHealth = healthValuePlayer;
                Player.local.creature.maxHealth = healthValuePlayer;
            }
            healthModifierController.data.ValueHasChangedPlayerGetSet = false;
        }

        public void giveHealthToEnemy(Creature creature, int selectEnemy, float value)
        {
            pureRandomSelection = healthModifierController.data.PureRandomSelectionGetSet;
            nbRankRandomMode = healthModifierController.data.nbRankModifiersGetSet;
            int[] tabValueModifier = new int[nbRankRandomMode];
            tabValueModifier = healthModifierController.data.selectorModifiersGetSet;
            bool ConfirmModifierRandom = false;
            // If a enemy is spawning and it is not confirmed set to default !
            if (healthModifierController.data.SelectorModifiersConfirmGetSet == true)
            {
                ConfirmModifierRandom = true;
            }
            // Give health value to the enemy via the Selection Menu
            healthValueEnemy = healthModifierValue.GiveHealthValueEnemyMenu(selectEnemy, pureRandomSelection, tabValueModifier, ConfirmModifierRandom, value);
            // Set health for all creatures not hidden and that do no have the maxvalue set (except for player)
            if (!creature.isPlayer && creature.maxHealth != healthValueEnemy)
            {
                creature.maxHealth = healthValueEnemy;
                creature.currentHealth = healthValueEnemy;
            }
            healthModifierController.data.ValueHasChangedEnemyGetSet = false;
        }

        private void EventManager_onCreatureSpawn(Creature creature)
        {
            selectorEnemy = healthModifierController.data.SelecModeSelectorEnemyGetSet;
            // If creature is not hidden and isn't the player and the selector not on default
            if (!creature.isPlayer && !creature.hidden && selectorEnemy != 0)
            {
                // When a creature is spawning, start this coroutine
                GameManager.local.StartCoroutine(IEHealthModifier(creature));
            }
        }
    }
}
