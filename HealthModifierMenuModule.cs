using ThunderRoad;
using UnityEngine;
using UnityEngine.UI;

namespace HealthModifier
{
    public class HealthModifierMenuModule : MenuModule
    {
        private Text txtEnemyRandomHealthDesc;
        private Button btnPlayerHealth;
        private Button btnEnemyHealth;
        private Button btnSelectorRightPlayerHealth;
        private Button btnSelectorLeftPlayerHealth;
        private Button btnSelectorRightEnemyHealth;
        private Button btnSelectorLeftEnemyHealth;
        private Button btnSelectorRandomEnemyHealth;
        private GameObject objWeightedRandomModifiersHide;
        private Text txtSelectorTotalValueModifier;
        private Text txtSelectorTotalValueModifierDesc;
        private Text txtSelectorBeggarModifier;
        private Text txtSelectorPeasantModifier;
        private Text txtSelectorMilitiaModifier;
        private Text txtSelectorGladiatorModifier;
        private Text txtSelectorWarriorModifier;
        private Text txtSelectorKnightModifier;
        private Text txtSelectorLordModifier;
        private Text txtSelectorKingModifier;
        private Text txtSelectorDemiGodModifier;
        private Text txtSelectorGodModifier;
        private Text txtSelectorTitanModifier;
        private Button btnSelectorConfirm;
        private Button btnSelectorRightBeggarModifier;
        private Button btnSelectorLeftBeggarModifier;
        private Button btnSelectorRightPeasantModifier;
        private Button btnSelectorLeftPeasantModifier;
        private Button btnSelectorRightMilitiaModifier;
        private Button btnSelectorLeftMilitiaModifier;
        private Button btnSelectorRightGladiatorModifier;
        private Button btnSelectorLeftGladiatorModifier;
        private Button btnSelectorRightWarriorModifier;
        private Button btnSelectorLeftWarriorModifier;
        private Button btnSelectorRightKnightModifier;
        private Button btnSelectorLeftKnightModifier;
        private Button btnSelectorRightLordModifier;
        private Button btnSelectorLeftLordModifier;
        private Button btnSelectorRightKingModifier;
        private Button btnSelectorLeftKingModifier;
        private Button btnSelectorRightDemiGodModifier;
        private Button btnSelectorLeftDemiGodModifier;
        private Button btnSelectorRightGodModifier;
        private Button btnSelectorLeftGodModifier;
        private Button btnSelectorRightTitanModifier;
        private Button btnSelectorLeftTitanModifier;
        private bool valueChanged;
        private bool ConfirmModifierisOk;
        private string txtSelectorTemp;
        public HealthModifierController healthModifierController;
        public HealthModifierHook healthModifierHook;
        private int valueDefaultPlayerHealthPercent = 100;
        private int valueDefaultEnemyHealthPercent = 100;
        private int nbSelectorPlayerHealth = 2;
        private int nbSelectorEnemyHealth = 3;
        private int nbSelectorRanksModifier = 11;

