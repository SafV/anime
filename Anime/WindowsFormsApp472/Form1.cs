using AnimeLogic;
using DataAccessLayer;
using System;
using System.Windows.Forms;
using AnimeLogic;


namespace WinFormsApp1
{
    public partial class 
        
        
        Form1 : Form
    {
        private Logic logic;

        public Form1()
        {
            InitializeComponent();

            logic = new Logic(new EntityRepository<Anime>());

            ShowAnime();
        }

        /// <summary>
        /// ВЫводим список аниме
        /// </summary>
        private void ShowAnime()
        {
            dataGridViewAnime.DataSource = null;
            dataGridViewAnime.DataSource = logic.GetAllAnime();
        }

        /// <summary>
        /// Событие ДОБАВИТЬ АНИМЕ
        /// </summary>
        /// <param name="sender"> кнопка </param>
        /// <param name="e"> аргумент события </param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AnimeForm form = new AnimeForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                logic.AddAnime(form.Anime);
                ShowAnime();
            }
            else
            {
                MessageBox.Show("Аниме с таким ID уже существует.");
            }
        }

        /// <summary>
        /// Событие ИЗМЕНИТЬ АНИМЕ
        /// </summary>
        /// <param name="sender"> кнопка </param>
        /// <param name="e"> аргумент события</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnime.CurrentRow == null)
            {
                MessageBox.Show("Выберите аниме.");
                return;
            }

            Anime selectedAnime = (Anime)dataGridViewAnime.CurrentRow.DataBoundItem;

            AnimeForm form = new AnimeForm(selectedAnime);

            if (form.ShowDialog() == DialogResult.OK)
            {
                bool result = logic.UpdateAnime(
                    selectedAnime.Id,
                    form.Anime.Id,
                    form.Anime.Title,
                    form.Anime.Genre,
                    form.Anime.Year,
                    form.Anime.Episodes
                );

                if (result)
                {
                    ShowAnime();
                }
                else
                {
                    MessageBox.Show("ID изменить нельзя. Остальные данные можно редактировать.");
                }
            }
        }

        /// <summary>
        /// Событие УДАЛИТЬ АНИМЕ
        /// </summary>
        /// <param name="sender"> кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnime.CurrentRow == null)
            {
                MessageBox.Show("Выберите аниме.");
                return;
            }

            Anime selectedAnime = (Anime)dataGridViewAnime.CurrentRow.DataBoundItem;

            bool result = logic.DeleteAnime(selectedAnime.Id);

            if (result)
            {
                MessageBox.Show("Аниме удалено.");
                ShowAnime();
            }
        }

        /// <summary>
        /// Событие группировка по жанру
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonGenre_Click(object sender, EventArgs e)
        {
            string genre = Microsoft.VisualBasic.Interaction.InputBox("Введите жанр:", "Поиск по жанру", "");

            if (genre == "")
            {
                return;
            }

            dataGridViewAnime.DataSource = null;
            dataGridViewAnime.DataSource = logic.GetAnimeByGenre(genre);
        }

        /// <summary>
        /// Событие поиск по году
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonYear_Click(object sender, EventArgs e)
        {
            string text = Microsoft.VisualBasic.Interaction.InputBox("Введите год:", "Поиск по году", "");

            if (int.TryParse(text, out int year))
            {
                dataGridViewAnime.DataSource = null;
                dataGridViewAnime.DataSource = logic.GetAnimeAfterYear(year);
            }
            else
            {
                MessageBox.Show("Введите правильный год.");
            }
        }

        /// <summary>
        /// Обновление аниме списка и его вывод 
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ShowAnime();
        }

        /// <summary>
        /// Событие добавления аниме в список избранного только единожды
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonFavorites_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnime.CurrentRow == null)
            {
                MessageBox.Show("Выберите аниме.");
                return;
            }

            Anime selectedAnime =(Anime)dataGridViewAnime.CurrentRow.DataBoundItem;
            bool result = logic.AddToFavorites(selectedAnime.Id);

            if (result)
            {
                MessageBox.Show("Аниме добавлено в избранное!");
            }
            else
            {
                MessageBox.Show("Аниме уже в избранном.");
            }
        }

        /// <summary>
        /// Событие вывода списка избранного
        /// </summary>
        /// <param name="sender">кнопка</param>
        /// <param name="e">аргумент события</param>
        private void buttonShowFavorites_Click(object sender, EventArgs e)
        {
            dataGridViewAnime.DataSource = null;
            dataGridViewAnime.DataSource = logic.GetFavorites();
        }
    }
}

