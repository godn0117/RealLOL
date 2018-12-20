namespace LOLAPI
{
    partial class controlItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlItems));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.groupBoxMagic = new System.Windows.Forms.GroupBox();
            this.chkManaRegen = new System.Windows.Forms.CheckBox();
            this.chkMana = new System.Windows.Forms.CheckBox();
            this.chkCooldownReduction = new System.Windows.Forms.CheckBox();
            this.chkSpellDamage = new System.Windows.Forms.CheckBox();
            this.groupBoxAttack = new System.Windows.Forms.GroupBox();
            this.chkLifeSteal = new System.Windows.Forms.CheckBox();
            this.chkAttackSpeed = new System.Windows.Forms.CheckBox();
            this.chkCriticalStrike = new System.Windows.Forms.CheckBox();
            this.chkDamage = new System.Windows.Forms.CheckBox();
            this.groupBoxDefence = new System.Windows.Forms.GroupBox();
            this.chkArmor = new System.Windows.Forms.CheckBox();
            this.chkHealthRegen = new System.Windows.Forms.CheckBox();
            this.chkSpellBlock = new System.Windows.Forms.CheckBox();
            this.chkHealth = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBoxMagic.SuspendLayout();
            this.groupBoxAttack.SuspendLayout();
            this.groupBoxDefence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.groupBoxMagic);
            this.panel1.Controls.Add(this.groupBoxAttack);
            this.panel1.Controls.Add(this.groupBoxDefence);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(245, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 190);
            this.panel1.TabIndex = 1;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(27, 169);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 12);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version";
            // 
            // groupBoxMagic
            // 
            this.groupBoxMagic.Controls.Add(this.chkManaRegen);
            this.groupBoxMagic.Controls.Add(this.chkMana);
            this.groupBoxMagic.Controls.Add(this.chkCooldownReduction);
            this.groupBoxMagic.Controls.Add(this.chkSpellDamage);
            this.groupBoxMagic.Location = new System.Drawing.Point(384, 45);
            this.groupBoxMagic.Name = "groupBoxMagic";
            this.groupBoxMagic.Size = new System.Drawing.Size(159, 119);
            this.groupBoxMagic.TabIndex = 4;
            this.groupBoxMagic.TabStop = false;
            this.groupBoxMagic.Text = "마법";
            // 
            // chkManaRegen
            // 
            this.chkManaRegen.AutoSize = true;
            this.chkManaRegen.Location = new System.Drawing.Point(6, 86);
            this.chkManaRegen.Name = "chkManaRegen";
            this.chkManaRegen.Size = new System.Drawing.Size(76, 16);
            this.chkManaRegen.TabIndex = 3;
            this.chkManaRegen.Text = "마나 회복";
            this.chkManaRegen.UseVisualStyleBackColor = true;
            this.chkManaRegen.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkMana
            // 
            this.chkMana.AutoSize = true;
            this.chkMana.Location = new System.Drawing.Point(6, 64);
            this.chkMana.Name = "chkMana";
            this.chkMana.Size = new System.Drawing.Size(48, 16);
            this.chkMana.TabIndex = 2;
            this.chkMana.Text = "마나";
            this.chkMana.UseVisualStyleBackColor = true;
            this.chkMana.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkCooldownReduction
            // 
            this.chkCooldownReduction.AutoSize = true;
            this.chkCooldownReduction.Location = new System.Drawing.Point(6, 42);
            this.chkCooldownReduction.Name = "chkCooldownReduction";
            this.chkCooldownReduction.Size = new System.Drawing.Size(140, 16);
            this.chkCooldownReduction.TabIndex = 1;
            this.chkCooldownReduction.Text = "재사용 대기시간 감소";
            this.chkCooldownReduction.UseVisualStyleBackColor = true;
            this.chkCooldownReduction.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkSpellDamage
            // 
            this.chkSpellDamage.AutoSize = true;
            this.chkSpellDamage.Location = new System.Drawing.Point(6, 20);
            this.chkSpellDamage.Name = "chkSpellDamage";
            this.chkSpellDamage.Size = new System.Drawing.Size(60, 16);
            this.chkSpellDamage.TabIndex = 0;
            this.chkSpellDamage.Text = "주문력";
            this.chkSpellDamage.UseVisualStyleBackColor = true;
            this.chkSpellDamage.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // groupBoxAttack
            // 
            this.groupBoxAttack.Controls.Add(this.chkLifeSteal);
            this.groupBoxAttack.Controls.Add(this.chkAttackSpeed);
            this.groupBoxAttack.Controls.Add(this.chkCriticalStrike);
            this.groupBoxAttack.Controls.Add(this.chkDamage);
            this.groupBoxAttack.Location = new System.Drawing.Point(204, 45);
            this.groupBoxAttack.Name = "groupBoxAttack";
            this.groupBoxAttack.Size = new System.Drawing.Size(161, 119);
            this.groupBoxAttack.TabIndex = 4;
            this.groupBoxAttack.TabStop = false;
            this.groupBoxAttack.Text = "공격";
            // 
            // chkLifeSteal
            // 
            this.chkLifeSteal.AutoSize = true;
            this.chkLifeSteal.Location = new System.Drawing.Point(6, 86);
            this.chkLifeSteal.Name = "chkLifeSteal";
            this.chkLifeSteal.Size = new System.Drawing.Size(88, 16);
            this.chkLifeSteal.TabIndex = 3;
            this.chkLifeSteal.Text = "생명력 흡수";
            this.chkLifeSteal.UseVisualStyleBackColor = true;
            this.chkLifeSteal.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkAttackSpeed
            // 
            this.chkAttackSpeed.AutoSize = true;
            this.chkAttackSpeed.Location = new System.Drawing.Point(6, 64);
            this.chkAttackSpeed.Name = "chkAttackSpeed";
            this.chkAttackSpeed.Size = new System.Drawing.Size(72, 16);
            this.chkAttackSpeed.TabIndex = 2;
            this.chkAttackSpeed.Text = "공격속도";
            this.chkAttackSpeed.UseVisualStyleBackColor = true;
            this.chkAttackSpeed.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkCriticalStrike
            // 
            this.chkCriticalStrike.AutoSize = true;
            this.chkCriticalStrike.Location = new System.Drawing.Point(6, 42);
            this.chkCriticalStrike.Name = "chkCriticalStrike";
            this.chkCriticalStrike.Size = new System.Drawing.Size(60, 16);
            this.chkCriticalStrike.TabIndex = 1;
            this.chkCriticalStrike.Text = "치명타";
            this.chkCriticalStrike.UseVisualStyleBackColor = true;
            this.chkCriticalStrike.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkDamage
            // 
            this.chkDamage.AutoSize = true;
            this.chkDamage.Location = new System.Drawing.Point(6, 20);
            this.chkDamage.Name = "chkDamage";
            this.chkDamage.Size = new System.Drawing.Size(60, 16);
            this.chkDamage.TabIndex = 0;
            this.chkDamage.Text = "공격력";
            this.chkDamage.UseVisualStyleBackColor = true;
            this.chkDamage.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // groupBoxDefence
            // 
            this.groupBoxDefence.Controls.Add(this.chkArmor);
            this.groupBoxDefence.Controls.Add(this.chkHealthRegen);
            this.groupBoxDefence.Controls.Add(this.chkSpellBlock);
            this.groupBoxDefence.Controls.Add(this.chkHealth);
            this.groupBoxDefence.Location = new System.Drawing.Point(29, 45);
            this.groupBoxDefence.Name = "groupBoxDefence";
            this.groupBoxDefence.Size = new System.Drawing.Size(157, 119);
            this.groupBoxDefence.TabIndex = 3;
            this.groupBoxDefence.TabStop = false;
            this.groupBoxDefence.Text = "방어";
            // 
            // chkArmor
            // 
            this.chkArmor.AutoSize = true;
            this.chkArmor.Location = new System.Drawing.Point(6, 86);
            this.chkArmor.Name = "chkArmor";
            this.chkArmor.Size = new System.Drawing.Size(60, 16);
            this.chkArmor.TabIndex = 3;
            this.chkArmor.Text = "방어력";
            this.chkArmor.UseVisualStyleBackColor = true;
            this.chkArmor.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkHealthRegen
            // 
            this.chkHealthRegen.AutoSize = true;
            this.chkHealthRegen.Location = new System.Drawing.Point(6, 64);
            this.chkHealthRegen.Name = "chkHealthRegen";
            this.chkHealthRegen.Size = new System.Drawing.Size(76, 16);
            this.chkHealthRegen.TabIndex = 2;
            this.chkHealthRegen.Text = "체력 재생";
            this.chkHealthRegen.UseVisualStyleBackColor = true;
            this.chkHealthRegen.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkSpellBlock
            // 
            this.chkSpellBlock.AutoSize = true;
            this.chkSpellBlock.Location = new System.Drawing.Point(6, 42);
            this.chkSpellBlock.Name = "chkSpellBlock";
            this.chkSpellBlock.Size = new System.Drawing.Size(88, 16);
            this.chkSpellBlock.TabIndex = 1;
            this.chkSpellBlock.Text = "마법 저항력";
            this.chkSpellBlock.UseVisualStyleBackColor = true;
            this.chkSpellBlock.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkHealth
            // 
            this.chkHealth.AutoSize = true;
            this.chkHealth.Location = new System.Drawing.Point(6, 20);
            this.chkHealth.Name = "chkHealth";
            this.chkHealth.Size = new System.Drawing.Size(48, 16);
            this.chkHealth.TabIndex = 0;
            this.chkHealth.Text = "체력";
            this.chkHealth.UseVisualStyleBackColor = true;
            this.chkHealth.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "아이템 필터";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(330, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(136, 21);
            this.txtSearch.TabIndex = 0;
            // 
            // listView1
            // 
            
            this.listView1.Location = new System.Drawing.Point(29, 270);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(993, 391);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listView1.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView1_ItemMouseHover);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            
            this.pictureBox1.Location = new System.Drawing.Point(29, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(817, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(205, 190);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 

            this.pictureBox3.Location = new System.Drawing.Point(245, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(559, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // controlItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "controlItems";
            this.Size = new System.Drawing.Size(1057, 674);
            this.Load += new System.EventHandler(this.controlItems_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxMagic.ResumeLayout(false);
            this.groupBoxMagic.PerformLayout();
            this.groupBoxAttack.ResumeLayout(false);
            this.groupBoxAttack.PerformLayout();
            this.groupBoxDefence.ResumeLayout(false);
            this.groupBoxDefence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDefence;
        private System.Windows.Forms.CheckBox chkArmor;
        private System.Windows.Forms.CheckBox chkHealthRegen;
        private System.Windows.Forms.CheckBox chkSpellBlock;
        private System.Windows.Forms.CheckBox chkHealth;
        private System.Windows.Forms.GroupBox groupBoxMagic;
        private System.Windows.Forms.CheckBox chkManaRegen;
        private System.Windows.Forms.CheckBox chkMana;
        private System.Windows.Forms.CheckBox chkCooldownReduction;
        private System.Windows.Forms.CheckBox chkSpellDamage;
        private System.Windows.Forms.GroupBox groupBoxAttack;
        private System.Windows.Forms.CheckBox chkLifeSteal;
        private System.Windows.Forms.CheckBox chkAttackSpeed;
        private System.Windows.Forms.CheckBox chkCriticalStrike;
        private System.Windows.Forms.CheckBox chkDamage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