        public override void Init(MenuData menuData, Menu menu)
        {
            base.Init(menuData, menu);

            // Grab the value from Unity
            btnPlayerHealth = menu.GetCustomReference("btn_PlayerHealth").GetComponent<Button>();
            btnEnemyHealth = menu.GetCustomReference("btn_EnemyHealth").GetComponent<Button>();
            txtEnemyRandomHealthDesc = menu.GetCustomReference("txt_EnemyRandomHealthDesc").GetComponent<Text>();
            btnSelectorRightPlayerHealth = menu.GetCustomReference("btn_SelectorRightPlayerHealth").GetComponent<Button>();
            btnSelectorLeftPlayerHealth = menu.GetCustomReference("btn_SelectorLeftPlayerHealth").GetComponent<Button>();
            btnSelectorRightEnemyHealth = menu.GetCustomReference("btn_SelectorRightEnemyHealth").GetComponent<Button>();
            btnSelectorLeftEnemyHealth = menu.GetCustomReference("btn_SelectorLeftEnemyHealth").GetComponent<Button>();
            btnSelectorRandomEnemyHealth = menu.GetCustomReference("btn_SelectorRandomEnemyHealth").GetComponent<Button>();
            objWeightedRandomModifiersHide = menu.GetCustomReference("obj_WeightedRandomModifiersHide").gameObject;
            txtSelectorTotalValueModifier = menu.GetCustomReference("txt_SelectorTotalModifierValue").GetComponent<Text>();
            txtSelectorBeggarModifier = menu.GetCustomReference("txt_SelectorBeggarModifier").GetComponent<Text>();
            txtSelectorPeasantModifier = menu.GetCustomReference("txt_SelectorPeasantModifier").GetComponent<Text>();
            txtSelectorMilitiaModifier = menu.GetCustomReference("txt_SelectorMilitiaModifier").GetComponent<Text>();
            txtSelectorGladiatorModifier = menu.GetCustomReference("txt_SelectorGladiatorModifier").GetComponent<Text>();
            txtSelectorWarriorModifier = menu.GetCustomReference("txt_SelectorWarriorModifier").GetComponent<Text>();
            txtSelectorKnightModifier = menu.GetCustomReference("txt_SelectorKnightModifier").GetComponent<Text>();
            txtSelectorLordModifier = menu.GetCustomReference("txt_SelectorLordModifier").GetComponent<Text>();
            txtSelectorKingModifier = menu.GetCustomReference("txt_SelectorKingModifier").GetComponent<Text>();
            txtSelectorDemiGodModifier = menu.GetCustomReference("txt_SelectorDemiGodModifier").GetComponent<Text>();
            txtSelectorGodModifier = menu.GetCustomReference("txt_SelectorGodModifier").GetComponent<Text>();
            txtSelectorTitanModifier = menu.GetCustomReference("txt_SelectorTitanModifier").GetComponent<Text>();
            txtSelectorTotalValueModifierDesc = menu.GetCustomReference("txt_SelectorTotalModifierValueDesc").GetComponent<Text>();
            btnSelectorConfirm = menu.GetCustomReference("btn_SelectorConfirm").GetComponent<Button>();
            btnSelectorRightBeggarModifier = menu.GetCustomReference("btn_SelectorRightBeggarModifier").GetComponent<Button>();
            btnSelectorLeftBeggarModifier = menu.GetCustomReference("btn_SelectorLeftBeggarModifier").GetComponent<Button>();
            btnSelectorRightPeasantModifier = menu.GetCustomReference("btn_SelectorRightPeasantModifier").GetComponent<Button>();
            btnSelectorLeftPeasantModifier = menu.GetCustomReference("btn_SelectorLeftPeasantModifier").GetComponent<Button>();
            btnSelectorRightMilitiaModifier = menu.GetCustomReference("btn_SelectorRightMilitiaModifier").GetComponent<Button>();
            btnSelectorLeftMilitiaModifier = menu.GetCustomReference("btn_SelectorLeftMilitiaModifier").GetComponent<Button>();
            btnSelectorRightGladiatorModifier = menu.GetCustomReference("btn_SelectorRightGladiatorModifier").GetComponent<Button>();
            btnSelectorLeftGladiatorModifier = menu.GetCustomReference("btn_SelectorLeftGladiatorModifier").GetComponent<Button>();
            btnSelectorRightWarriorModifier = menu.GetCustomReference("btn_SelectorRightWarriorModifier").GetComponent<Button>();
            btnSelectorLeftWarriorModifier = menu.GetCustomReference("btn_SelectorLeftWarriorModifier").GetComponent<Button>();
            btnSelectorRightKnightModifier = menu.GetCustomReference("btn_SelectorRightKnightModifier").GetComponent<Button>();
            btnSelectorLeftKnightModifier = menu.GetCustomReference("btn_SelectorLeftKnightModifier").GetComponent<Button>();
            btnSelectorRightLordModifier = menu.GetCustomReference("btn_SelectorRightLordModifier").GetComponent<Button>();
            btnSelectorLeftLordModifier = menu.GetCustomReference("btn_SelectorLeftLordModifier").GetComponent<Button>();
            btnSelectorRightKingModifier = menu.GetCustomReference("btn_SelectorRightKingModifier").GetComponent<Button>();
            btnSelectorLeftKingModifier = menu.GetCustomReference("btn_SelectorLeftKingModifier").GetComponent<Button>();
            btnSelectorRightDemiGodModifier = menu.GetCustomReference("btn_SelectorRightDemiGodModifier").GetComponent<Button>();
            btnSelectorLeftDemiGodModifier = menu.GetCustomReference("btn_SelectorLeftDemiGodModifier").GetComponent<Button>();
            btnSelectorRightGodModifier = menu.GetCustomReference("btn_SelectorRightGodModifier").GetComponent<Button>();
            btnSelectorLeftGodModifier = menu.GetCustomReference("btn_SelectorLeftGodModifier").GetComponent<Button>();
            btnSelectorRightTitanModifier = menu.GetCustomReference("btn_SelectorRightTitanModifier").GetComponent<Button>();
            btnSelectorLeftTitanModifier = menu.GetCustomReference("btn_SelectorLeftTitanModifier").GetComponent<Button>();

            // Add an event listener for buttons
            btnPlayerHealth.onClick.AddListener(ClickBtnPlayerHealth);
            btnEnemyHealth.onClick.AddListener(ClickBtnEnemyHealth);
            btnSelectorRightPlayerHealth.onClick.AddListener(ClickSelectorRightPlayerHealth);
            btnSelectorLeftPlayerHealth.onClick.AddListener(ClickSelectorLeftPlayerHealth);
            btnSelectorRightEnemyHealth.onClick.AddListener(ClickSelectorRightEnemyHealth);
            btnSelectorLeftEnemyHealth.onClick.AddListener(ClickSelectorLeftEnemyHealth);
            btnSelectorRandomEnemyHealth.onClick.AddListener(ClickSelectorPureRandomEnemyHealth);
            btnSelectorConfirm.onClick.AddListener(ClickSelectorConfirm);
            btnSelectorRightBeggarModifier.onClick.AddListener(ClickSelectorRightBeggarModifier);
            btnSelectorLeftBeggarModifier.onClick.AddListener(ClickSelectorLeftBeggarModifier);
            btnSelectorRightPeasantModifier.onClick.AddListener(ClickSelectorRightPeasantModifier);
            btnSelectorLeftPeasantModifier.onClick.AddListener(ClickSelectorLeftPeasantModifier);
            btnSelectorRightMilitiaModifier.onClick.AddListener(ClickSelectorRightMilitiaModifier);
            btnSelectorLeftMilitiaModifier.onClick.AddListener(ClickSelectorLeftMilitiaModifier);
            btnSelectorRightGladiatorModifier.onClick.AddListener(ClickSelectorRightGladiatorModifier);
            btnSelectorLeftGladiatorModifier.onClick.AddListener(ClickSelectorLeftGladiatorModifier);
            btnSelectorRightWarriorModifier.onClick.AddListener(ClickSelectorRightWarriorModifier);
            btnSelectorLeftWarriorModifier.onClick.AddListener(ClickSelectorLeftWarriorModifier);
            btnSelectorRightKnightModifier.onClick.AddListener(ClickSelectorRightKnightModifier);
            btnSelectorLeftKnightModifier.onClick.AddListener(ClickSelectorLeftKnightModifier);
            btnSelectorRightLordModifier.onClick.AddListener(ClickSelectorRightLordModifier);
            btnSelectorLeftLordModifier.onClick.AddListener(ClickSelectorLeftLordModifier);
            btnSelectorRightKingModifier.onClick.AddListener(ClickSelectorRightKingModifier);
            btnSelectorLeftKingModifier.onClick.AddListener(ClickSelectorLeftKingModifier);
            btnSelectorRightDemiGodModifier.onClick.AddListener(ClickSelectorRightDemiGodModifier);
            btnSelectorLeftDemiGodModifier.onClick.AddListener(ClickSelectorLeftDemiGodModifier);
            btnSelectorRightGodModifier.onClick.AddListener(ClickSelectorRightGodModifier);
            btnSelectorLeftGodModifier.onClick.AddListener(ClickSelectorLeftGodModifier);
            btnSelectorRightTitanModifier.onClick.AddListener(ClickSelectorRightTitanModifier);
            btnSelectorLeftTitanModifier.onClick.AddListener(ClickSelectorLeftTitanModifier);

            // Initialization of datas

            healthModifierController = GameManager.local.gameObject.AddComponent<HealthModifierController>();
            healthModifierController.data.SelecModeSelectorEnemyGetSet = 0;
            healthModifierController.data.SelecModeSelectorPlayerGetSet = 0;
            healthModifierController.data.PureRandomSelectionGetSet = true;
            healthModifierController.data.nbRankModifiersGetSet = nbSelectorRanksModifier;
            healthModifierController.data.selectorModifiersGetSet = new int[nbSelectorRanksModifier];
            healthModifierController.data.ErrorModifiersGetSet = false;
            healthModifierController.data.ValueHasChangedPlayerGetSet = false;
            healthModifierController.data.ValueHasChangedEnemyGetSet = false;
            healthModifierController.data.ValueHealthPlayerGetSet = valueDefaultPlayerHealthPercent;
            healthModifierController.data.ValueHealthEnemyGetSet = valueDefaultEnemyHealthPercent;

            healthModifierHook = menu.gameObject.AddComponent<HealthModifierHook>();
            healthModifierHook.menu = this;
            // Update all the Data for left page (text, visibility of buttons etc...)
            UpdateDataPageLeft1();
            // Update all the Data for right page (text, visibility of buttons etc...)
            UpdateDataPageRight1();
        }

