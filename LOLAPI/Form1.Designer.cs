namespace LOLAPI
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRune = new System.Windows.Forms.Button();
            this.btnSpell = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnChampion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExitApi = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.controlSpell1 = new LOLAPI.controlSpell();
            this.controlRune1 = new LOLAPI.controlRune();
            this.controlItems1 = new LOLAPI.controlItems();
            this.controlChampion1 = new LOLAPI.ControlChampion();
            this.mainControl1 = new LOLAPI.MainControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnRune);
            this.panel1.Controls.Add(this.btnSpell);
            this.panel1.Controls.Add(this.btnItem);
            this.panel1.Controls.Add(this.btnChampion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 676);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Turquoise;
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 167);
            this.panel3.TabIndex = 6;
            this.panel3.Visible = false;
            // 
            // btnRune
            // 
            this.btnRune.BackColor = System.Drawing.Color.Gray;
            this.btnRune.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRune.Location = new System.Drawing.Point(0, 512);
            this.btnRune.Name = "btnRune";
            this.btnRune.Size = new System.Drawing.Size(153, 175);
            this.btnRune.TabIndex = 3;
            this.btnRune.Text = " 룬\r\n(rune)";
            this.btnRune.UseVisualStyleBackColor = false;
            this.btnRune.Click += new System.EventHandler(this.btnRune_Click);
            // 
            // btnSpell
            // 
            this.btnSpell.BackColor = System.Drawing.Color.Gray;
            this.btnSpell.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSpell.Location = new System.Drawing.Point(0, 342);
            this.btnSpell.Name = "btnSpell";
            this.btnSpell.Size = new System.Drawing.Size(153, 175);
            this.btnSpell.TabIndex = 2;
            this.btnSpell.Text = " 스펠\r\n(spell)\r\n";
            this.btnSpell.UseVisualStyleBackColor = false;
            this.btnSpell.Click += new System.EventHandler(this.btnSpell_Click);
            // 
            // btnItem
            // 
            this.btnItem.BackColor = System.Drawing.Color.Gray;
            this.btnItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnItem.Location = new System.Drawing.Point(0, 172);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(153, 175);
            this.btnItem.TabIndex = 1;
            this.btnItem.Text = " 아이템\r\n ( item )";
            this.btnItem.UseVisualStyleBackColor = false;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // btnChampion
            // 
            this.btnChampion.BackColor = System.Drawing.Color.Gray;
            this.btnChampion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChampion.Location = new System.Drawing.Point(0, 0);
            this.btnChampion.Name = "btnChampion";
            this.btnChampion.Size = new System.Drawing.Size(153, 178);
            this.btnChampion.TabIndex = 0;
            this.btnChampion.Text = "챔피언\r\n(Champion)";
            this.btnChampion.UseVisualStyleBackColor = false;
            this.btnChampion.Click += new System.EventHandler(this.btnChampion_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.controlSpell1);
            this.panel2.Controls.Add(this.btnExitApi);
            this.panel2.Controls.Add(this.controlRune1);
            this.panel2.Controls.Add(this.controlItems1);
            this.panel2.Controls.Add(this.controlChampion1);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Controls.Add(this.mainControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(153, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1138, 676);
            this.panel2.TabIndex = 4;
            // 
            // btnExitApi
            // 
            this.btnExitApi.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnExitApi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExitApi.BackgroundImage")));
            this.btnExitApi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExitApi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExitApi.Location = new System.Drawing.Point(1087, 0);
            this.btnExitApi.Margin = new System.Windows.Forms.Padding(0);
            this.btnExitApi.Name = "btnExitApi";
            this.btnExitApi.Size = new System.Drawing.Size(49, 50);
            this.btnExitApi.TabIndex = 6;
            this.btnExitApi.UseVisualStyleBackColor = false;
            this.btnExitApi.Click += new System.EventHandler(this.btnExitApi_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.MediumBlue;
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHome.Location = new System.Drawing.Point(1025, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(59, 50);
            this.btnHome.TabIndex = 1;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // controlSpell1
            // 
            this.controlSpell1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlSpell1.BackgroundImage")));
            this.controlSpell1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlSpell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlSpell1.Location = new System.Drawing.Point(0, 0);
            this.controlSpell1.Name = "controlSpell1";
            this.controlSpell1.Size = new System.Drawing.Size(1138, 676);
            this.controlSpell1.TabIndex = 5;
            // 
            // controlRune1
            // 
            this.controlRune1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlRune1.BackgroundImage")));
            this.controlRune1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlRune1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlRune1.Location = new System.Drawing.Point(0, 0);
            this.controlRune1.Name = "controlRune1";
            this.controlRune1.Size = new System.Drawing.Size(1138, 676);
            this.controlRune1.TabIndex = 4;
            // 
            // controlItems1
            // 
            this.controlItems1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlItems1.BackgroundImage")));
            this.controlItems1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlItems1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlItems1.Location = new System.Drawing.Point(0, 0);
            this.controlItems1.Name = "controlItems1";
            this.controlItems1.Size = new System.Drawing.Size(1138, 676);
            this.controlItems1.TabIndex = 3;
            // 
            // controlChampion1
            // 
            this.controlChampion1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlChampion1.BackgroundImage")));
            this.controlChampion1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlChampion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlChampion1.Location = new System.Drawing.Point(0, 0);
            this.controlChampion1.Name = "controlChampion1";
            this.controlChampion1.Size = new System.Drawing.Size(1138, 676);
            this.controlChampion1.TabIndex = 2;
            // 
            // mainControl1
            // 
            this.mainControl1.AutoSize = true;
            this.mainControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainControl1.BackgroundImage")));
            this.mainControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainControl1.Location = new System.Drawing.Point(0, 0);
            this.mainControl1.Name = "mainControl1";
            this.mainControl1.Size = new System.Drawing.Size(1138, 676);
            this.mainControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1291, 676);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRune;
        private System.Windows.Forms.Button btnSpell;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnChampion;
        private System.Windows.Forms.Panel panel2;
        private MainControl mainControl1;
        private System.Windows.Forms.Button btnHome;
        private ControlChampion controlChampion1;
        private controlSpell controlSpell1;
        private controlRune controlRune1;
        private controlItems controlItems1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExitApi;
    }
}

