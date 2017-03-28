using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Delivery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lbSizePizza.ClearSelected();
            lbSauce.ClearSelected();
            lbPizzaCrust.ClearSelected();
            lbToppings.ClearSelected();
            lbSpecialtyPizza.ClearSelected();
            txtName.Text = "";
            txtAddress.Text = "";
            txtContactNumber.Text = "";
            txtEmail.Text = "";
            MessageBox.Show("Form Reset.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtQuantity.Text.Remove(txtQuantity.Text.Length - 1);
            }
        }

        private enum CostFactor
        {
            Neapolitan = 50,
            Margherita = 60,
            Lazio = 70,
            Pepperoni = 80,
            Zucchini = 90,
            Hawaiian = 95,
            ChickenCaesar = 85,
            Cheese = 55,
            Veggie = 45,
            SmokeyMapleBacon = 100,
            CanadianMeatLover =105,
            BBQChicken = 110
        }

        private enum SizePizza
        {
            Small = 10,
            Medium = 20,
            Large = 30
        }

        private enum Beverages
        {
            Coke = 3,
            Pepsi = 3,
            MountainDew = 3,
            DietCoke  = 2,
            Sprite = 3
        }

        private enum Toppings
        {
            Ham = 7,
            Pineapple = 8,
            Pepperoni = 8,
            Mushroom = 8,
            GreenPepper = 8,
            BlackOlive = 5,
            Onion = 5,
            MozzarellaCheese = 7,
            CheddarCheese = 7
        }

        private enum Sauce
        {
            Tomato = 30,
            Pesto = 40
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            bool error = false;



            if (lbSizePizza.SelectedItem == null)
            {
                MessageBox.Show("Size of pizza must be selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lbPizzaCrust.SelectedItem == null)
            {
                MessageBox.Show("Crust of pizza must be selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                           
            }
            if  (lbSpecialtyPizza.SelectedItem != null)
            {
                if (txtQuantity.Text != null)
                {
                    int selectedCostFactor = 0;
                    int sizePizza = 0;
                    switch (lbSpecialtyPizza.SelectedItem.ToString())
                    {
                        case "Neapolitan":
                            selectedCostFactor = (int)CostFactor.Neapolitan;
                            break;
                        case "Margherita":
                            selectedCostFactor = (int)CostFactor.Margherita;
                            break;
                        case "Lazio":
                            selectedCostFactor = (int)CostFactor.Lazio;
                            break;
                        case "Pepperoni":
                            selectedCostFactor = (int)CostFactor.Pepperoni;
                            break;
                        case "Zucchini":
                            selectedCostFactor = (int)CostFactor.Zucchini;
                            break;
                        case "Hawaiian":
                            selectedCostFactor = (int)CostFactor.Hawaiian;
                            break;
                        case "Chicken Caesar":
                            selectedCostFactor = (int)CostFactor.ChickenCaesar;
                            break;
                        case "Cheese":
                            selectedCostFactor = (int)CostFactor.Cheese;
                            break;
                        case "Veggie":
                            selectedCostFactor = (int)CostFactor.Veggie;
                            break;
                        case "Smokey Maple Bacon":
                            selectedCostFactor = (int)CostFactor.SmokeyMapleBacon;
                            break;
                        case "Canadian Meat Lover":
                            selectedCostFactor = (int)CostFactor.CanadianMeatLover;
                            break;
                        case "BBQ Chicken":
                            selectedCostFactor = (int)CostFactor.BBQChicken;
                            break;
                    }
                    switch (lbSizePizza.SelectedItem.ToString())
                    {
                        case "Small":
                            sizePizza = (int)SizePizza.Small;
                            break;
                        case "Medium":
                            sizePizza = (int)SizePizza.Medium;
                            break;
                        case "Large":
                            sizePizza = (int)SizePizza.Large;
                            break;

                    }

                    int drinks = 0;
                    switch (lbBeverages.SelectedItem.ToString())
                    {
                        case "Coke":
                            drinks = (int)Beverages.Coke;
                            break;
                        case "Pepsi":
                            drinks = (int)Beverages.Pepsi;
                            break;
                        case "Mountain Dew":
                            drinks = (int)Beverages.MountainDew;
                            break;
                        case "Diet Coke":
                            drinks = (int)Beverages.DietCoke;
                            break;
                        case "Sprite":
                            drinks = (int)Beverages.Sprite;
                            break;
                    }
                    int tp = 0, temp = 0;
                    temp = (Convert.ToInt32(txtQuantity.Text));
                    tp = (Convert.ToInt32(txtQuantity.Text) * selectedCostFactor + sizePizza + drinks);               
                    txtQuantity.Focus();
                    txtQuantity.Clear();
                    MessageBox.Show("Thank you for ordering " + txtName.Text +
                                    "\nQuantity: \t\t" + temp +
                                    "\nPrice: \t\t$" + selectedCostFactor + ".00 " +
                                    "\nSize of the pizza: \t$" + sizePizza + ".00" +
                                    "\nDrinks Price: \t$" + drinks + ".00" +
                                    "\n\nTotal Price: \t$" + tp + ".00"
                                  + " \n\nHave a nice meal!!" + "");
                } else
                {
                    error = true;
                    MessageBox.Show("Please enter a valid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if
                (lbPizzaCrust != null)
            {
                if (lbToppings.SelectedItem == null && lbSauce.SelectedItem == null)
                {
                    MessageBox.Show("Choose toppings and sauce for customize pizza!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int sizePizza = 0;
                    int toppings = 0;
                    int sauce = 0;

                    if (txtQuantity.Text != null)
                    {
                        switch (lbSizePizza.SelectedItem.ToString())
                        {
                            case "Small":
                                sizePizza = (int)SizePizza.Small;
                                break;
                            case "Medium":
                                sizePizza = (int)SizePizza.Medium;
                                break;
                            case "Large":
                                sizePizza = (int)SizePizza.Large;
                                break;
                        }

                        switch (lbSauce.SelectedItem.ToString())
                        {
                            case "Tomato":
                                sauce = (int)Sauce.Tomato;
                                break;
                            case "Pesto":
                                sauce = (int)Sauce.Pesto;
                                break;
                        }
                        switch (lbToppings.SelectedItem.ToString())
                        {
                            case "Ham":
                                toppings = (int)Toppings.Ham;
                                break;
                            case "Pineapple":
                                toppings = (int)Toppings.Pineapple;
                                break;
                            case "Pepperoni":
                                toppings = (int)Toppings.Pepperoni;
                                break;
                            case "Mushroom":
                                toppings = (int)Toppings.Mushroom;
                                break;
                            case "Green Pepper":
                                toppings = (int)Toppings.GreenPepper;
                                break;
                            case "Black Olive":
                                toppings = (int)Toppings.BlackOlive;
                                break;
                            case "Onion":
                                toppings = (int)Toppings.Onion;
                                break;
                            case "Mozarella Cheese":
                                toppings = (int)Toppings.MozzarellaCheese;
                                break;
                            case "Cheddar Cheese":
                                toppings = (int)Toppings.CheddarCheese;
                                break;

                        }
                        
                        int drinks = 0;
                        switch (lbBeverages.SelectedItem.ToString())
                        {
                            case "Coke":
                                drinks = (int)Beverages.Coke;
                                break;
                            case "Pepsi":
                                drinks = (int)Beverages.Pepsi;
                                break;
                            case "Mountain Dew":
                                drinks = (int)Beverages.MountainDew;
                                break;
                            case "Diet Coke":
                                drinks = (int)Beverages.DietCoke;
                                break;
                            case "Sprite":
                                drinks = (int)Beverages.Sprite;
                                break;
                        }

                        int tp = 0, temp = 0;
                        temp = (Convert.ToInt32(txtQuantity.Text));
                        tp = (Convert.ToInt32(txtQuantity.Text) * toppings + sizePizza + sauce + drinks);
                        txtQuantity.Focus();
                        txtQuantity.Clear();
                        MessageBox.Show("Thank you for ordering " + txtName.Text +
                                        "\nQuantity: \t\t" + temp +
                                        "\nSize of the pizza: \t$" + sizePizza + ".00" +
                                        "\nToppings: \t$" + toppings + ".00" +
                                        "\nSauce: \t\t$" + sauce + ".00" +
                                        "\nDrinks Price: \t$" + drinks  + ".00" +
                                        "\n\nTotal Price: \t$" + tp + ".00"
                                    + " \n\nHave a nice meal!!" + "");
                    } else
                    {
                        MessageBox.Show("Please enter a valid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                   
                }
            }
        }
    }
}