        public void ChangeTextPlayerHealth()
        {
            /* Values Selectable for player :
            *   Value00 at 100; 100%
            *   Value01 at Value;  Value%
            *   Default at 100;  100%
            */
            // For button switch
            switch (healthModifierController.data.SelecModeSelectorPlayerGetSet)
            {
                case 0:
                    btnPlayerHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "Default";
                    break;
                case 1:
                    btnPlayerHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = healthModifierController.data.ValueHealthPlayerGetSet.ToString() + "%";
                    break;
                default:
                    btnPlayerHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "Default";
                    break;
            }
        }

        public void ChangeTextEnemyHealth()
        {
            /* Values Selectable for enemies :
            *   Value00 at 50;  100%
            *   Value01 at SliderValue / 2;  Slider%
            *   Value02 at null ; Random mode
            *   Default at 50;  100%
            */
            // For button switch
            switch (healthModifierController.data.SelecModeSelectorEnemyGetSet)
            {
                case 0:
                    btnEnemyHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "Default";
                    break;
                case 1:
                    btnEnemyHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = healthModifierController.data.ValueHealthEnemyGetSet.ToString() + "%";
                    break;
                case 2:
                    btnEnemyHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "Random";
                    break;
                default:
                    btnEnemyHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "Default";
                    break;
            }
        }

