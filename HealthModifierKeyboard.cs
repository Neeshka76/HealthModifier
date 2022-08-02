using System.Collections;
using ThunderRoad;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace HealthModifier
{
    public class HealthModifierKeyboard : LevelModule
    {
        private GameObject keyboard;
        AsyncOperationHandle<GameObject> handleKeyboard;
        private bool previousStateKeyboard = false;
        private bool currentStateKeyboard = false;
        private bool errorInput = false;
        private Button button0;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button buttonDot;
        private Button buttonEnter;
        private Button buttonPlusMinus;
        private Button buttonDelete;
        private Button buttonClear;
        private float valueToAssignFloat = 0.0f;
        private int valueToAssignInt = 0;
        private uint valueToAssignUint = 0;
        GameObject keyboardCanvas;
        private Text txtInput;
        private HealthModifierController healthModifierController;

        public override IEnumerator OnLoadCoroutine()
        {
            healthModifierController = GameManager.local.gameObject.GetComponent<HealthModifierController>();
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
                if (keyboard == null && Player.currentCreature != null)
                {
                    // Creates the Keyboard
                    handleKeyboard = Addressables.LoadAssetAsync<GameObject>("Neeshka.HealthModifier.Keyboard");
                    keyboard = handleKeyboard.WaitForCompletion();
                    keyboard = UnityEngine.Object.Instantiate(keyboard);
                    keyboard.SetActive(false);
                    keyboard.transform.SetParent(MenuBook.local.gameObject.transform);
                    keyboard.transform.localPosition = new Vector3(0f, 0.35f, 0.04f);
                    keyboard.transform.localRotation = MenuBook.local.gameObject.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                    keyboardCanvas = keyboard.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject;
                    txtInput = keyboard.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

                    button7 = keyboardCanvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();
                    button8 = keyboardCanvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
                    button9 = keyboardCanvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
                    button4 = keyboardCanvas.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();
                    button5 = keyboardCanvas.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
                    button6 = keyboardCanvas.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
                    button1 = keyboardCanvas.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();
                    button2 = keyboardCanvas.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
                    button3 = keyboardCanvas.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
                    buttonPlusMinus = keyboardCanvas.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();
                    button0 = keyboardCanvas.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
                    buttonDot = keyboardCanvas.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
                    buttonEnter = keyboardCanvas.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();
                    buttonClear = keyboardCanvas.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
                    buttonDelete = keyboardCanvas.transform.GetChild(4).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
                    // Add an event listener for buttons
                    button7.onClick.AddListener(ClickButton7);
                    button8.onClick.AddListener(ClickButton8);
                    button9.onClick.AddListener(ClickButton9);
                    button4.onClick.AddListener(ClickButton4);
                    button5.onClick.AddListener(ClickButton5);
                    button6.onClick.AddListener(ClickButton6);
                    button1.onClick.AddListener(ClickButton1);
                    button2.onClick.AddListener(ClickButton2);
                    button3.onClick.AddListener(ClickButton3);
                    button0.onClick.AddListener(ClickButton0);
                    buttonPlusMinus.onClick.AddListener(ClickButtonPlusMinus);
                    buttonDot.onClick.AddListener(ClickButtonDot);
                    buttonEnter.onClick.AddListener(ClickButtonEnter);
                    buttonClear.onClick.AddListener(ClickButtonClear);
                    buttonDelete.onClick.AddListener(ClickButtonDelete);
                    // Initialization of datas
                    healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet = false;
                    healthModifierController.data.ButtonPlayerHealthPressedGetSet = false;
                    healthModifierController.data.ButtonEnemyHealthPressedGetSet = false;
                }

                if (Player.currentCreature != null)
                {
                    currentStateKeyboard = (healthModifierController.data.ButtonPlayerHealthPressedGetSet
                        ^ healthModifierController.data.ButtonEnemyHealthPressedGetSet) && !keyboard.activeSelf;
                    // Rising edge
                    if (keyboard != null && currentStateKeyboard != previousStateKeyboard && previousStateKeyboard == false)
                    {
                        keyboard.SetActive(true);
                        keyboard.layer = 5;
                    }
                    // Deactivate the keyboard
                    if (healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet == true && keyboard.activeSelf)
                    {
                        keyboard.SetActive(false);
                    }
                    // Set the new state
                    previousStateKeyboard = currentStateKeyboard;
                }
            }
        }
        /*
        void ButtonClick(string text)
        {
            Debug.Log("DebugMenuPlus : TEXT BUTTON CLICK : " + text);
            switch (text)
            {
                case "Clear":
                    txtInput.text = "";
                break;
                case "Delete":
                    if (txtInput.text.Length != 0)
                    {
                        txtInput.text = txtInput.text.Remove(txtInput.text.Length - 1, 1);
                    }
                break;
                case "Enter":
                    //in this case, you may want to keep the "ClickButtonEnter()" function and call it from here
                    ClickButtonEnter();
                break;
                case "-":
                    if (txtInput.text.StartsWith("-"))
                    {
                        // Remove the - at the beginning of the string
                        txtInput.text = txtInput.text.Remove(0, 1);
                    }
                    else
                    {
                        // Add the - at the beginning of the string
                        txtInput.text = txtInput.text.Insert(0, "-");
                    }
                break;
                default:
                    if (errorInput == false)
                    {
                        txtInput.text += text;
                    }
                    else
                    {
                        txtInput.text = text;
                        errorInput = false;
                    }
                break;
            }
        }*/

        public void ClickButton7()
        {
            if (errorInput == false)
            {
                txtInput.text += "7";
            }
            else
            {
                txtInput.text = "7";
                errorInput = false;
            }
        }
        public void ClickButton8()
        {
            if (errorInput == false)
            {
                txtInput.text += "8";
            }
            else
            {
                txtInput.text = "8";
                errorInput = false;
            }
        }
        public void ClickButton9()
        {
            if (errorInput == false)
            {
                txtInput.text += "9";
            }
            else
            {
                txtInput.text = "9";
                errorInput = false;
            }
        }
        public void ClickButton4()
        {
            if (errorInput == false)
            {
                txtInput.text += "4";
            }
            else
            {
                txtInput.text = "4";
                errorInput = false;
            }
        }
        public void ClickButton5()
        {
            if (errorInput == false)
            {
                txtInput.text += "5";
            }
            else
            {
                txtInput.text = "5";
                errorInput = false;
            }
        }
        public void ClickButton6()
        {
            if (errorInput == false)
            {
                txtInput.text += "6";
            }
            else
            {
                txtInput.text = "6";
                errorInput = false;
            }
        }
        public void ClickButton1()
        {
            if (errorInput == false)
            {
                txtInput.text += "1";
            }
            else
            {
                txtInput.text = "1";
                errorInput = false;
            }
        }
        public void ClickButton2()
        {
            if (errorInput == false)
            {
                txtInput.text += "2";
            }
            else
            {
                txtInput.text = "2";
                errorInput = false;
            }
        }
        public void ClickButton3()
        {
            if (errorInput == false)
            {
                txtInput.text += "3";
            }
            else
            {
                txtInput.text = "3";
                errorInput = false;
            }
        }
        public void ClickButtonPlusMinus()
        {
            if (txtInput.text.StartsWith("-"))
            {
                // Remove the - at the beginning of the string
                txtInput.text = txtInput.text.Remove(0, 1);
            }
            else
            {
                // Add the - at the beginning of the string
                txtInput.text = txtInput.text.Insert(0, "-");
            }
        }
        public void ClickButton0()
        {
            if (errorInput == false)
            {
                txtInput.text += "0";
            }
            else
            {
                txtInput.text = "0";
                errorInput = false;
            }
        }
        public void ClickButtonDot()
        {
            if (errorInput == false)
            {
                txtInput.text += ".";
            }
            else
            {
                txtInput.text = ".";
                errorInput = false;
            }
        }
        public void ClickButtonEnter()
        {
            // Try if it's a float else display a message
            if (healthModifierController.data.ValueToAssignIsFloat == true)
            {
                if (float.TryParse(txtInput.text, out valueToAssignFloat))
                {
                    healthModifierController.data.ValueToAssignedFloatGetSet = valueToAssignFloat;
                    healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet = true;
                    healthModifierController.data.ValueToAssignIsFloat = false;
                    txtInput.text = "";
                }
                else
                {
                    txtInput.text = "Error, wrong format entered";
                    errorInput = true;
                }
            }
            if (healthModifierController.data.ValueToAssignIsInt == true)
            {
                if (int.TryParse(txtInput.text, out valueToAssignInt))
                {
                    healthModifierController.data.ValueToAssignedIntGetSet = valueToAssignInt;
                    healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet = true;
                    healthModifierController.data.ValueToAssignIsInt = false;
                    txtInput.text = "";
                }
                else
                {
                    txtInput.text = "Error, wrong format entered enter a value without decimals";
                    errorInput = true;
                }
            }
            if (healthModifierController.data.ValueToAssignIsUint == true)
            {
                if (uint.TryParse(txtInput.text, out valueToAssignUint))
                {
                    healthModifierController.data.ValueToAssignedUintGetSet = valueToAssignUint;
                    healthModifierController.data.KeyboardFinishEnterButtonPressedGetSet = true;
                    healthModifierController.data.ValueToAssignIsUint = false;
                    txtInput.text = "";

                }
                else
                {
                    txtInput.text = "Error, wrong format entered, enter a positive value without decimals";
                    errorInput = true;
                }
            }
        }
        public void ClickButtonClear()
        {
            // Clear the string
            txtInput.text = "";
        }
        public void ClickButtonDelete()
        {
            // Remove the last element of the string
            if (txtInput.text.Length != 0)
            {
                txtInput.text = txtInput.text.Remove(txtInput.text.Length - 1, 1);
            }
        }
    }
}
