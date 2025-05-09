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
    private int avgSpeed;

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
        SwitchPanel(_carLPanel); //ODEBRAT S GRAFIKOU
    }

    private void carL_Click(object sender, EventArgs e)
    {
        SwitchPanel(_carLPanel);
        blankAll();
    }

    private void carR_Click(object sender, EventArgs e)
    {
        SwitchPanel(_carRPanel);
        blankAll();
    }
    private void SwitchPanel(Panel panelToShow)
    {
        _carLPanel.Visible = false;
        _carRPanel.Visible = false;
        _comparePanel.Visible = false;

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
        if (_carLPanel.Visible)
        {
            if (string.IsNullOrWhiteSpace(batteryL_Bx.Text))
            {
                MessageBox.Show("Write down the battery first (L)");
            }
            else
            {
                _selectPanel.Visible = true;
                _selectPanel.BringToFront();
            }
        }
        //---------//---------//---------//---------//---------//---------//---------//---------//---------//---------
        if (_carRPanel.Visible)
        {
            if (string.IsNullOrWhiteSpace(batteryR_Bx.Text))
            {
                MessageBox.Show("Write down the battery first (R)");
            }
            else
            {
                _selectPanel.Visible = true;
                _selectPanel.BringToFront();
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
            startLbl.Text = $"Start: {firstCity}";
        }
        else
        {
            secondCity = clickedButton.Text;
            endLbl.Text = $"End: {secondCity}";

            int startIndex = Array.IndexOf(mesta, firstCity);
            int endIndex = Array.IndexOf(mesta, secondCity);
            distance = ranges[startIndex, endIndex];
            time = timeline[startIndex, endIndex];

            if (distance != 0 && distance != -1 && time != 0)
            {
                avgSpeed = distance / (time / 60);
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
        _selectPanel.Visible = false;
        /////////
        if (_carLPanel.Visible)
        {
            /*Checking if filled*/
            if (distance > 0)
            {
                //Calculation of the Total Average Consumption
                avgConsume = distance * maxBatteryKWHL / maxDistanceL;
                //TEXT
                consumeL_Lbl.Text = avgConsume.ToString() + " kWh / 100 km";

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
        if (_carRPanel.Visible)
        {
            if (distance > 0)
            {
                avgConsume = distance * maxBatteryKWHL / maxDistanceL;
                consumeL_Lbl.Text = avgConsume.ToString() + " kWh / 100 km";

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
        consumeL_Lbl.Text = "";
        batteryL_Bx.Text = "";
        chargeL_Lbl.Text = "";
        capacityL_Lbl.Text = "";
        reachL_Lbl.Text = "";

        consumeR_Lbl.Text = "";
        batteryR_Bx.Text = "";
        chargeR_Lbl.Text = "";
        capacityR_Lbl.Text = "";
        reachR_Lbl.Text = "";

        distance = -1;
        battery = 0;
    }
    private void batteryL_Bx_TextChanged(object sender, EventArgs e)
    {
        /*FOR THE LEFT CAR*/

        // Limit to 3 characters
        if (batteryL_Bx.Text.Length > 3)
        {
            batteryL_Bx.Text = batteryL_Bx.Text.Substring(0, 3);
        }

        if (int.TryParse(batteryL_Bx.Text, out int valueR))
        {
            battery = valueR; // Battery is now the valid int value
            int rest = 100 - battery; // Remaining battery for charging

            // Check if the battery exceeds 100, reset to 100
            if (battery > 100)
            {
                battery = 100;
                batteryL_Bx.Text = "100";
            }

            // Calculate the Total range
            activeDistance = (battery / 100.0) * maxDistanceL; // float integer issue integer / integer = 0
            // TEXT
            reachL_Lbl.Text = activeDistance.ToString() + " km";

            // Calculate the Total Battery Capacity
            activeCapacity = ((battery / 100.0) * maxBatteryKWHL);
            //TEXT
            capacityL_Lbl.Text = activeCapacity.ToString() + " kWh";

            // Calculate the Total Recharge Time
            if (battery < 100) // Battery is not full, need to charge
            {
                if (battery <= 50)
                {
                    //TEXT
                    chargeL_Lbl.Text = Math.Round((((50 - battery) * 19.2) + (30 * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else if (battery <= 80)
                {
                    //TEXT
                    chargeL_Lbl.Text = ((((80 - battery) * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else
                {
                    if (rest <= 3) // Battery is almost full, value with a little imprecision
                    {
                        //TEXT
                        chargeL_Lbl.Text = "<1 min";
                    }
                    else
                    {
                        //TEXT
                        chargeL_Lbl.Text = (((rest * 36)) / 60).ToString() + " min";
                    }
                }
            }
            else
            {
                //TEXT
                chargeL_Lbl.Text = "Full"; // Battery is full, no need to charge
            }
        }
        else
        {
            //TEXT
            batteryL_Bx.Text = ""; // Invalid input, reset the field
            blankAll();
        }
    }
    
    //---------//---------//---------//---------//---------//---------//---------//---------//---------//---------
    private void batteryR_Bx_TextChanged(object sender, EventArgs e)
    {
        /*FOR THE RIGHT CAR*/

        if (batteryR_Bx.Text.Length > 3)
        {
            batteryR_Bx.Text = batteryR_Bx.Text.Substring(0, 3);
        }

        if (int.TryParse(batteryR_Bx.Text, out int valueR))
        {
            battery = valueR; // Battery is now the valid int value
            int rest = 100 - battery; // Remaining battery for charging

            // Check if the battery exceeds 100, reset to 100
            if (battery > 100)
            {
                battery = 100;
                batteryR_Bx.Text = "100";
            }

            // Calculate the Total range
            activeDistance = (battery / 100.0) * maxDistanceR; // float integer issue integer / integer = 0
                                                                // TEXT
            reachR_Lbl.Text = activeDistance.ToString() + " km";

            // Calculate the Total Battery Capacity
            activeCapacity = ((battery / 100.0) * maxBatteryKWHR);
            //TEXT
            capacityR_Lbl.Text = activeCapacity.ToString() + " kWh";

            // Calculate the Total Recharge Time
            if (battery < 100) // Battery is not full, need to charge
            {
                if (battery <= 50)
                {
                    //TEXT
                    chargeL_Lbl.Text = Math.Round((((50 - battery) * 19.2) + (30 * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else if (battery <= 80)
                {
                    //TEXT
                    chargeL_Lbl.Text = ((((80 - battery) * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else
                {
                    if (rest <= 3) // Battery is almost full, value with a little imprecision
                    {
                        //TEXT
                        chargeL_Lbl.Text = "<1 min";
                    }
                    else
                    {
                        //TEXT
                        chargeL_Lbl.Text = (((rest * 36)) / 60).ToString() + " min";
                    }
                }
            }
            else
            {
                //TEXT
                chargeL_Lbl.Text = "Full"; // Battery is full, no need to charge
            }
        }
        else
        {
            //TEXT
            batteryL_Bx.Text = ""; // Invalid input, reset the field
            blankAll();
        }
    }

    private void batteryR_Bx_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(batteryR_Bx.Text) && distance >= 0)
        {
            if (distance > activeDistance)
            {
                MessageBox.Show("The battery is too low.");
                blankAll();
            }
        }
    }
        //##########//##########//##########//##########//##########//##########//##########//##########//##########//

        //TROUBLES
        // Only if 100 % battery - dojezd, kapacita
        // avgConsume in 600 kWh

        // DONE
        // charging time considers 3 input values above 100 (etc. 555, 999) - goes to negative charging time values
} }
