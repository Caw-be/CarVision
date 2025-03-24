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
        private string firstCity = "";
        private string secondCity = "";
        //private int time = 0;

        private int activeDistance;
        private int distance = -1;
        private int battery;
        private float avgConsume;


        //LIMITS
        private int maxDistanceL = 600;
        private int maxBatteryKWHL = 100;

        private int maxDistanceR = 500;
        private int maxBatteryKWHR = 90;

        int[,] ranges = new int[,]
        {
            { 0, 70, 205, 30 }, // Praha
            { 70, 0, 160, 105 }, // Kolín
            { 205, 160, 0, 240 }, // Brno
            { 30, 105, 240, 0 }  // Kladno
        };
        /*
        int[,] timeline = new int[,]
        {
            { 0, 55, 120, 40 },  // Praha
            { 55, 0, 115, 85 },  // Kolín
            { 120, 115, 0, 140 }, // Brno
            { 40, 85, 140, 0 }   // Kladno
        };
        */

        string[] mesta = { "Praha", "Kolín", "Brno", "Kladno" };


        public CarVision()
        {
            InitializeComponent();
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

        private void batteryBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void destinationBtn_Click(object sender, EventArgs e)
        {
            _selectPanel.Visible = true;
            _selectPanel.BringToFront();
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
                //time = timeline[startIndex, endIndex];

                firstCity = "";
                secondCity = "";
            }
        }
        private void destinationSaveBtn_Click(object sender, EventArgs e)
        {
            _selectPanel.Visible = false;

            if (_carLPanel.Visible)
            {
                /*Checking if filled*/
                if (!string.IsNullOrWhiteSpace(batteryL_Bx.Text) && distance >= 0)
                {
                    activeDistance = (battery / 100) * maxDistanceL;
                    avgConsume = distance * maxBatteryKWHL / maxDistanceL;

                    consumeL_Lbl.Text = avgConsume.ToString() + " kWh";

                    if ( distance > activeDistance )
                    {
                        MessageBox.Show("The battery is too low.");
                        blankAll();
                    }
                }
                else
                {
                    MessageBox.Show("Please don't forget to enter battery percentage aswell as destination.");
                }
            }
            if (_carRPanel.Visible)
            {
                if (!string.IsNullOrWhiteSpace(batteryR_Bx.Text) && distance >= 0)
                {
                    activeDistance = (  battery / 100   ) * maxDistanceR;
                    avgConsume = distance * maxBatteryKWHR / maxDistanceR;

                    consumeR_Lbl.Text = avgConsume.ToString() + " kWh";

                    if ( distance > activeDistance )
                    {
                        MessageBox.Show("The battery is too low.");
                        blankAll();
                    }
                }
                else
                {
                    MessageBox.Show("Please don't forget to enter battery percentage aswell as destination.");
                }
            }
            
        }

        private void blankAll()
        {
            consumeR_Lbl.Text = "";
            batteryR_Bx.Text = "";
            chargeR_Lbl.Text = "";
            capacityR_Lbl.Text = "";
            reachR_Lbl.Text = "";

            distance = -1;
            battery = 0;
        }

        private void batteryR_Bx_TextChanged(object sender, EventArgs e)
        {
            /*FOR THE RIGHT CAR*/

            if (batteryR_Bx.Text.Length > 3)
            {
                batteryR_Bx.Text = batteryR_Bx.Text.Substring(0, 3);
                batteryR_Bx.SelectionStart = batteryR_Bx.Text.Length;
            }

            if (int.TryParse(batteryR_Bx.Text, out int valueR))
            {

                activeDistance = (battery / 100) * maxDistanceR;
                battery = int.Parse(batteryR_Bx.Text);
                int rest = 100 - int.Parse(batteryR_Bx.Text);

                if (valueR > 100)
                {
                    batteryR_Bx.Text = "100";
                }

                /*Checking if filled*/
                if (!string.IsNullOrWhiteSpace(batteryR_Bx.Text) && distance >= 0)
                {
                    avgConsume = distance * maxBatteryKWHR / maxDistanceR;
                    consumeR_Lbl.Text = avgConsume.ToString() + " kWh";
                }

                /*Celkový dojezd*/
                reachR_Lbl.Text = activeDistance.ToString("F2") + " km";

                /*Kapacita baterie*/
                capacityR_Lbl.Text = (  (battery / 100) * maxBatteryKWHR    ).ToString("F2") + " kWh";


                /*Čas nabití*/
                if (battery <= 50)
                {
                    chargeR_Lbl.Text = ((((50 - int.Parse(batteryR_Bx.Text)) * 19.2) + (30 * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else if (battery <= 80)
                {
                    chargeR_Lbl.Text = ((((80 - int.Parse(batteryR_Bx.Text)) * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else
                {
                    chargeR_Lbl.Text = (((rest * 36)) / 60).ToString() + " min";
                }
            }
            else
            {
                batteryR_Bx.Text = "";
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

        private void batteryL_Bx_TextChanged(object sender, EventArgs e)
        {
            /*FOR THE LEFT CAR*/

            if (batteryL_Bx.Text.Length > 3)
            {
                batteryL_Bx.Text = batteryL_Bx.Text.Substring(0, 3);
                batteryL_Bx.SelectionStart = batteryL_Bx.Text.Length;
            }

            if (int.TryParse(batteryL_Bx.Text, out int valueR))
            {
                battery = int.Parse(batteryL_Bx.Text);
                activeDistance = (battery / 100) * maxDistanceL;
                int rest = 100 - int.Parse(batteryL_Bx.Text);

                // CHANGES higher VALUES IN battery
                if (valueR > 100)
                {
                    batteryL_Bx.Text = "100";
                }

                /*Checking if filled*/
                if (distance >= 0)
                {
                    avgConsume = distance * maxBatteryKWHL / maxDistanceL;

                    consumeL_Lbl.Text = avgConsume.ToString() + " kWh";
                }

                /*Celkový dojezd*/
                reachL_Lbl.Text = activeDistance.ToString("F2") + " km";

                /*Kapacita baterie*/
                capacityL_Lbl.Text = (  ( battery / 100) * maxBatteryKWHL   ).ToString("F2") + " kWh";


                /*Čas nabití*/
                if (battery <= 50)
                {
                    chargeL_Lbl.Text = ((((50 - int.Parse(batteryL_Bx.Text)) * 19.2) + (30 * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else if (battery <= 80)
                {
                    chargeL_Lbl.Text = ((((80 - int.Parse(batteryL_Bx.Text)) * 30) + (20 * 36)) / 60).ToString() + " min";
                }
                else
                {
                    chargeL_Lbl.Text = (((rest * 36)) / 60).ToString() + " min";
                }
            }
            else {
                batteryL_Bx.Text = "";
            }
        }

        private void batteryL_Bx_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(batteryL_Bx.Text) && distance >= 0)
            {
                if (distance > activeDistance)
                {
                    MessageBox.Show("The battery is too low.");
                    blankAll();
                }
            }
        }
    }
}
