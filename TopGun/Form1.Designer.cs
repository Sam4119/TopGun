
namespace TopGun
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrFPS = new System.Windows.Forms.Timer(this.components);
            this.pbxField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxField)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrFPS
            // 
            this.tmrFPS.Tick += new System.EventHandler(this.tmrFPS_Tick);
            // 
            // pbxField
            // 
            this.pbxField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxField.Location = new System.Drawing.Point(0, -2);
            this.pbxField.Name = "pbxField";
            this.pbxField.Size = new System.Drawing.Size(800, 454);
            this.pbxField.TabIndex = 0;
            this.pbxField.TabStop = false;
            this.pbxField.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGame);
            this.pbxField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClicks);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbxField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressControl);
            ((System.ComponentModel.ISupportInitialize)(this.pbxField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrFPS;
        private System.Windows.Forms.PictureBox pbxField;
    }
}

