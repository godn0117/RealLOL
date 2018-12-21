namespace LOLAPI
{
    partial class controlRune
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn영감 = new System.Windows.Forms.Button();
            this.btn결의 = new System.Windows.Forms.Button();
            this.btn마법 = new System.Windows.Forms.Button();
            this.btn지배 = new System.Windows.Forms.Button();
            this.btn정밀 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(46, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 12);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::LOLAPI.Properties.Resources.KakaoTalk_20181211_202916226;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.btn영감);
            this.panel1.Controls.Add(this.btn결의);
            this.panel1.Controls.Add(this.btn마법);
            this.panel1.Controls.Add(this.btn지배);
            this.panel1.Controls.Add(this.btn정밀);
            this.panel1.Location = new System.Drawing.Point(172, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 114);
            this.panel1.TabIndex = 1;
            // 
            // btn영감
            // 
            this.btn영감.Location = new System.Drawing.Point(521, 17);
            this.btn영감.Name = "btn영감";
            this.btn영감.Size = new System.Drawing.Size(100, 78);
            this.btn영감.TabIndex = 6;
            this.btn영감.UseVisualStyleBackColor = true;
            this.btn영감.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn결의
            // 
            this.btn결의.Location = new System.Drawing.Point(397, 17);
            this.btn결의.Name = "btn결의";
            this.btn결의.Size = new System.Drawing.Size(100, 78);
            this.btn결의.TabIndex = 5;
            this.btn결의.UseVisualStyleBackColor = true;
            this.btn결의.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn마법
            // 
            this.btn마법.Location = new System.Drawing.Point(270, 17);
            this.btn마법.Name = "btn마법";
            this.btn마법.Size = new System.Drawing.Size(100, 78);
            this.btn마법.TabIndex = 4;
            this.btn마법.UseVisualStyleBackColor = true;
            this.btn마법.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn지배
            // 
            this.btn지배.BackColor = System.Drawing.Color.Transparent;
            this.btn지배.Location = new System.Drawing.Point(150, 17);
            this.btn지배.Name = "btn지배";
            this.btn지배.Size = new System.Drawing.Size(100, 78);
            this.btn지배.TabIndex = 3;
            this.btn지배.UseVisualStyleBackColor = false;
            this.btn지배.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn정밀
            // 
            this.btn정밀.BackColor = System.Drawing.Color.Transparent;
            this.btn정밀.Location = new System.Drawing.Point(29, 17);
            this.btn정밀.Name = "btn정밀";
            this.btn정밀.Size = new System.Drawing.Size(100, 78);
            this.btn정밀.TabIndex = 2;
            this.btn정밀.UseVisualStyleBackColor = false;
            this.btn정밀.Click += new System.EventHandler(this.btn_Click);
            // 
            // controlRune
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LOLAPI.Properties.Resources.KakaoTalk_20181211_202916226;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVersion);
            this.Name = "controlRune";
            this.Size = new System.Drawing.Size(984, 603);
            this.Load += new System.EventHandler(this.controlRune_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn영감;
        private System.Windows.Forms.Button btn결의;
        private System.Windows.Forms.Button btn마법;
        private System.Windows.Forms.Button btn지배;
        private System.Windows.Forms.Button btn정밀;
    }
}