        public void ClickBtnPlayerHealth()
        {
            if (healthModifierController.data.SelecModeSelectorPlayerGetSet == 1)
            {
                healthModifierController.data.ValueToAssignIsUint = true;
                healthModifierController.data.ButtonPlayerHealthPressedGetSet = true;
            }
        }
        public void ClickBtnEnemyHealth()
        {
            if (healthModifierController.data.SelecModeSelectorEnemyGetSet == 1)
            {
                healthModifierController.data.ValueToAssignIsUint = true;
                healthModifierController.data.ButtonEnemyHealthPressedGetSet = true;
            }
        }

        // Change the value of the selector "SelecModeSelectorPlayer" in the "HealthModifierLevelModule" Class (allow to select different value until the selector reach 1, can't go to 2)
        // at 1, it disables the button
        public void ClickSelectorRightPlayerHealth()
        {
            if (healthModifierController.data.SelecModeSelectorPlayerGetSet >= 0 && healthModifierController.data.SelecModeSelectorPlayerGetSet < nbSelectorPlayerHealth - 1)
            {
                healthModifierController.data.SelecModeSelectorPlayerGetSet++;
                healthModifierController.data.SelectorHasChangedPlayerGetSet = true;
            }
            ChangeTextPlayerHealth();
            UpdateDataPageLeft1();
        }
        // Change the value of the selector "SelecModeSelectorPlayer" in the "HealthModifierLevelModule" Class (allow to select different value until the selector reach 0, can't go to -1)
        // at 0, it disables the button
        public void ClickSelectorLeftPlayerHealth()
        {
            if (healthModifierController.data.SelecModeSelectorPlayerGetSet > 0 && healthModifierController.data.SelecModeSelectorPlayerGetSet <= nbSelectorPlayerHealth - 1)
            {
                healthModifierController.data.SelecModeSelectorPlayerGetSet--;
                healthModifierController.data.SelectorHasChangedPlayerGetSet = true;
            }
            ChangeTextPlayerHealth();
            UpdateDataPageLeft1();
        }

        // Change the value of the selector "selecModeSelectorEnemy" in the "HealthModifierLevelModule" Class (allow to select different value until the selector reach 2, can't go to 3)
        // at 2, it disables the button
        public void ClickSelectorRightEnemyHealth()
        {
            if (healthModifierController.data.SelecModeSelectorEnemyGetSet >= 0 && healthModifierController.data.SelecModeSelectorEnemyGetSet < nbSelectorEnemyHealth - 1)
                healthModifierController.data.SelecModeSelectorEnemyGetSet++;
            ChangeTextEnemyHealth();
            UpdateDataPageLeft1();
        }
        // Change the value of the selector "selecModeSelectorEnemy" in the "HealthModifierLevelModule" Class (allow to select different value until the selector reach 0, can't go to -1)
        // at 0, it disables the button
        public void ClickSelectorLeftEnemyHealth()
        {
            if (healthModifierController.data.SelecModeSelectorEnemyGetSet > 0 && healthModifierController.data.SelecModeSelectorEnemyGetSet <= nbSelectorEnemyHealth - 1)
                healthModifierController.data.SelecModeSelectorEnemyGetSet--;
            ChangeTextEnemyHealth();
            UpdateDataPageLeft1();
        }
        // Allow to enable or disable the pure random mode
        // Disable pure random mode lead to weighted random mode (a bit more balance)
        public void ClickSelectorPureRandomEnemyHealth()
        {
            healthModifierController.data.PureRandomSelectionGetSet = !healthModifierController.data.PureRandomSelectionGetSet;
            UpdateDataPageLeft1();
        }

