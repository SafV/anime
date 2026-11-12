using AnimeLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class AnimeForm : Form
    {
        public Anime Anime { get; private set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public AnimeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для изменения существующего аниме
        /// </summary>
        /// <param name="anime">аниме</param>
        public AnimeForm(Anime anime)
        {
            InitializeComponent();

            textBoxId.Text = anime.Id.ToString();
            textBoxTitle.Text = anime.Title;
            textBoxGenre.Text = anime.Genre;
            textBoxYear.Text = anime.Year.ToString();
            textBoxEpisodes.Text = anime.Episodes.ToString();
        }

        /// <summary>
        /// Событие Добавить
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text,out int id))
            {
                MessageBox.Show("Введите правильный ID.");
                return;
            }

            if (textBoxTitle.Text == "")
            {
                MessageBox.Show("Введите название.");
                return;
            }

            if (textBoxGenre.Text == "")
            {
                MessageBox.Show("Введите жанр.");
                return;
            }

            if (!int.TryParse(textBoxYear.Text,out int year))
            {
                MessageBox.Show("Введите правильный год.");
                return;
            }

            if (!int.TryParse(textBoxEpisodes.Text,out int episodes))
            {
                MessageBox.Show("Введите количество серий.");
                return;
            }

            Anime = new Anime(
                id,
                textBoxTitle.Text,
                textBoxGenre.Text,
                year,
                episodes
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Событие Отмена
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonCancel_Click(object sender,EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}