namespace RepairMobilePhones
{
    partial class AddForm
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
            this.components = new System.ComponentModel.Container();
            this.dateLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.phoneModelLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.Savebutton = new System.Windows.Forms.Button();
            this.textBox_date = new System.Windows.Forms.TextBox();
            this.textBox_contact = new System.Windows.Forms.TextBox();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTipDate = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipContact = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.Location = new System.Drawing.Point(27, 122);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(131, 25);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Дата подачі:";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contactLabel.Location = new System.Drawing.Point(27, 164);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(195, 25);
            this.contactLabel.TabIndex = 1;
            this.contactLabel.Text = "Контактний номер:";
            // 
            // phoneModelLabel
            // 
            this.phoneModelLabel.AutoSize = true;
            this.phoneModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneModelLabel.Location = new System.Drawing.Point(27, 206);
            this.phoneModelLabel.Name = "phoneModelLabel";
            this.phoneModelLabel.Size = new System.Drawing.Size(191, 25);
            this.phoneModelLabel.TabIndex = 2;
            this.phoneModelLabel.Text = "Модель телефону:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(27, 240);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(165, 25);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Опис проблеми:";
            // 
            // Savebutton
            // 
            this.Savebutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Savebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Savebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Savebutton.Location = new System.Drawing.Point(336, 409);
            this.Savebutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(160, 40);
            this.Savebutton.TabIndex = 4;
            this.Savebutton.Text = "Зберегти";
            this.Savebutton.UseVisualStyleBackColor = false;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // textBox_date
            // 
            this.textBox_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_date.Location = new System.Drawing.Point(336, 122);
            this.textBox_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(447, 30);
            this.textBox_date.TabIndex = 5;
            this.toolTipDate.SetToolTip(this.textBox_date, "Формат вводу дати: dd.mm.yyyy");
            // 
            // textBox_contact
            // 
            this.textBox_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_contact.Location = new System.Drawing.Point(336, 164);
            this.textBox_contact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_contact.Name = "textBox_contact";
            this.textBox_contact.Size = new System.Drawing.Size(447, 30);
            this.textBox_contact.TabIndex = 6;
            this.toolTipContact.SetToolTip(this.textBox_contact, "Формат вводу номеру: +380-XX-XXX-XX-XX");
            // 
            // textBox_phone
            // 
            this.textBox_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_phone.Location = new System.Drawing.Point(336, 206);
            this.textBox_phone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(447, 30);
            this.textBox_phone.TabIndex = 7;
            // 
            // textBox_description
            // 
            this.textBox_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_description.Location = new System.Drawing.Point(336, 240);
            this.textBox_description.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_description.Size = new System.Drawing.Size(447, 156);
            this.textBox_description.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 70);
            this.panel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(288, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "Створення заявки";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 474);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.textBox_phone);
            this.Controls.Add(this.textBox_contact);
            this.Controls.Add(this.textBox_date);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.phoneModelLabel);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.dateLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddForm";
            this.Text = "Додавання запису";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.Label phoneModelLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.TextBox textBox_date;
        private System.Windows.Forms.TextBox textBox_contact;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTipContact;
        private System.Windows.Forms.ToolTip toolTipDate;
    }
}