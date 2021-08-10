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
        private float sliderHealthPlayer;
        private float sliderHealthEnemy;
        private bool pureRandomSelection;
        private bool sliderHealthPlayerHasChanged;
        private float healthValueEnemy;
        private float healthValuePlayer;

    // Execute at the loading of the level
    public override System.Collections.IEnumerator OnLoadCoroutine(Level level)
        {
            // 
            healthModifierController = GameManager.local.gameObject.GetComponent<HealthModifierController>();
            // Create an event manager on creature spawn
            EventManager.onCreatureSpawn += EventManager_onCreatureSpawn;

            return base.OnLoadCoroutine(level);
        }

        public override void Update(Level level)
        {
            if (healthModifierController == null)
            {
                healthModifierController = GameManager.local.gameObject.GetComponent<HealthModifierController>();
                return;
            }
            else
            {
                sliderHealthPlayerHasChanged = healthModifierController.data.SliderHasChangedPlayerGetSet;
                if (sliderHealthPlayerHasChanged)
                {
                    foreach (Creature creature in Creature.list)
                    {
                        // If player
                        if (creature.isPlayer)
                        {
                            sliderHealthPlayer = healthModifierController.data.SliderValueHealthPlayerGetSet;
                            selectorPlayer = healthModifierController.data.SelecModeSelectorPlayerGetSet;
                            giveHealthToPlayer(creature, selectorPlayer, sliderHealthPlayer);
                            healthModifierController.data.SliderHasChangedPlayerGetSet = false;
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
            sliderHealthPlayer = healthModifierController.data.SliderValueHealthPlayerGetSet;
            sliderHealthEnemy = healthModifierController.data.SliderValueHealthEnemyGetSet;
            giveHealthToEnemy(creature, selectorEnemy, sliderHealthEnemy);
            giveHealthToPlayer(creature, selectorPlayer, sliderHealthPlayer);
            yield return (object)null;
        }

        public void giveHealthToPlayer(Creature creature, int selectPlayer, float sliderValue)
        {
            // Give health value to the player via the Selection Menu
            healthValuePlayer = healthModifierValue.GiveHealthValuePlayerMenu(selectPlayer, sliderValue);
            // Set health for player and if his maxvalue is not set
            if (creature.isPlayer && creature.maxHealth != healthValuePlayer)
                {
                    creature.maxHealth = healthValuePlayer;
                    creature.currentHealth = healthValuePlayer;
                }
        }

        public void giveHealthToEnemy(Creature creature, int selectEnemy, float sliderValue)
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
            healthValueEnemy = healthModifierValue.GiveHealthValueEnemyMenu(selectEnemy, pureRandomSelection, tabValueModifier, ConfirmModifierRandom, sliderValue);
            // Set health for all creatures not hidden and that do no have the maxvalue set (except for player)
            if (!creature.isPlayer && creature.maxHealth != healthValueEnemy)
            {
                creature.maxHealth = healthValueEnemy;
                creature.currentHealth = healthValueEnemy;
            }
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
