using System.Collections;
using ThunderRoad;
using UnityEngine;


namespace HealthModifier
{
    public class HealthModifierLevelModule : LevelModule
    {

        private HealthModifierController healthModifierController;
        private HealthModifierValue healthModifierValue = new HealthModifierValue();
        private float healthValueEnemy;
        private float healthValuePlayer;

        // Execute at the loading of the level
        public override IEnumerator OnLoadCoroutine()
        {
            healthModifierController = GameManager.local.gameObject.GetComponent<HealthModifierController>();
            // Create an event manager on creature spawn
            EventManager.onCreatureSpawn += EventManager_onCreatureSpawn;
            //EventManager.onCreatureHit += EventManager_onCreatureHit;

            return base.OnLoadCoroutine();
        }

        public override void OnUnload()
        {
            EventManager.onCreatureSpawn -= EventManager_onCreatureSpawn;
            base.OnUnload();
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
                    giveHealthToPlayer(healthModifierController.data.SelecModeSelectorPlayerGetSet, healthModifierController.data.ValueHealthPlayerGetSet);
                }
                if (healthModifierController.data.SelectorModifiersConfirmGetSet == true || healthModifierController.data.ValueHasChangedEnemyGetSet)
                {
                    foreach (Creature creature in Creature.allActive)
                    {
                        // If creature is not hidden and isn't the player and the selector not on default
                        if (!creature.isPlayer && healthModifierController.data.SelecModeSelectorEnemyGetSet != 0 && creature.maxHealth == creature.currentHealth)
                        {
                            // When a creature is spawning, start this coroutine
                            GameManager.local.StartCoroutine(IEHealthModifier(creature));
                        }
                    }
                    healthModifierController.data.ValueHasChangedEnemyGetSet = false;
                }
            }
        }

        private IEnumerator IEHealthModifier(Creature creature)
        {
            float tempoTime = 1.0f;
            yield return new WaitForSeconds(tempoTime);
            giveHealthToEnemy(creature, healthModifierController.data.SelecModeSelectorEnemyGetSet, healthModifierController.data.ValueHealthEnemyGetSet / 2);
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
                Player.local.creature.data.health = (short)healthValuePlayer;
            }
            healthModifierController.data.ValueHasChangedPlayerGetSet = false;
        }

        public void giveHealthToEnemy(Creature creature, int selectEnemy, float value)
        {
            // If a enemy is spawning and it is not confirmed set to default !
            // Give health value to the enemy via the Selection Menu
            healthValueEnemy = healthModifierValue.GiveHealthValueEnemyMenu(selectEnemy, healthModifierController.data.PureRandomSelectionGetSet, healthModifierController.data.selectorModifiersGetSet, healthModifierController.data.SelectorModifiersConfirmGetSet, value);
            // Set health for all creatures not hidden and that do no have the maxvalue set (except for player)
            if (!creature.isPlayer && creature.maxHealth != healthValueEnemy)
            {
                creature.maxHealth = healthValueEnemy;
                creature.currentHealth = healthValueEnemy;
                creature.data.health = (short)healthValueEnemy;
            }
            //Debug.Log("HealthModifier : Value changed !");
        }

        private void EventManager_onCreatureSpawn(Creature creature)
        {
            // If creature is not hidden and isn't the player and the selector not on default
            if (!creature.isPlayer && healthModifierController.data.SelecModeSelectorEnemyGetSet != 0)
            {
                // When a creature is spawning, start this coroutine
                GameManager.local.StartCoroutine(IEHealthModifier(creature));
            }
        }
    }
}
