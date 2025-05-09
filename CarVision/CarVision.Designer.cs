namespace CarVision
{
    partial class CarVision
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.carL = new System.Windows.Forms.PictureBox();
            this.carR = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._comparePanel = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this._carLPanel = new System.Windows.Forms.Panel();
            this.toRBtn = new System.Windows.Forms.Button();
            this.consumeL_Lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.capacityL_Lbl = new System.Windows.Forms.Label();
            this.reachL_Lbl = new System.Windows.Forms.Label();
            this.chargeL_Lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.destinationL_Btn = new System.Windows.Forms.Button();
            this.batteryL_Bx = new System.Windows.Forms.TextBox();
            this._selectPanel = new System.Windows.Forms.Panel();
            this.destinationSaveBtn = new System.Windows.Forms.Button();
            this.startLbl = new System.Windows.Forms.Label();
            this.endLbl = new System.Windows.Forms.Label();
            this.kolinBtn = new System.Windows.Forms.Button();
            this.kladnoBtn = new System.Windows.Forms.Button();
            this.brnoBtn = new System.Windows.Forms.Button();
            this.prahaBtn = new System.Windows.Forms.Button();
            this._carRPanel = new System.Windows.Forms.Panel();
            this.toLBtn = new System.Windows.Forms.Button();
            this.consumeR_Lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.capacityR_Lbl = new System.Windows.Forms.Label();
            this.reachR_Lbl = new System.Windows.Forms.Label();
            this.chargeR_Lbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.destinationR_Btn = new System.Windows.Forms.Button();
            this.batteryR_Bx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.carL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carR)).BeginInit();
            this._comparePanel.SuspendLayout();
            this._carLPanel.SuspendLayout();
            this._selectPanel.SuspendLayout();
            this._carRPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // carL
            // 
            this.carL.BackColor = System.Drawing.Color.IndianRed;
            this.carL.Location = new System.Drawing.Point(95, 145);
            this.carL.Margin = new System.Windows.Forms.Padding(4);
            this.carL.Name = "carL";
            this.carL.Size = new System.Drawing.Size(400, 357);
            this.carL.TabIndex = 0;
            this.carL.TabStop = false;
            this.carL.Click += new System.EventHandler(this.carL_Click);
            // 
            // carR
            // 
            this.carR.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.carR.Location = new System.Drawing.Point(603, 145);
            this.carR.Margin = new System.Windows.Forms.Padding(4);
            this.carR.Name = "carR";
            this.carR.Size = new System.Drawing.Size(400, 357);
            this.carR.TabIndex = 1;
            this.carR.TabStop = false;
            this.carR.Click += new System.EventHandler(this.carR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(228, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Porsche 911";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(723, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rimac Nevera";
            // 
            // _comparePanel
            // 
            this._comparePanel.Controls.Add(this.closeBtn);
            this._comparePanel.Controls.Add(this.label1);
            this._comparePanel.Controls.Add(this.label2);
            this._comparePanel.Controls.Add(this.carL);
            this._comparePanel.Controls.Add(this.carR);
            this._comparePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._comparePanel.Location = new System.Drawing.Point(0, 0);
            this._comparePanel.Margin = new System.Windows.Forms.Padding(4);
            this._comparePanel.Name = "_comparePanel";
            this._comparePanel.Size = new System.Drawing.Size(1091, 642);
            this._comparePanel.TabIndex = 4;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(973, 27);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(87, 46);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // _carLPanel
            // 
            this._carLPanel.BackColor = System.Drawing.Color.PowderBlue;
            this._carLPanel.Controls.Add(this.toRBtn);
            this._carLPanel.Controls.Add(this.consumeL_Lbl);
            this._carLPanel.Controls.Add(this.label4);
            this._carLPanel.Controls.Add(this.capacityL_Lbl);
            this._carLPanel.Controls.Add(this.reachL_Lbl);
            this._carLPanel.Controls.Add(this.chargeL_Lbl);
            this._carLPanel.Controls.Add(this.label8);
            this._carLPanel.Controls.Add(this.label10);
            this._carLPanel.Controls.Add(this.label11);
            this._carLPanel.Controls.Add(this.label12);
            this._carLPanel.Controls.Add(this.destinationL_Btn);
            this._carLPanel.Controls.Add(this.batteryL_Bx);
            this._carLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._carLPanel.Location = new System.Drawing.Point(0, 0);
            this._carLPanel.Margin = new System.Windows.Forms.Padding(4);
            this._carLPanel.Name = "_carLPanel";
            this._carLPanel.Size = new System.Drawing.Size(1091, 642);
            this._carLPanel.TabIndex = 5;
            // 
            // toRBtn
            // 
            this.toRBtn.Location = new System.Drawing.Point(955, 294);
            this.toRBtn.Margin = new System.Windows.Forms.Padding(4);
            this.toRBtn.Name = "toRBtn";
            this.toRBtn.Size = new System.Drawing.Size(105, 65);
            this.toRBtn.TabIndex = 22;
            this.toRBtn.Text = "Switch to Rimac";
            this.toRBtn.UseVisualStyleBackColor = true;
            this.toRBtn.Click += new System.EventHandler(this.carR_Click);
            // 
            // consumeL_Lbl
            // 
            this.consumeL_Lbl.AutoSize = true;
            this.consumeL_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.consumeL_Lbl.Location = new System.Drawing.Point(604, 308);
            this.consumeL_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.consumeL_Lbl.Name = "consumeL_Lbl";
            this.consumeL_Lbl.Size = new System.Drawing.Size(0, 31);
            this.consumeL_Lbl.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(607, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Průměrná spotřeba";
            // 
            // capacityL_Lbl
            // 
            this.capacityL_Lbl.AutoSize = true;
            this.capacityL_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.capacityL_Lbl.Location = new System.Drawing.Point(251, 455);
            this.capacityL_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.capacityL_Lbl.Name = "capacityL_Lbl";
            this.capacityL_Lbl.Size = new System.Drawing.Size(0, 31);
            this.capacityL_Lbl.TabIndex = 19;
            // 
            // reachL_Lbl
            // 
            this.reachL_Lbl.AutoSize = true;
            this.reachL_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reachL_Lbl.Location = new System.Drawing.Point(251, 308);
            this.reachL_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reachL_Lbl.Name = "reachL_Lbl";
            this.reachL_Lbl.Size = new System.Drawing.Size(0, 31);
            this.reachL_Lbl.TabIndex = 18;
            // 
            // chargeL_Lbl
            // 
            this.chargeL_Lbl.AutoSize = true;
            this.chargeL_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chargeL_Lbl.Location = new System.Drawing.Point(604, 455);
            this.chargeL_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chargeL_Lbl.Name = "chargeL_Lbl";
            this.chargeL_Lbl.Size = new System.Drawing.Size(0, 31);
            this.chargeL_Lbl.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(253, 393);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Kapacita baterie";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(253, 245);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Celkový dojezd";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(607, 393);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Čas potřebný k dobití";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(253, 102);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "Stav baterie";
            // 
            // destinationL_Btn
            // 
            this.destinationL_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.destinationL_Btn.Location = new System.Drawing.Point(611, 123);
            this.destinationL_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.destinationL_Btn.Name = "destinationL_Btn";
            this.destinationL_Btn.Size = new System.Drawing.Size(231, 34);
            this.destinationL_Btn.TabIndex = 12;
            this.destinationL_Btn.Text = "Vyberte destinaci";
            this.destinationL_Btn.UseVisualStyleBackColor = true;
            this.destinationL_Btn.Click += new System.EventHandler(this.destinationBtn_Click);
            // 
            // batteryL_Bx
            // 
            this.batteryL_Bx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.batteryL_Bx.Location = new System.Drawing.Point(257, 126);
            this.batteryL_Bx.Margin = new System.Windows.Forms.Padding(4);
            this.batteryL_Bx.MaxLength = 3;
            this.batteryL_Bx.Name = "batteryL_Bx";
            this.batteryL_Bx.Size = new System.Drawing.Size(176, 30);
            this.batteryL_Bx.TabIndex = 11;
            this.batteryL_Bx.TextChanged += new System.EventHandler(this.batteryL_Bx_TextChanged);
            this.batteryL_Bx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batteryBx_KeyPress);
            // 
            // _selectPanel
            // 
            this._selectPanel.Controls.Add(this.destinationSaveBtn);
            this._selectPanel.Controls.Add(this.startLbl);
            this._selectPanel.Controls.Add(this.endLbl);
            this._selectPanel.Controls.Add(this.kolinBtn);
            this._selectPanel.Controls.Add(this.kladnoBtn);
            this._selectPanel.Controls.Add(this.brnoBtn);
            this._selectPanel.Controls.Add(this.prahaBtn);
            this._selectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._selectPanel.Location = new System.Drawing.Point(0, 0);
            this._selectPanel.Margin = new System.Windows.Forms.Padding(4);
            this._selectPanel.Name = "_selectPanel";
            this._selectPanel.Size = new System.Drawing.Size(1091, 642);
            this._selectPanel.TabIndex = 10;
            this._selectPanel.Visible = false;
            // 
            // destinationSaveBtn
            // 
            this.destinationSaveBtn.BackColor = System.Drawing.SystemColors.Desktop;
            this.destinationSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.destinationSaveBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.destinationSaveBtn.Location = new System.Drawing.Point(425, 478);
            this.destinationSaveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.destinationSaveBtn.Name = "destinationSaveBtn";
            this.destinationSaveBtn.Size = new System.Drawing.Size(236, 65);
            this.destinationSaveBtn.TabIndex = 6;
            this.destinationSaveBtn.Text = "Načíst cestu";
            this.destinationSaveBtn.UseVisualStyleBackColor = false;
            this.destinationSaveBtn.Click += new System.EventHandler(this.destinationSaveBtn_Click);
            // 
            // startLbl
            // 
            this.startLbl.AutoSize = true;
            this.startLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startLbl.Location = new System.Drawing.Point(344, 117);
            this.startLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startLbl.Name = "startLbl";
            this.startLbl.Size = new System.Drawing.Size(68, 29);
            this.startLbl.TabIndex = 5;
            this.startLbl.Text = "Start:";
            // 
            // endLbl
            // 
            this.endLbl.AutoSize = true;
            this.endLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endLbl.Location = new System.Drawing.Point(613, 117);
            this.endLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endLbl.Name = "endLbl";
            this.endLbl.Size = new System.Drawing.Size(48, 29);
            this.endLbl.TabIndex = 4;
            this.endLbl.Text = "Cíl:";
            // 
            // kolinBtn
            // 
            this.kolinBtn.Location = new System.Drawing.Point(603, 337);
            this.kolinBtn.Margin = new System.Windows.Forms.Padding(4);
            this.kolinBtn.Name = "kolinBtn";
            this.kolinBtn.Size = new System.Drawing.Size(145, 74);
            this.kolinBtn.TabIndex = 3;
            this.kolinBtn.Text = "Kolín";
            this.kolinBtn.UseVisualStyleBackColor = true;
            this.kolinBtn.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // kladnoBtn
            // 
            this.kladnoBtn.Location = new System.Drawing.Point(349, 338);
            this.kladnoBtn.Margin = new System.Windows.Forms.Padding(4);
            this.kladnoBtn.Name = "kladnoBtn";
            this.kladnoBtn.Size = new System.Drawing.Size(145, 74);
            this.kladnoBtn.TabIndex = 2;
            this.kladnoBtn.Text = "Kladno";
            this.kladnoBtn.UseVisualStyleBackColor = true;
            this.kladnoBtn.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // brnoBtn
            // 
            this.brnoBtn.Location = new System.Drawing.Point(603, 213);
            this.brnoBtn.Margin = new System.Windows.Forms.Padding(4);
            this.brnoBtn.Name = "brnoBtn";
            this.brnoBtn.Size = new System.Drawing.Size(145, 74);
            this.brnoBtn.TabIndex = 1;
            this.brnoBtn.Text = "Brno";
            this.brnoBtn.UseVisualStyleBackColor = true;
            this.brnoBtn.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // prahaBtn
            // 
            this.prahaBtn.Location = new System.Drawing.Point(349, 213);
            this.prahaBtn.Margin = new System.Windows.Forms.Padding(4);
            this.prahaBtn.Name = "prahaBtn";
            this.prahaBtn.Size = new System.Drawing.Size(145, 74);
            this.prahaBtn.TabIndex = 0;
            this.prahaBtn.Text = "Praha";
            this.prahaBtn.UseVisualStyleBackColor = true;
            this.prahaBtn.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // _carRPanel
            // 
            this._carRPanel.BackColor = System.Drawing.Color.LightSalmon;
            this._carRPanel.Controls.Add(this.toLBtn);
            this._carRPanel.Controls.Add(this.consumeR_Lbl);
            this._carRPanel.Controls.Add(this.label9);
            this._carRPanel.Controls.Add(this.capacityR_Lbl);
            this._carRPanel.Controls.Add(this.reachR_Lbl);
            this._carRPanel.Controls.Add(this.chargeR_Lbl);
            this._carRPanel.Controls.Add(this.label13);
            this._carRPanel.Controls.Add(this.label14);
            this._carRPanel.Controls.Add(this.label15);
            this._carRPanel.Controls.Add(this.label16);
            this._carRPanel.Controls.Add(this.destinationR_Btn);
            this._carRPanel.Controls.Add(this.batteryR_Bx);
            this._carRPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._carRPanel.Location = new System.Drawing.Point(0, 0);
            this._carRPanel.Margin = new System.Windows.Forms.Padding(4);
            this._carRPanel.Name = "_carRPanel";
            this._carRPanel.Size = new System.Drawing.Size(1091, 642);
            this._carRPanel.TabIndex = 11;
            // 
            // toLBtn
            // 
            this.toLBtn.Location = new System.Drawing.Point(33, 316);
            this.toLBtn.Margin = new System.Windows.Forms.Padding(4);
            this.toLBtn.Name = "toLBtn";
            this.toLBtn.Size = new System.Drawing.Size(105, 65);
            this.toLBtn.TabIndex = 23;
            this.toLBtn.Text = "Switch to Tesla";
            this.toLBtn.UseVisualStyleBackColor = true;
            this.toLBtn.Click += new System.EventHandler(this.carL_Click);
            // 
            // consumeR_Lbl
            // 
            this.consumeR_Lbl.AutoSize = true;
            this.consumeR_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.consumeR_Lbl.Location = new System.Drawing.Point(596, 330);
            this.consumeR_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.consumeR_Lbl.Name = "consumeR_Lbl";
            this.consumeR_Lbl.Size = new System.Drawing.Size(0, 31);
            this.consumeR_Lbl.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(599, 267);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Průměrná spotřeba";
            // 
            // capacityR_Lbl
            // 
            this.capacityR_Lbl.AutoSize = true;
            this.capacityR_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.capacityR_Lbl.Location = new System.Drawing.Point(243, 478);
            this.capacityR_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.capacityR_Lbl.Name = "capacityR_Lbl";
            this.capacityR_Lbl.Size = new System.Drawing.Size(0, 31);
            this.capacityR_Lbl.TabIndex = 8;
            // 
            // reachR_Lbl
            // 
            this.reachR_Lbl.AutoSize = true;
            this.reachR_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reachR_Lbl.Location = new System.Drawing.Point(243, 330);
            this.reachR_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reachR_Lbl.Name = "reachR_Lbl";
            this.reachR_Lbl.Size = new System.Drawing.Size(0, 31);
            this.reachR_Lbl.TabIndex = 7;
            // 
            // chargeR_Lbl
            // 
            this.chargeR_Lbl.AutoSize = true;
            this.chargeR_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chargeR_Lbl.Location = new System.Drawing.Point(596, 478);
            this.chargeR_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chargeR_Lbl.Name = "chargeR_Lbl";
            this.chargeR_Lbl.Size = new System.Drawing.Size(0, 31);
            this.chargeR_Lbl.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(245, 415);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "Kapacita baterie";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(245, 267);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "Celkový dojezd";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(599, 415);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(167, 20);
            this.label15.TabIndex = 3;
            this.label15.Text = "Čas potřebný k dobití";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(245, 124);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Stav baterie";
            // 
            // destinationR_Btn
            // 
            this.destinationR_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.destinationR_Btn.Location = new System.Drawing.Point(603, 145);
            this.destinationR_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.destinationR_Btn.Name = "destinationR_Btn";
            this.destinationR_Btn.Size = new System.Drawing.Size(231, 34);
            this.destinationR_Btn.TabIndex = 1;
            this.destinationR_Btn.Text = "Vyberte destinaci";
            this.destinationR_Btn.UseVisualStyleBackColor = true;
            this.destinationR_Btn.Click += new System.EventHandler(this.destinationBtn_Click);
            // 
            // batteryR_Bx
            // 
            this.batteryR_Bx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.batteryR_Bx.Location = new System.Drawing.Point(249, 148);
            this.batteryR_Bx.Margin = new System.Windows.Forms.Padding(4);
            this.batteryR_Bx.MaxLength = 3;
            this.batteryR_Bx.Name = "batteryR_Bx";
            this.batteryR_Bx.Size = new System.Drawing.Size(176, 30);
            this.batteryR_Bx.TabIndex = 0;
            this.batteryR_Bx.TextChanged += new System.EventHandler(this.batteryR_Bx_TextChanged);
            this.batteryR_Bx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batteryBx_KeyPress);
            this.batteryR_Bx.Leave += new System.EventHandler(this.batteryR_Bx_Leave);
            // 
            // CarVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 642);
            this.Controls.Add(this._carLPanel);
            this.Controls.Add(this._carRPanel);
            this.Controls.Add(this._comparePanel);
            this.Controls.Add(this._selectPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CarVision";
            this.Text = "CarVision";
            ((System.ComponentModel.ISupportInitialize)(this.carL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carR)).EndInit();
            this._comparePanel.ResumeLayout(false);
            this._comparePanel.PerformLayout();
            this._carLPanel.ResumeLayout(false);
            this._carLPanel.PerformLayout();
            this._selectPanel.ResumeLayout(false);
            this._selectPanel.PerformLayout();
            this._carRPanel.ResumeLayout(false);
            this._carRPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox carL;
        private System.Windows.Forms.PictureBox carR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel _comparePanel;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel _carLPanel;
        private System.Windows.Forms.Panel _selectPanel;
        private System.Windows.Forms.Button destinationSaveBtn;
        private System.Windows.Forms.Label startLbl;
        private System.Windows.Forms.Label endLbl;
        private System.Windows.Forms.Button kolinBtn;
        private System.Windows.Forms.Button kladnoBtn;
        private System.Windows.Forms.Button brnoBtn;
        private System.Windows.Forms.Button prahaBtn;
        private System.Windows.Forms.Panel _carRPanel;
        private System.Windows.Forms.Label consumeR_Lbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label capacityR_Lbl;
        private System.Windows.Forms.Label reachR_Lbl;
        private System.Windows.Forms.Label chargeR_Lbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button destinationR_Btn;
        private System.Windows.Forms.TextBox batteryR_Bx;
        private System.Windows.Forms.Label consumeL_Lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label capacityL_Lbl;
        private System.Windows.Forms.Label reachL_Lbl;
        private System.Windows.Forms.Label chargeL_Lbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button destinationL_Btn;
        private System.Windows.Forms.TextBox batteryL_Bx;
        private System.Windows.Forms.Button toRBtn;
        private System.Windows.Forms.Button toLBtn;
    }
}