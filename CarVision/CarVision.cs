using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarVision
{
    // full screen responsive 
    // animace
    // buttons
    // timer charge, 
public partial class CarVision : Form
{
    //BATTERY VALUES
    private int battery; 
    Timer batteryTimer = new Timer();

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

    private readonly Size programReferenceSize = new Size(818, 460);

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
    private void BatteryTimer_Tick(object sender, EventArgs e)
    {
        // Zvětšit baterii
        if (battery < 100)
        {
            battery = battery + 1;
                if (Nevera_Charge_battery.Visible)
                {
                    activeCapacity = ((battery / 100.0) * maxBatteryKWHR);
                    Nevera_capacity_Lbl.Text = activeCapacity.ToString() + " kWh";
                    Nevera_Charge_battery.Text = battery + " %";
                }
                else
                {
                    activeCapacity = ((battery / 100.0) * maxBatteryKWHL);
                    Taycan_capacity_Lbl.Text = activeCapacity.ToString() + " kWh";
                    Taycan_Charge_battery.Text = battery + " %";
                }
            UpdateBatteryInterval();

            //MessageBox.Show("Interval: " + (batteryTimer.Interval).ToString());
            //MessageBox.Show("Battery: " + battery.ToString());
            }
        else
        {
            batteryTimer.Stop();
                if (Nevera_Charge_battery.Visible)
                {
                    label3.Text = "Baterie plně nabita.";
                    Nevera_charge_Lbl.Text = "Full";
                }
                else
                {
                    label1.Text = "Baterie plně nabita.";
                    Taycan_charge_Lbl.Text = "Full";
                }
         }
    }
    private void UpdateBatteryInterval()
    {
            if (Nevera_Charge_battery.Visible)
            {
                if (battery <= 50)
                {
                    batteryTimer.Interval = (int)(120);
                    Nevera_charge_Lbl.Text = ((((50 - battery) * 12) + (30 * 24) + (20 * 36)) / 60).ToString() + " min";
                }
                else if (battery <= 80)
                {
                    batteryTimer.Interval = 240;
                    Nevera_charge_Lbl.Text = ((((80 - battery) * 24) + (20 * 36)) / 60).ToString() + " min";
                }
                else
                {
                    batteryTimer.Interval = 360;
                    int rest = 100 - battery;
                    if (rest <= 3)
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
                if (battery <= 50)
                {
                    batteryTimer.Interval = (int)(192); // 19.2s / 10 = 1.92s → 1920ms, ale zrychleně → 192ms
                    Taycan_charge_Lbl.Text = Math.Round((((50 - battery) * 19.2) + (30 * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else if (battery <= 80)
                {
                    batteryTimer.Interval = 300; // 3s (30s / 10)
                    Taycan_charge_Lbl.Text = ((((80 - battery) * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else
                {
                    batteryTimer.Interval = 360; // 3.6s (36s / 10)
                    int rest = 100 - battery;
                    if (rest <= 3)
                    {
                        Taycan_charge_Lbl.Text = "<1 min";
                    }
                    else
                    {
                        Taycan_charge_Lbl.Text = (((rest * 36)) / 60).ToString() + " min";
                    }
                }
            }
    }
    private void carL_Click(object sender, EventArgs e)
    {
        label12.Text = "Zadejte startovní baterii";

        Taycan_Battery.Visible = false;
        Taycan_Battery_Bx.Visible = true;
        Taycan_Battery_Btn.Visible = true;

        SwitchPanel(_Taycan);
        blankAll();
    }
    private void carL_Charge_Click(object sender, EventArgs e)
    {
        if (Taycan_Battery.Visible)
        {
            SwitchPanel(_Taycan_Charge);

            Taycan_Charge_battery.Text = battery + " %";
            //Timer section
            batteryTimer.Tick -= BatteryTimer_Tick;
            batteryTimer.Tick += BatteryTimer_Tick;
            UpdateBatteryInterval();
            batteryTimer.Start();
        }
        else
        {
            MessageBox.Show("Write down the battery first (Taycan)");
        }
    }
    private void carR_Click(object sender, EventArgs e)
    {
        label6.Text = "Zadejte startovní baterii";

        Nevera_Battery.Visible = false;
        Nevera_Battery_Bx.Visible = true;
        Nevera_Battery_Btn.Visible = true;

        SwitchPanel(_Nevera);
        blankAll();
    }
    private void carR_Charge_Click(object sender, EventArgs e)
    {
            if (Nevera_Battery.Visible)
            {
                SwitchPanel(_Nevera_Charge);

                Nevera_Charge_battery.Text = battery + " %";
                //Timer section
                batteryTimer.Tick -= BatteryTimer_Tick;
                batteryTimer.Tick += BatteryTimer_Tick;
                UpdateBatteryInterval();
                batteryTimer.Start();
            }
            else
            {
                MessageBox.Show("Write down the battery first (Nevera)");
            }
    }
        private void SwitchPanel(Panel panelToShow)
    {
        _Nevera.Visible = false;
        _Nevera_Charge.Visible = false;
        _Taycan.Visible = false;
        _Taycan_Charge.Visible = false;

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
            if (Taycan_Battery.Visible)
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
            if (Nevera_Battery.Visible)
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
            PictureBox clickedPicture = (PictureBox)sender;
            string cityName = clickedPicture.Tag?.ToString();

            if (string.IsNullOrEmpty(cityName))
            {
                MessageBox.Show("Obrázek nemá přiřazený název města");
                return;
            }

            if (string.IsNullOrEmpty(firstCity))
            {
                firstCity = cityName;
                Destinace_Start_Lbl.Text = $"Start: {firstCity}";
            }
            else
            {
                secondCity = cityName;
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
            battery = battery - (distance*100) / maxDistanceL;
            Taycan_Battery.Text = battery.ToString() + " %";
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
            battery = battery - (distance * 100) / maxDistanceR;
            Nevera_Battery.Text = battery.ToString() + " %";
                if (distance > 0)
            {
                avgConsume = distance * maxBatteryKWHR / maxDistanceR;
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

        Destinace_Start_Lbl.Text = "";
        Destinace_End_Lbl.Text = "";

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
                activeDistance = (battery / 100.0) * maxDistanceR; // float integer issue integer / integer = 0
                                                                   // TEXT
                Nevera_reach_Lbl.Text = activeDistance.ToString() + " km";

                // Calculate the Total Battery Capacity
                activeCapacity = ((battery / 100.0) * maxBatteryKWHR);
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
            if (Nevera_Battery_Bx.Text == "")
            {
                MessageBox.Show("Enter the battery value.");
            }
            else
            {
                battery = int.Parse(Nevera_Battery_Bx.Text);
                label6.Text = "Stav baterie: ";

                Nevera_Battery.Text = battery.ToString() + " %";
                Nevera_Battery.Visible = true;

                Nevera_Battery_Bx.Visible = false;
                Nevera_Battery_Btn.Visible = false;
            }
        }

        private void Taycan_Battery_Btn_Click(object sender, EventArgs e)
        {
            if(Taycan_Battery_Bx.Text == "")
            {
                MessageBox.Show("Enter the battery value.");
            }
            else
            {
                battery = int.Parse(Taycan_Battery_Bx.Text);
                label12.Text = "Stav baterie: ";

                Taycan_Battery.Text = battery.ToString() + " %";
                Taycan_Battery.Visible = true;

                Taycan_Battery_Bx.Visible = false;
                Taycan_Battery_Btn.Visible = false;
            }
        }

        private void AdjustSquares()
        {
            float scaleX = (float)_Taycan.Width / programReferenceSize.Width;
            float scaleY = (float)_Taycan.Height / programReferenceSize.Height;

            Taycan_to_Charge.Size = new Size((int)(173 * scaleX), (int)(46 * scaleY));
            Taycan_to_Charge.Location = new Point((int)(42 * scaleX), (int)(394 * scaleY));

            Taycan_Destination_Btn.Size = new Size((int)(173 * scaleX), (int)(46 * scaleY));
            Taycan_Destination_Btn.Location = new Point((int)(603 * scaleX), (int)(394 * scaleY));

            toNeveraBtn2.Size = new Size((int)(45 * scaleX), (int)(44 * scaleY));
            toNeveraBtn2.Location = new Point((int)(748 * scaleX), (int)(217 * scaleY));

            toNeveraBtn.Size = new Size((int)(45 * scaleX), (int)(44 * scaleY));
            toNeveraBtn.Location = new Point((int)(25 * scaleX), (int)(217 * scaleY));

            Destinace_Brno_Btn.Size = new Size((int)(217 * scaleX), (int)(107 * scaleY));
            Destinace_Brno_Btn.Location = new Point((int)(443 * scaleX), (int)(113 * scaleY));

            Destinace_End_Lbl.Size = new Size((int)(36 * scaleX), (int)(24 * scaleY));
            Destinace_End_Lbl.Location = new Point((int)(460 * scaleX), (int)(95 * scaleY));

            Destinace_Kladno_Btn.Size = new Size((int)(217 * scaleX), (int)(107 * scaleY));
            Destinace_Kladno_Btn.Location = new Point((int)(154 * scaleX), (int)(239 * scaleY));

            Destinace_Kolin_Btn.Size = new Size((int)(217 * scaleX), (int)(107 * scaleY));
            Destinace_Kolin_Btn.Location = new Point((int)(443 * scaleX), (int)(239 * scaleY));

            Destinace_Praha_Btn.Size = new Size((int)(217 * scaleX), (int)(107 * scaleY));
            Destinace_Praha_Btn.Location = new Point((int)(154 * scaleX), (int)(113 * scaleY));

            Destinace_Save_Btn.Size = new Size((int)(177 * scaleX), (int)(53 * scaleY));
            Destinace_Save_Btn.Location = new Point((int)(319 * scaleX), (int)(388 * scaleY));

            Destinace_Start_Lbl.Size = new Size((int)(51 * scaleX), (int)(24 * scaleY));
            Destinace_Start_Lbl.Location = new Point((int)(258 * scaleX), (int)(95 * scaleY));

            // AND MORE ...
        }

        private void _Taycan_Resize(object sender, EventArgs e)
        {
            AdjustSquares();
        }

        private void Taycan_Charge_Back_Btn_Click(object sender, EventArgs e)
        {
            activeDistance = (battery / 100.0) * maxDistanceL;

            Taycan_Battery.Text = battery.ToString() + " %";
            Taycan_reach_Lbl.Text = activeDistance.ToString() + " km";

            batteryTimer.Stop();
            SwitchPanel(_Taycan);
        }

        private void Nevera_Charge_Back_Btn_Click(object sender, EventArgs e)
        {
            activeDistance = (battery / 100.0) * maxDistanceR;

            Nevera_Battery.Text = battery.ToString() + " %";
            Nevera_reach_Lbl.Text = activeDistance.ToString() + " km";

            batteryTimer.Stop();
            SwitchPanel(_Nevera);
        }

        private void Destination_Back_Btn_Click(object sender, EventArgs e)
        {
            _Destinace.Visible = false;
        }
        //##########//##########//##########//##########//##########//##########//##########//##########//##########//

        //TROUBLES
        // Only if 100 % battery - dojezd, kapacita
        // avgConsume in 600 kWh

        // DONE
        // charging time considers 3 input values above 100 (etc. 555, 999) - goes to negative charging time values
    } }