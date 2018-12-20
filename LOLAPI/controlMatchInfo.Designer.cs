namespace LOLAPI
{
    partial class controlMatchInfo
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlMatchInfo));
            this.dgvBlueTeam = new System.Windows.Forms.DataGridView();
            this.dgvRedTeam = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRedSumKDA = new System.Windows.Forms.Label();
            this.lblRedSumDTaken = new System.Windows.Forms.Label();
            this.lblRedSumDeal = new System.Windows.Forms.Label();
            this.lblRedSumGold = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBlueSumKDA = new System.Windows.Forms.Label();
            this.lblBlueSumDTaken = new System.Windows.Forms.Label();
            this.lblBlueSumGold = new System.Windows.Forms.Label();
            this.lblBlueSumDeal = new System.Windows.Forms.Label();
            this.txtGameTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlueTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedTeam)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBlueTeam
            // 
            this.dgvBlueTeam.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvBlueTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlueTeam.Location = new System.Drawing.Point(4, 47);
            this.dgvBlueTeam.Name = "dgvBlueTeam";
            this.dgvBlueTeam.RowTemplate.Height = 23;
            this.dgvBlueTeam.Size = new System.Drawing.Size(805, 176);
            this.dgvBlueTeam.TabIndex = 0;
            // 
            // dgvRedTeam
            // 
            this.dgvRedTeam.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvRedTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRedTeam.Location = new System.Drawing.Point(4, 330);
            this.dgvRedTeam.Name = "dgvRedTeam";
            this.dgvRedTeam.RowTemplate.Height = 23;
            this.dgvRedTeam.Size = new System.Drawing.Size(805, 176);
            this.dgvRedTeam.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(751, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 41);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(265, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "< 매치 상세 정보 >";
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWin.ForeColor = System.Drawing.Color.White;
            this.lblWin.Location = new System.Drawing.Point(12, 9);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(0, 27);
            this.lblWin.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleVioletRed;
            this.groupBox1.Controls.Add(this.lblRedSumKDA);
            this.groupBox1.Controls.Add(this.lblRedSumDTaken);
            this.groupBox1.Controls.Add(this.lblRedSumDeal);
            this.groupBox1.Controls.Add(this.lblRedSumGold);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(496, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 95);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "레드팀";
            // 
            // lblRedSumKDA
            // 
            this.lblRedSumKDA.AutoSize = true;
            this.lblRedSumKDA.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRedSumKDA.Location = new System.Drawing.Point(145, 55);
            this.lblRedSumKDA.Name = "lblRedSumKDA";
            this.lblRedSumKDA.Size = new System.Drawing.Size(51, 15);
            this.lblRedSumKDA.TabIndex = 7;
            this.lblRedSumKDA.Text = "label6";
            // 
            // lblRedSumDTaken
            // 
            this.lblRedSumDTaken.AutoSize = true;
            this.lblRedSumDTaken.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRedSumDTaken.Location = new System.Drawing.Point(146, 25);
            this.lblRedSumDTaken.Name = "lblRedSumDTaken";
            this.lblRedSumDTaken.Size = new System.Drawing.Size(38, 12);
            this.lblRedSumDTaken.TabIndex = 6;
            this.lblRedSumDTaken.Text = "label7";
            // 
            // lblRedSumDeal
            // 
            this.lblRedSumDeal.AutoSize = true;
            this.lblRedSumDeal.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRedSumDeal.Location = new System.Drawing.Point(10, 25);
            this.lblRedSumDeal.Name = "lblRedSumDeal";
            this.lblRedSumDeal.Size = new System.Drawing.Size(38, 12);
            this.lblRedSumDeal.TabIndex = 4;
            this.lblRedSumDeal.Text = "label9";
            // 
            // lblRedSumGold
            // 
            this.lblRedSumGold.AutoSize = true;
            this.lblRedSumGold.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRedSumGold.Location = new System.Drawing.Point(10, 55);
            this.lblRedSumGold.Name = "lblRedSumGold";
            this.lblRedSumGold.Size = new System.Drawing.Size(38, 12);
            this.lblRedSumGold.TabIndex = 5;
            this.lblRedSumGold.Text = "label8";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox2.Controls.Add(this.lblBlueSumKDA);
            this.groupBox2.Controls.Add(this.lblBlueSumDTaken);
            this.groupBox2.Controls.Add(this.lblBlueSumGold);
            this.groupBox2.Controls.Add(this.lblBlueSumDeal);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(5, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 95);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "블루팀";
            // 
            // lblBlueSumKDA
            // 
            this.lblBlueSumKDA.AutoSize = true;
            this.lblBlueSumKDA.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBlueSumKDA.Location = new System.Drawing.Point(144, 55);
            this.lblBlueSumKDA.Name = "lblBlueSumKDA";
            this.lblBlueSumKDA.Size = new System.Drawing.Size(51, 15);
            this.lblBlueSumKDA.TabIndex = 3;
            this.lblBlueSumKDA.Text = "label5";
            // 
            // lblBlueSumDTaken
            // 
            this.lblBlueSumDTaken.AutoSize = true;
            this.lblBlueSumDTaken.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBlueSumDTaken.Location = new System.Drawing.Point(145, 25);
            this.lblBlueSumDTaken.Name = "lblBlueSumDTaken";
            this.lblBlueSumDTaken.Size = new System.Drawing.Size(38, 12);
            this.lblBlueSumDTaken.TabIndex = 2;
            this.lblBlueSumDTaken.Text = "label4";
            // 
            // lblBlueSumGold
            // 
            this.lblBlueSumGold.AutoSize = true;
            this.lblBlueSumGold.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBlueSumGold.Location = new System.Drawing.Point(9, 55);
            this.lblBlueSumGold.Name = "lblBlueSumGold";
            this.lblBlueSumGold.Size = new System.Drawing.Size(38, 12);
            this.lblBlueSumGold.TabIndex = 1;
            this.lblBlueSumGold.Text = "label3";
            // 
            // lblBlueSumDeal
            // 
            this.lblBlueSumDeal.AutoSize = true;
            this.lblBlueSumDeal.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBlueSumDeal.Location = new System.Drawing.Point(9, 25);
            this.lblBlueSumDeal.Name = "lblBlueSumDeal";
            this.lblBlueSumDeal.Size = new System.Drawing.Size(38, 12);
            this.lblBlueSumDeal.TabIndex = 0;
            this.lblBlueSumDeal.Text = "label2";
            // 
            // txtGameTime
            // 
            this.txtGameTime.BackColor = System.Drawing.Color.Gray;
            this.txtGameTime.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGameTime.ForeColor = System.Drawing.Color.White;
            this.txtGameTime.Location = new System.Drawing.Point(324, 229);
            this.txtGameTime.Multiline = true;
            this.txtGameTime.Name = "txtGameTime";
            this.txtGameTime.Size = new System.Drawing.Size(166, 95);
            this.txtGameTime.TabIndex = 10;
            this.txtGameTime.Text = "\r\n";
            // 
            // controlMatchInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGameTime);
            this.Controls.Add(this.lblWin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRedTeam);
            this.Controls.Add(this.dgvBlueTeam);
            this.DoubleBuffered = true;
            this.Name = "controlMatchInfo";
            this.Size = new System.Drawing.Size(812, 506);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlueTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedTeam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvBlueTeam;
        public System.Windows.Forms.DataGridView dgvRedTeam;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblRedSumKDA;
        public System.Windows.Forms.Label lblRedSumDTaken;
        public System.Windows.Forms.Label lblRedSumDeal;
        public System.Windows.Forms.Label lblRedSumGold;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label lblBlueSumKDA;
        public System.Windows.Forms.Label lblBlueSumDTaken;
        public System.Windows.Forms.Label lblBlueSumGold;
        public System.Windows.Forms.Label lblBlueSumDeal;
        public System.Windows.Forms.TextBox txtGameTime;
    }
}