        public void ChangeTextSelectorTotalValueModifier()
        {
            int num = 0;
            for (int index = 0; index <= healthModifierController.data.nbRankModifiersGetSet - 1; index++)
                num += healthModifierController.data.selectorModifiersGetSet[index];
            if (num == 0)
            {
                txtSelectorTotalValueModifierDesc.gameObject.SetActive(false);
                txtSelectorTotalValueModifier.gameObject.SetActive(false);
                txtSelectorTotalValueModifier.text = num.ToString() + "%";
            }
            else
            {
                if (!txtSelectorTotalValueModifierDesc.gameObject.activeSelf)
                    txtSelectorTotalValueModifierDesc.gameObject.SetActive(true);
                if (!txtSelectorTotalValueModifier.gameObject.activeSelf)
                    txtSelectorTotalValueModifier.gameObject.SetActive(true);
                txtSelectorTotalValueModifier.text = ((int)((num - healthModifierController.data.nbRankModifiersGetSet) * 5.0)).ToString() + "%";
            }
        }

        public void ChangeTextSelectorModifier(int i)
        {
            /* Values Selector modifier :
            *   Value00 ; Default probabilities
            *   Value01 ; 0%
            *   Value02 ; 5%
            *   Value03 ; 10%
            *   Value04 ; 15%
            *   Value05 ; 20%
            *   Value06 ; 25%
            *   Value07 ; 30%
            *   Value08 ; 35%
            *   Value09 ; 40%
            *   Value10 ; 45%
            *   Value11 ; 50%
            *   Value12 ; 55%
            *   Value13 ; 60%
            *   Value14 ; 65%
            *   Value15 ; 70%
            *   Value16 ; 75%
            *   Value17 ; 80%
            *   Value18 ; 85%
            *   Value19 ; 90%
            *   Value20 ; 95%
            *   Value21 ; 100%
            *   Default ; Default
            */
            switch (healthModifierController.data.selectorModifiersGetSet[i])
            {
                case 0:
                    txtSelectorTemp = "Default";
                    break;
                case 1:
                    txtSelectorTemp = "0%";
                    break;
                case 2:
                    txtSelectorTemp = "5%";
                    break;
                case 3:
                    txtSelectorTemp = "10%";
                    break;
                case 4:
                    txtSelectorTemp = "15%";
                    break;
                case 5:
                    txtSelectorTemp = "20%";
                    break;
                case 6:
                    txtSelectorTemp = "25%";
                    break;
                case 7:
                    txtSelectorTemp = "30%";
                    break;
                case 8:
                    txtSelectorTemp = "35%";
                    break;
                case 9:
                    txtSelectorTemp = "40%";
                    break;
                case 10:
                    txtSelectorTemp = "45%";
                    break;
                case 11:
                    txtSelectorTemp = "50%";
                    break;
                case 12:
                    txtSelectorTemp = "55%";
                    break;
                case 13:
                    txtSelectorTemp = "60%";
                    break;
                case 14:
                    txtSelectorTemp = "65%";
                    break;
                case 15:
                    txtSelectorTemp = "70%";
                    break;
                case 16:
                    txtSelectorTemp = "75%";
                    break;
                case 17:
                    txtSelectorTemp = "80%";
                    break;
                case 18:
                    txtSelectorTemp = "85%";
                    break;
                case 19:
                    txtSelectorTemp = "90%";
                    break;
                case 20:
                    txtSelectorTemp = "95%";
                    break;
                case 21:
                    txtSelectorTemp = "100%";
                    break;
                default:
                    txtSelectorTemp = "Default";
                    break;
            }
            // Change text for each selector
            /* Values Selector modifier :
            *   Value00 ; Beggar
            *   Value01 ; Peasant
            *   Value02 ; Militia
            *   Value03 ; Gladiator
            *   Value04 ; Warrior
            *   Value05 ; Knight
            *   Value06 ; Lord
            *   Value07 ; King
            *   Value08 ; DemiGod
            *   Value09 ; God
            *   Value10 ; Titan
            */
            switch (i)
            {
                case 0:
                    txtSelectorBeggarModifier.text = txtSelectorTemp;
                    break;
                case 1:
                    txtSelectorPeasantModifier.text = txtSelectorTemp;
                    break;
                case 2:
                    txtSelectorMilitiaModifier.text = txtSelectorTemp;
                    break;
                case 3:
                    txtSelectorGladiatorModifier.text = txtSelectorTemp;
                    break;
                case 4:
                    txtSelectorWarriorModifier.text = txtSelectorTemp;
                    break;
                case 5:
                    txtSelectorKnightModifier.text = txtSelectorTemp;
                    break;
                case 6:
                    txtSelectorLordModifier.text = txtSelectorTemp;
                    break;
                case 7:
                    txtSelectorKingModifier.text = txtSelectorTemp;
                    break;
                case 8:
                    txtSelectorDemiGodModifier.text = txtSelectorTemp;
                    break;
                case 9:
                    txtSelectorGodModifier.text = txtSelectorTemp;
                    break;
                case 10:
                    txtSelectorTitanModifier.text = txtSelectorTemp;
                    break;
            }
        }
        // Change value until selector reach 100%
        // selectorModifiersGetSet[0] = Beggar
        public void ClickSelectorRightBeggarModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[0] >= 0 && healthModifierController.data.selectorModifiersGetSet[0] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[0]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(0);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftBeggarModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[0] > 0 && healthModifierController.data.selectorModifiersGetSet[0] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[0]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(0);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[1] = Peasant
        public void ClickSelectorRightPeasantModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[1] >= 0 && healthModifierController.data.selectorModifiersGetSet[1] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[1]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(1);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftPeasantModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[1] > 0 && healthModifierController.data.selectorModifiersGetSet[1] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[1]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(1);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[2] = Militia
        public void ClickSelectorRightMilitiaModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[2] >= 0 && healthModifierController.data.selectorModifiersGetSet[2] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[2]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(2);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftMilitiaModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[2] > 0 && healthModifierController.data.selectorModifiersGetSet[2] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[2]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(2);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[3] = Gladiator
        public void ClickSelectorRightGladiatorModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[3] >= 0 && healthModifierController.data.selectorModifiersGetSet[3] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[3]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(3);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftGladiatorModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[3] > 0 && healthModifierController.data.selectorModifiersGetSet[3] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[3]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(3);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[4] = Warrior
        public void ClickSelectorRightWarriorModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[4] >= 0 && healthModifierController.data.selectorModifiersGetSet[4] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[4]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(4);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftWarriorModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[4] > 0 && healthModifierController.data.selectorModifiersGetSet[4] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[4]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(4);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[5] = Knight
        public void ClickSelectorRightKnightModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[5] >= 0 && healthModifierController.data.selectorModifiersGetSet[5] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[5]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(5);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftKnightModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[5] > 0 && healthModifierController.data.selectorModifiersGetSet[5] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[5]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(5);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[6] = Lord
        public void ClickSelectorRightLordModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[6] >= 0 && healthModifierController.data.selectorModifiersGetSet[6] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[6]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(6);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftLordModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[6] > 0 && healthModifierController.data.selectorModifiersGetSet[6] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[6]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(6);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[7] = King
        public void ClickSelectorRightKingModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[7] >= 0 && healthModifierController.data.selectorModifiersGetSet[7] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[7]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(7);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftKingModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[7] > 0 && healthModifierController.data.selectorModifiersGetSet[7] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[7]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(7);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[8] = DemiGod
        public void ClickSelectorRightDemiGodModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[8] >= 0 && healthModifierController.data.selectorModifiersGetSet[8] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[8]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(8);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftDemiGodModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[8] > 0 && healthModifierController.data.selectorModifiersGetSet[8] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[8]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(8);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[9] = God
        public void ClickSelectorRightGodModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[9] >= 0 && healthModifierController.data.selectorModifiersGetSet[9] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[9]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(9);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftGodModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[9] > 0 && healthModifierController.data.selectorModifiersGetSet[9] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[9]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(9);
            UpdateDataPageRight1();
        }
        // selectorModifiersGetSet[10] = Titan
        public void ClickSelectorRightTitanModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[10] >= 0 && healthModifierController.data.selectorModifiersGetSet[10] < 21)
            {
                healthModifierController.data.selectorModifiersGetSet[10]++;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(10);
            UpdateDataPageRight1();
        }

        public void ClickSelectorLeftTitanModifier()
        {
            if (healthModifierController.data.selectorModifiersGetSet[10] > 0 && healthModifierController.data.selectorModifiersGetSet[10] <= 21)
            {
                healthModifierController.data.selectorModifiersGetSet[10]--;
                valueChanged = true;
            }
            ChangeTextSelectorModifier(10);
            UpdateDataPageRight1();
        }
        // When selector is click change display to Error or Confirmed
        public void ClickSelectorConfirm()
        {
            ConfirmModifierisOk = checkIfCanConfirm();
            btnSelectorConfirm.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = ConfirmModifierisOk ? "Confirmed" : "Error";
            UpdateDataPageRight1();
        }
        // Calculate the total value of modifier (in %)
        public float CalculateValueModifierTotal()
        {
            int num = 0;
            for (int index = 0; index <= healthModifierController.data.nbRankModifiersGetSet - 1; index++)
                num += healthModifierController.data.selectorModifiersGetSet[index];
            return (float)((num - healthModifierController.data.nbRankModifiersGetSet) * 5.0);
        }

        public int CalculateValueSelectorTotal()
        {
            int num = 0;
            for (int index = 0; index <= healthModifierController.data.nbRankModifiersGetSet - 1; index++)
                num += healthModifierController.data.selectorModifiersGetSet[index];
            return num;
        }

        public bool checkIfCanConfirm()
        {
            float valueModifierTotal = CalculateValueModifierTotal();
            return (double)valueModifierTotal == 100.0 || (double)valueModifierTotal == -(healthModifierController.data.nbRankModifiersGetSet * 5);
        }
        // Function to reset to Default or set to 0 all modifiers if one reach default or 0
        public void switchModifierToZeroOrDefault(bool forcetoDefault)
        {
            bool switchToZero = false;
            bool switchToDefault = false;
            // Change all the selector to 0 if only one is pressed to 0 and the rest in Default
            if (CalculateValueSelectorTotal() == 1)
                switchToZero = true;
            if (switchToZero == true)
            {
                for (int index = 0; index <= healthModifierController.data.nbRankModifiersGetSet - 1; index++)
                    healthModifierController.data.selectorModifiersGetSet[index] = 1;
                switchToZero = false;
            }
            // Change all the selector to Default if only one is pressed to Default and the rest is at another value
            for (int index = 0; index <= healthModifierController.data.nbRankModifiersGetSet - 1; index++)
            {
                if (healthModifierController.data.selectorModifiersGetSet[index] == 0)
                    switchToDefault = true;
            }
            if (forcetoDefault)
                switchToDefault = true;
            if (switchToDefault)
            {
                for (int index = 0; index <= healthModifierController.data.nbRankModifiersGetSet - 1; index++)
                    healthModifierController.data.selectorModifiersGetSet[index] = 0;
                switchToDefault = false;
            }

        }

        public void ValueToAssign()
        {
            //Assign a value when enter keyboard is pressed
            if (healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet == true)
            {
                // Assign the value of player's health
                if (healthModifierController.data.ButtonPlayerHealthPressedGetSet == true)
                {
                    healthModifierController.data.ButtonEnemyHealthPressedGetSet = false;
                    healthModifierController.data.ValueHealthPlayerGetSet = healthModifierController.data.ValueToAssignedUintGetSet;
                    healthModifierController.data.ButtonPlayerHealthPressedGetSet = false;
                    healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet = false;
                    healthModifierController.data.ValueHasChangedPlayerGetSet = true;
                }
                // Assign the value of enemy's health
                if (healthModifierController.data.ButtonEnemyHealthPressedGetSet == true)
                {
                    healthModifierController.data.ButtonPlayerHealthPressedGetSet = false;

                    healthModifierController.data.ValueHealthEnemyGetSet = healthModifierController.data.ValueToAssignedUintGetSet;
                    healthModifierController.data.ButtonEnemyHealthPressedGetSet = false;
                    healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet = false;
                    healthModifierController.data.ValueHasChangedEnemyGetSet = true;
                }
            }
        }

        public void UpdateDataPageLeft1()
        {
            ValueToAssign();
            // Set to change the value in the level module
            ChangeTextPlayerHealth();
            ChangeTextEnemyHealth();
            // Change text when clicked
            btnSelectorRandomEnemyHealth.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = healthModifierController.data.PureRandomSelectionGetSet ? "Disabled " : "Enabled";

            // Disable arrows when they reach the hightest or lowest value
            if (healthModifierController.data.SelecModeSelectorPlayerGetSet >= nbSelectorPlayerHealth - 1)
                btnSelectorRightPlayerHealth.enabled = false;
            else
                btnSelectorRightPlayerHealth.enabled = true;
            if (healthModifierController.data.SelecModeSelectorPlayerGetSet <= 0)
                btnSelectorLeftPlayerHealth.enabled = false;
            else
                btnSelectorLeftPlayerHealth.enabled = true;

            if (healthModifierController.data.SelecModeSelectorEnemyGetSet >= nbSelectorEnemyHealth - 1)
                btnSelectorRightEnemyHealth.enabled = false;
            else
                btnSelectorRightEnemyHealth.enabled = true;
            if (healthModifierController.data.SelecModeSelectorEnemyGetSet <= 0)
                btnSelectorLeftEnemyHealth.enabled = false;
            else
                btnSelectorLeftEnemyHealth.enabled = true;

            // Display the weighted randomness when enemy health is set to Random
            if (healthModifierController.data.SelecModeSelectorEnemyGetSet == nbSelectorEnemyHealth - 1)
            {
                txtEnemyRandomHealthDesc.gameObject.SetActive(true);
                btnSelectorRandomEnemyHealth.gameObject.SetActive(true);
            }
            else
            {
                txtEnemyRandomHealthDesc.gameObject.SetActive(false);
                btnSelectorRandomEnemyHealth.gameObject.SetActive(false);
            }
            // Display the weighted randomness modifiers when enemy health is set to Random and random weightness set to enabled
            if (btnSelectorRandomEnemyHealth.IsActive() && !healthModifierController.data.PureRandomSelectionGetSet)
                objWeightedRandomModifiersHide.SetActive(true);
            else
                objWeightedRandomModifiersHide.SetActive(false);
        }

        public void UpdateDataPageRight1()
        {
            ValueToAssign();
            // Change to default if error in value
            if (healthModifierController.data.ErrorModifiersGetSet)
            {
                switchModifierToZeroOrDefault(healthModifierController.data.ErrorModifiersGetSet);
                healthModifierController.data.ErrorModifiersGetSet = false;
            }
            else
                switchModifierToZeroOrDefault(false);
            for (int i = 0; i <= healthModifierController.data.nbRankModifiersGetSet - 1; i++)
            {
                ChangeTextSelectorModifier(i);
            }
            ChangeTextSelectorTotalValueModifier();
            // Change the text to Confirm ? when a modifier button is pressed
            if (valueChanged == true)
            {
                ConfirmModifierisOk = false;
                btnSelectorConfirm.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "Confirm ?";
                valueChanged = false;
            }
            healthModifierController.data.SelectorModifiersConfirmGetSet = ConfirmModifierisOk;
            // Disable arrow if more than 21 or less than 0
            if (healthModifierController.data.selectorModifiersGetSet[0] >= 21)
                btnSelectorRightBeggarModifier.enabled = false;
            else
                btnSelectorRightBeggarModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[0] <= 0)
                btnSelectorLeftBeggarModifier.enabled = false;
            else
                btnSelectorLeftBeggarModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[1] >= 21)
                btnSelectorRightPeasantModifier.enabled = false;
            else
                btnSelectorRightPeasantModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[1] <= 0)
                btnSelectorLeftPeasantModifier.enabled = false;
            else
                btnSelectorLeftPeasantModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[2] >= 21)
                btnSelectorRightMilitiaModifier.enabled = false;
            else
                btnSelectorRightMilitiaModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[2] <= 0)
                btnSelectorLeftMilitiaModifier.enabled = false;
            else
                btnSelectorLeftMilitiaModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[3] >= 21)
                btnSelectorRightGladiatorModifier.enabled = false;
            else
                btnSelectorRightGladiatorModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[3] <= 0)
                btnSelectorLeftGladiatorModifier.enabled = false;
            else
                btnSelectorLeftGladiatorModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[4] >= 21)
                btnSelectorRightWarriorModifier.enabled = false;
            else
                btnSelectorRightWarriorModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[4] <= 0)
                btnSelectorLeftWarriorModifier.enabled = false;
            else
                btnSelectorLeftWarriorModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[5] >= 21)
                btnSelectorRightKnightModifier.enabled = false;
            else
                btnSelectorRightKnightModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[5] <= 0)
                btnSelectorLeftKnightModifier.enabled = false;
            else
                btnSelectorLeftKnightModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[6] >= 21)
                btnSelectorRightLordModifier.enabled = false;
            else
                btnSelectorRightLordModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[6] <= 0)
                btnSelectorLeftLordModifier.enabled = false;
            else
                btnSelectorLeftLordModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[7] >= 21)
                btnSelectorRightKingModifier.enabled = false;
            else
                btnSelectorRightKingModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[7] <= 0)
                btnSelectorLeftKingModifier.enabled = false;
            else
                btnSelectorLeftKingModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[8] >= 21)
                btnSelectorRightDemiGodModifier.enabled = false;
            else
                btnSelectorRightDemiGodModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[8] <= 0)
                btnSelectorLeftDemiGodModifier.enabled = false;
            else
                btnSelectorLeftDemiGodModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[9] >= 21)
                btnSelectorRightGodModifier.enabled = false;
            else
                btnSelectorRightGodModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[9] <= 0)
                btnSelectorLeftGodModifier.enabled = false;
            else
                btnSelectorLeftGodModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[10] >= 21)
                btnSelectorRightTitanModifier.enabled = false;
            else
                btnSelectorRightTitanModifier.enabled = true;
            if (healthModifierController.data.selectorModifiersGetSet[10] <= 0)
                btnSelectorLeftTitanModifier.enabled = false;
            else
                btnSelectorLeftTitanModifier.enabled = true;
        }
        // Refresh the menu each frame (need optimization)
        public class HealthModifierHook : MonoBehaviour
        {
            public HealthModifierMenuModule menu;
            void Update()
            {
                menu.UpdateDataPageLeft1();
                menu.UpdateDataPageRight1();
            }
        }
    }
}
