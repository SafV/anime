using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewAnime;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonGenre;
        private System.Windows.Forms.Button buttonYear;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonFavorites;
        private System.Windows.Forms.Button buttonShowFavorites;

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
            dataGridViewAnime = new DataGridView();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonGenre = new Button();
            buttonYear = new Button();
            buttonRefresh = new Button();
            buttonFavorites = new Button();
            buttonShowFavorites = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnime).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAnime
            // 
            dataGridViewAnime.AllowUserToAddRows = false;
            dataGridViewAnime.AllowUserToDeleteRows = false;
            dataGridViewAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAnime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAnime.Location = new Point(23, 27);
            dataGridViewAnime.Margin = new Padding(3, 4, 3, 4);
            dataGridViewAnime.Name = "dataGridViewAnime";
            dataGridViewAnime.ReadOnly = true;
            dataGridViewAnime.RowHeadersWidth = 51;
            dataGridViewAnime.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAnime.Size = new Size(846, 400);
            dataGridViewAnime.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 451);
            buttonAdd.Margin = new Padding(3, 4, 3, 4);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(101, 52);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(119, 451);
            buttonEdit.Margin = new Padding(3, 4, 3, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(100, 52);
            buttonEdit.TabIndex = 2;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(234, 451);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(89, 52);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonGenre
            // 
            buttonGenre.Location = new Point(340, 451);
            buttonGenre.Margin = new Padding(3, 4, 3, 4);
            buttonGenre.Name = "buttonGenre";
            buttonGenre.Size = new Size(97, 52);
            buttonGenre.TabIndex = 5;
            buttonGenre.Text = "По жанру";
            buttonGenre.UseVisualStyleBackColor = true;
            buttonGenre.Click += buttonGenre_Click;
            // 
            // buttonYear
            // 
            buttonYear.Location = new Point(453, 451);
            buttonYear.Margin = new Padding(3, 4, 3, 4);
            buttonYear.Name = "buttonYear";
            buttonYear.Size = new Size(92, 52);
            buttonYear.TabIndex = 6;
            buttonYear.Text = "По году";
            buttonYear.UseVisualStyleBackColor = true;
            buttonYear.Click += buttonYear_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(778, 451);
            buttonRefresh.Margin = new Padding(3, 4, 3, 4);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(91, 52);
            buttonRefresh.TabIndex = 7;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonFavorites
            // 
            buttonFavorites.Location = new Point(561, 451);
            buttonFavorites.Margin = new Padding(3, 4, 3, 4);
            buttonFavorites.Name = "buttonFavorites";
            buttonFavorites.Size = new Size(108, 52);
            buttonFavorites.TabIndex = 8;
            buttonFavorites.Text = "В избранное";
            buttonFavorites.UseVisualStyleBackColor = true;
            buttonFavorites.Click += buttonFavorites_Click;
            // 
            // buttonShowFavorites
            // 
            buttonShowFavorites.Location = new Point(675, 451);
            buttonShowFavorites.Margin = new Padding(3, 4, 3, 4);
            buttonShowFavorites.Name = "buttonShowFavorites";
            buttonShowFavorites.Size = new Size(97, 52);
            buttonShowFavorites.TabIndex = 9;
            buttonShowFavorites.Text = "Избранное";
            buttonShowFavorites.UseVisualStyleBackColor = true;
            buttonShowFavorites.Click += buttonShowFavorites_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 547);
            Controls.Add(buttonYear);
            Controls.Add(buttonGenre);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridViewAnime);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonFavorites);
            Controls.Add(buttonShowFavorites);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список аниме";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnime).EndInit();
            ResumeLayout(false);
        }
    }
}

