namespace WinFormsApp1
{
    partial class AnimeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelEpisodes;

        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxEpisodes;

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelId = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelEpisodes = new System.Windows.Forms.Label();

            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxEpisodes = new System.Windows.Forms.TextBox();

            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(30, 30);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(24, 15);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID:";

            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(180, 27);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(220, 23);
            this.textBoxId.TabIndex = 1;

            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(30, 70);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(65, 15);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Название:";

            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(180, 67);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(220, 23);
            this.textBoxTitle.TabIndex = 3;

            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(30, 110);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(39, 15);
            this.labelGenre.TabIndex = 4;
            this.labelGenre.Text = "Жанр:";

            // 
            // textBoxGenre
            // 
            this.textBoxGenre.Location = new System.Drawing.Point(180, 107);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(220, 23);
            this.textBoxGenre.TabIndex = 5;

            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(30, 150);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(78, 15);
            this.labelYear.TabIndex = 6;
            this.labelYear.Text = "Год выхода:";

            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(180, 147);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(220, 23);
            this.textBoxYear.TabIndex = 7;

            // 
            // labelEpisodes
            // 
            this.labelEpisodes.AutoSize = true;
            this.labelEpisodes.Location = new System.Drawing.Point(30, 190);
            this.labelEpisodes.Name = "labelEpisodes";
            this.labelEpisodes.Size = new System.Drawing.Size(127, 15);
            this.labelEpisodes.TabIndex = 8;
            this.labelEpisodes.Text = "Количество серий:";

            // 
            // textBoxEpisodes
            // 
            this.textBoxEpisodes.Location = new System.Drawing.Point(180, 187);
            this.textBoxEpisodes.Name = "textBoxEpisodes";
            this.textBoxEpisodes.Size = new System.Drawing.Size(220, 23);
            this.textBoxEpisodes.TabIndex = 9;

            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(80, 240);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(120, 40);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(230, 240);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // 
            // AnimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);

            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxEpisodes);
            this.Controls.Add(this.labelEpisodes);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelId);

            this.Name = "AnimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление аниме";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}