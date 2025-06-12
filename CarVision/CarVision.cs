using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarVision
{
public partial class CarVision : Form
{
    //BATTERY VALUES
    private int battery;

    private double activeDistance;
    private double activeCapacity;
    private double avgConsume;
    //limits for car
    private int maxDistanceL = 600;
    private int maxBatteryKWHL = 100;
    private int maxDistanceR = 500;
    private int maxBatteryKWHR = 90;
    //#
    //ROUTE VALUES
    private string firstCity = "";
    private string secondCity = "";
    private int distance = -1;

    private int time = 0;
    private double avgSpeed;

    int[,] ranges = new int[,]
    {
        { 0, 70, 205, 30 }, // Praha
        { 70, 0, 160, 105 }, // Kolín
        { 205, 160, 0, 240 }, // Brno
        { 30, 105, 240, 0 }  // Kladno
    };

    int[,] timeline = new int[,]
    {
        { 0, 55, 120, 40 },  // Praha
        { 55, 0, 115, 85 },  // Kolín
        { 120, 115, 0, 140 }, // Brno
        { 40, 85, 140, 0 }   // Kladno
    };

    string[] mesta = { "Praha", "Kolín", "Brno", "Kladno" };
    //#
    public CarVision()
    {
        InitializeComponent();
        SwitchPanel(_Taycan);  //ODEBRAT S GRAFIKOU
    }

    private void carL_Click(object sender, EventArgs e)
    {
        SwitchPanel(_Taycan);
        blankAll();
    }

    private void carR_Click(object sender, EventArgs e)
    {
        SwitchPanel(_Nevera);
        blankAll();
    }
    private void SwitchPanel(Panel panelToShow)
    {
        _Taycan.Visible = false;
        _Nevera.Visible = false;

        panelToShow.Visible = true;
        panelToShow.BringToFront();
    }
    private void closeBtn_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    //ONLY NUMBERS in both batteryBX
    private void batteryBx_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void destinationBtn_Click(object sender, EventArgs e)
    {
        if (_Taycan.Visible)
        {
                if (battery > 0)
                {
                    _Destinace.Visible = true;
                    _Destinace.BringToFront();
                }
                else
                {
                    MessageBox.Show("Write down the battery first (Taycan)");
                }
            }
        //---------//---------//---------//---------//---------//---------//---------//---------//---------//---------
        if (_Nevera.Visible)
        {
            if (battery > 0)
            {
                    _Destinace.Visible = true;
                    _Destinace.BringToFront();
            }
            else
             {
                    MessageBox.Show("Write down the battery first (Nevera)");
             }
        }
        //##########//##########//##########//##########//##########//##########//##########//##########//##########//
    }

    private void btnCity_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

        if (string.IsNullOrEmpty(firstCity))
        {
            firstCity = clickedButton.Text;
            Destinace_Start_Lbl.Text = $"Start: {firstCity}";
        }
        else
        {
            secondCity = clickedButton.Text;
            Destinace_End_Lbl.Text = $"End: {secondCity}";

            int startIndex = Array.IndexOf(mesta, firstCity);
            int endIndex = Array.IndexOf(mesta, secondCity);
            distance = ranges[startIndex, endIndex];
            time = timeline[startIndex, endIndex];

            if (distance != 0 && distance != -1 && time != 0)
            {
                avgSpeed = distance / (double)(time / 60);
            }
            else
            {
                MessageBox.Show("Fukmi");
            }
            firstCity = "";
            secondCity = "";
        }
    }
    private void destinationSaveBtn_Click(object sender, EventArgs e)
    {
        _Destinace.Visible = false;
        /////////
        if (_Taycan.Visible)
        {
            /*Checking if filled*/
            if (distance > 0)
            {
                //Calculation of the Total Average Consumption
                avgConsume = distance * maxBatteryKWHL / maxDistanceL;
                //TEXT
                Taycan_consume_Lbl.Text = avgConsume.ToString() + " kWh / 100 km";

                if (distance > activeDistance)
                {
                    MessageBox.Show("Battery is insufficient for the trip. Please plan a charging stop along your route.");
                    //blankAll();
                }
            }
            else if (distance == 0)
            {
                MessageBox.Show("Start/End share the same city, choose different city and start your journey!");
            }
            else
            {
                MessageBox.Show("Please note to enter destination.");
            }
        }
        //---------//---------//---------//---------//---------//---------//---------//---------//---------//---------
        if (_Nevera.Visible)
        {
            if (distance > 0)
            {
                avgConsume = distance * maxBatteryKWHL / maxDistanceL;
                Nevera_consume_Lbl.Text = avgConsume.ToString() + " kWh / 100 km";

                if (distance > activeDistance)
                {
                    MessageBox.Show("Battery is insufficient for the trip. Please plan a charging stop along your route.");
                }
            }
            else if (distance == 0)
            {
                MessageBox.Show("Start/End share the same city, choose different city and start your journey!");
            }
            else
            {
                MessageBox.Show("Please note to enter destination.");
            }
        }
        //##########//##########//##########//##########//##########//##########//##########//##########//##########//
    }

    private void blankAll()
    {
        Taycan_consume_Lbl.Text = "n/a";
        Taycan_Battery_Bx.Text = "";
        Taycan_charge_Lbl.Text = "";
        Taycan_capacity_Lbl.Text = "";
        Taycan_reach_Lbl.Text = "n/a";

        Nevera_consume_Lbl.Text = "n/a";
        Nevera_Battery_Bx.Text = "";
        Nevera_charge_Lbl.Text = "";
        Nevera_capacity_Lbl.Text = "";
        Nevera_reach_Lbl.Text = "n/a";

        distance = -1;
        battery = 0;
    }
    private void batteryL_Bx_TextChanged(object sender, EventArgs e)
    {
        /*FOR THE LEFT CAR*/

        // Limit to 3 characters
        if (Taycan_Battery_Bx.Text.Length > 3)
        {
            Taycan_Battery_Bx.Text = Taycan_Battery_Bx.Text.Substring(0, 3);
        }

        if (int.TryParse(Taycan_Battery_Bx.Text, out int valueR))
        {
            battery = valueR; // Battery is now the valid int value
            int rest = 100 - battery; // Remaining battery for charging

            // Check if the battery exceeds 100, reset to 100
            if (battery > 100)
            {
                battery = 100;
                Taycan_Battery_Bx.Text = "100";
            }

            // Calculate the Total range
            activeDistance = (battery / 100.0) * maxDistanceL; // float integer issue integer / integer = 0
            // TEXT
            Taycan_reach_Lbl.Text = activeDistance.ToString() + " km";

            // Calculate the Total Battery Capacity
            activeCapacity = ((battery / 100.0) * maxBatteryKWHL);
            //TEXT
            Taycan_capacity_Lbl.Text = activeCapacity.ToString() + " kWh";

            // Calculate the Total Recharge Time
            if (battery < 100) // Battery is not full, need to charge
            {
                if (battery <= 50)
                {
                    //TEXT
                    Taycan_charge_Lbl.Text = Math.Round((((50 - battery) * 19.2) + (30 * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else if (battery <= 80)
                {
                    //TEXT
                    Taycan_charge_Lbl.Text = ((((80 - battery) * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else
                {
                    if (rest <= 3) // Battery is almost full, value with a little imprecision
                    {
                        //TEXT
                        Taycan_charge_Lbl.Text = "<1 min";
                    }
                    else
                    {
                        //TEXT
                        Taycan_charge_Lbl.Text = (((rest * 36)) / 60).ToString() + " min";
                    }
                }
            }
            else
            {
                //TEXT
                Taycan_charge_Lbl.Text = "Full"; // Battery is full, no need to charge
            }
        }
        else
        {
            //TEXT
            Taycan_Battery_Bx.Text = ""; // Invalid input, reset the field
            blankAll();
        }
    }
    
    //---------//---------//---------//---------//---------//---------//---------//---------//---------//---------
    private void batteryR_Bx_TextChanged(object sender, EventArgs e)
    {
            /*FOR THE LEFT CAR*/

            // Limit to 3 characters
            if (Nevera_Battery_Bx.Text.Length > 3)
            {
                Nevera_Battery_Bx.Text = Nevera_Battery_Bx.Text.Substring(0, 3);
            }

            if (int.TryParse(Nevera_Battery_Bx.Text, out int valueR))
            {
                battery = valueR; // Battery is now the valid int value
                int rest = 100 - battery; // Remaining battery for charging

                // Check if the battery exceeds 100, reset to 100
                if (battery > 100)
                {
                    battery = 100;
                    Nevera_Battery_Bx.Text = "100";
                }

                // Calculate the Total range
                activeDistance = (battery / 100.0) * maxDistanceL; // float integer issue integer / integer = 0
                                                                   // TEXT
                Nevera_reach_Lbl.Text = activeDistance.ToString() + " km";

                // Calculate the Total Battery Capacity
                activeCapacity = ((battery / 100.0) * maxBatteryKWHL);
                //TEXT
                Nevera_capacity_Lbl.Text = activeCapacity.ToString() + " kWh";

                // Calculate the Total Recharge Time
                if (battery < 100) // Battery is not full, need to charge
                {
                    if (battery <= 50)
                    {
                        //TEXT
                        Nevera_charge_Lbl.Text = Math.Round((((50 - battery) * 19.2) + (30 * 30) + (20 * 36)) / 60).ToString() + " min";
                    }
                    else if (battery <= 80)
                    {
                        //TEXT
                        Nevera_charge_Lbl.Text = ((((80 - battery) * 30) + (20 * 36)) / 60).ToString() + " min";
                    }
                    else
                    {
                        if (rest <= 3) // Battery is almost full, value with a little imprecision
                        {
                            //TEXT
                            Nevera_charge_Lbl.Text = "<1 min";
                        }
                        else
                        {
                            //TEXT
                            Nevera_charge_Lbl.Text = (((rest * 36)) / 60).ToString() + " min";
                        }
                    }
                }
                else
                {
                    //TEXT
                    Nevera_charge_Lbl.Text = "Full"; // Battery is full, no need to charge
                }
            }
            else
            {
                //TEXT
                Nevera_Battery_Bx.Text = ""; // Invalid input, reset the field
                blankAll();
            }
        }

    private void batteryR_Bx_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Nevera_Battery_Bx.Text) && distance >= 0)
        {
            if (distance > activeDistance)
            {
                MessageBox.Show("The battery is too low.");
                blankAll();
            }
        }
    }
        private void Nevera_Battery_Btn_Click(object sender, EventArgs e)
        {
            battery = int.Parse(Nevera_Battery_Bx.Text);
            label6.Text = "Stav baterie: ";

            Nevera_Battery.Text = battery.ToString();
            Nevera_Battery.Visible = true;

            Nevera_Battery_Bx.Visible = false;
            Nevera_Battery_Btn.Visible = false;
        }

        private void Taycan_Battery_Btn_Click(object sender, EventArgs e)
        {
            battery = int.Parse(Taycan_Battery_Bx.Text);
            label6.Text = "Stav baterie: ";

            Taycan_Battery.Text = battery.ToString();
            Taycan_Battery.Visible = true;

            Taycan_Battery_Bx.Visible = false;
            Taycan_Battery_Btn.Visible = false;
        }
        //##########//##########//##########//##########//##########//##########//##########//##########//##########//

        //TROUBLES
        // Only if 100 % battery - dojezd, kapacita
        // avgConsume in 600 kWh

        // DONE
        // charging time considers 3 input values above 100 (etc. 555, 999) - goes to negative charging time values
    } }
