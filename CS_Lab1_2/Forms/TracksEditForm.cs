using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Lab1_2
{

    public partial class TracksEditForm : Form
    {
        List<Track> tracks = new List<Track>();
        List<Author> authorList = new List<Author>();
        List<Genre> genreList = new List<Genre>();
        List<Album> albumList = new List<Album>();
        BindingSource source = new BindingSource();

        string name = string.Empty;

        public TracksEditForm(ref List<Track> tracks, ref List<Author> authorList, ref List<Genre> genreList, ref List<Album> albumList)
        {
            this.tracks = tracks;
            this.authorList = authorList;
            this.genreList = genreList;
            this.albumList = albumList;
            InitializeComponent();
        }
        public TracksEditForm()
        {
            InitializeComponent();
        }

        private void TracksEditForm_Load(object sender, EventArgs e)
        {
            source.DataSource = tracks;
            tracksGrid.DataSource = source;
            tracksGrid.Columns["author"].ReadOnly = true;
            tracksGrid.Columns["genre"].ReadOnly = true;
            tracksGrid.Columns["album"].ReadOnly = true;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }

        private void tracksGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Items.Clear();
            switch (tracksGrid.CurrentCell.OwningColumn.Index)
            {
                case 1:
                    foreach (Author author in authorList)
                    {
                        comboBox1.Items.Add(author.value);
                    }
                    break;
                case 4:
                    foreach (Genre item in genreList)
                    {
                        comboBox1.Items.Add(item.value);
                    }
                    break;
                case 3:

                    using (SqlConnection connection = new SqlConnection(db.connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        string author = tracksGrid.Rows[tracksGrid.CurrentCell.RowIndex].Cells[1].Value.ToString();
                        command.CommandText = $"SELECT Albums.AlbumName" +
                            $"\r\nFROM Albums" +
                            $"\r\nJOIN Authors ON Authors.AuthorId = Albums.AuthorId" +
                            $"\r\nWHERE Authors.AuthorName = '{author}'";
                        command.Connection = connection;
                        var result = command.ExecuteReader();

                        while (result.Read())
                        {
                            comboBox1.Items.Add(result.GetValue(0));
                        }
                    }
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tracksGrid.CurrentCell.OwningColumn.Index)
            {
                case 1:
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(db.connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand();
                            command.CommandText = $"DECLARE @TrackName VARCHAR(50) = '{tracks[tracksGrid.CurrentCell.RowIndex].name}'" +
                            $"\r\nDECLARE @OldAuthorName VARCHAR(50) = '{tracks[tracksGrid.CurrentCell.RowIndex].author}'" +
                            $"\r\nDECLARE @NewAuthorName VARCHAR(50) = '{comboBox1.Items[comboBox1.SelectedIndex].ToString()}'" +
                            $"\r\n" +
                            $"\r\nDECLARE @TrackId INT, @NewAuthorId INT" +
                            $"\r\nSELECT @TrackId = TrackId FROM Tracks WHERE TrackName = @TrackName" +
                            $"\r\nSELECT @NewAuthorId = AuthorId FROM Authors WHERE AuthorName = @NewAuthorName" +
                            $"\r\n" +
                            $"\r\nUPDATE Tracks" +
                            $"\r\nSET AuthorId = @NewAuthorId" +
                            $"\r\nWHERE TrackId = @TrackId AND AuthorId = (SELECT AuthorId FROM Authors WHERE AuthorName = @OldAuthorName)";
                            command.Connection = connection;
                            var result = command.ExecuteReader();

                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        tracks[tracksGrid.CurrentCell.RowIndex].author = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                        MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 4:
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(db.connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand();
                            command.CommandText = $"DECLARE @TrackName VARCHAR(50) = '{tracks[tracksGrid.CurrentCell.RowIndex].name}'" +
                                $"\r\nDECLARE @AuthorName VARCHAR(50) = '{tracks[tracksGrid.CurrentCell.RowIndex].author}'" +
                                $"\r\nDECLARE @NewGenreName VARCHAR(50) = '{comboBox1.Items[comboBox1.SelectedIndex].ToString()}'" +
                                $"\r\n" +
                                $"\r\nUPDATE Tracks" +
                                $"\r\nSET GenreId = (" +
                                $"\r\n    SELECT GenreId" +
                                $"\r\n    FROM Genres" +
                                $"\r\n    WHERE GenreName = @NewGenreName" +
                                $"\r\n)" +
                                $"\r\nWHERE TrackName = @TrackName" +
                                $"\r\nAND AuthorId = (" +
                                $"\r\n    SELECT AuthorId" +
                                $"\r\n    FROM Authors" +
                                $"\r\n    WHERE AuthorName = @AuthorName" +
                                $"\r\n);" +
                                $"\r\n";
                            command.Connection = connection;
                            var result = command.ExecuteReader();


                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        tracks[tracksGrid.CurrentCell.RowIndex].genre = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                        MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 3:
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(db.connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand();
                            MessageBox.Show($"-{tracks[tracksGrid.CurrentCell.RowIndex].name}-\n-{tracks[tracksGrid.CurrentCell.RowIndex].author}-\n-{comboBox1.Items[comboBox1.SelectedIndex].ToString()}-", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            command.CommandText = $"DECLARE @TrackName VARCHAR(50) = '{tracks[tracksGrid.CurrentCell.RowIndex].name}' -- название трека" +
                                $"\r\nDECLARE @AuthorName VARCHAR(50) = '{tracks[tracksGrid.CurrentCell.RowIndex].author}' -- имя исполнителя" +
                                $"\r\nDECLARE @AlbumName VARCHAR(50) = '{comboBox1.Items[comboBox1.SelectedIndex].ToString()}' -- новое название альбома" +
                                $"\r\n" +
                                $"\r\n-- находим id трека по его названию и id автора по его имени" +
                                $"\r\nDECLARE @TrackId INT, @AuthorId INT" +
                                $"\r\nSELECT @TrackId = TrackId, @AuthorId = Tracks.AuthorId" +
                                $"\r\nFROM Tracks" +
                                $"\r\nINNER JOIN Authors ON Tracks.AuthorId = Authors.AuthorId" +
                                $"\r\nWHERE TrackName = @TrackName AND AuthorName = @AuthorName" +
                                $"\r\n" +
                                $"\r\n-- обновляем название альбома трека" +
                                $"\r\nUPDATE Tracks" +
                                $"\r\nSET AlbumId = (SELECT AlbumId FROM Albums WHERE AlbumName = @AlbumName)" +
                                $"\r\nWHERE TrackId = @TrackId";
                            command.Connection = connection;
                            var result = command.ExecuteReader();


                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        tracks[tracksGrid.CurrentCell.RowIndex].album = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                        MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
            comboBox1.Items.Clear();
        }

        private void trackButton_Click(object sender, EventArgs e)
        {

            AddTrackForm atf = new AddTrackForm(ref tracks, ref authorList, ref genreList, ref albumList);
            atf.ShowDialog();
            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(db.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    foreach (DataGridViewRow row in tracksGrid.SelectedRows)
                    {
                        MessageBox.Show($"-{tracks[row.Index].name}-\n-{tracks[row.Index].author}-", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        command.CommandText = $"DECLARE @TrackName VARCHAR(50) = '{tracks[row.Index].name}' -- название трека" +
                            $"\r\nDECLARE @AuthorName VARCHAR(50) = '{tracks[row.Index].author}' -- имя исполнителя" +
                            $"\r\n" +
                            $"\r\n-- выбираем id автора" +
                            $"\r\nDECLARE @AuthorId INT" +
                            $"\r\nSELECT @AuthorId = AuthorId FROM Authors WHERE AuthorName = @AuthorName" +
                            $"\r\n" +
                            $"\r\n-- удаляем треки с заданным названием и исполнителем" +
                            $"\r\nDELETE FROM Tracks WHERE TrackName = @TrackName AND AuthorId = @AuthorId";
                        command.Connection = connection;
                        var result = command.ExecuteReader();
                        tracks.RemoveAt(row.Index);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }

        private void tracksGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (tracksGrid.Columns[e.ColumnIndex].HeaderText == "time")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(db.connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"DECLARE @TrackName VARCHAR(50) = '{tracks[e.RowIndex].name}' -- название трека" +
                            $"\r\nDECLARE @AuthorName VARCHAR(50) = '{tracks[e.RowIndex].author}' -- имя исполнителя" +
                            $"\r\nDECLARE @NewTime VARCHAR(10) = '{tracksGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()}' -- новое время трека" +
                            $"\r\n" +
                            $"\r\nUPDATE Tracks" +
                            $"\r\nSET Time = @NewTime" +
                            $"\r\nWHERE TrackName = @TrackName AND AuthorId = (SELECT AuthorId FROM Authors WHERE AuthorName = @AuthorName)";
                        command.Connection = connection;
                        var result = command.ExecuteReader();

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    tracks[e.RowIndex].time = tracksGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(db.connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        //MessageBox.Show($"-{tracks[e.RowIndex].name}-\n-{tracks[e.RowIndex].value}-\n-{name}-", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        command.CommandText = $"DECLARE @TrackName VARCHAR(50) = '{name}' -- название трека" +
                            $"\r\nDECLARE @AuthorName VARCHAR(50) = '{tracks[e.RowIndex].author}' -- имя автора" +
                            $"\r\nDECLARE @NewTrackName VARCHAR(50) = '{tracks[e.RowIndex].name}' -- новое название трека" +
                            $"\r\n" +
                            $"\r\nUPDATE Tracks" +
                            $"\r\nSET TrackName = @NewTrackName" +
                            $"\r\nWHERE TrackName = @TrackName" +
                            $"\r\nAND AuthorId = (SELECT AuthorId FROM Authors WHERE AuthorName = @AuthorName)";
                        command.Connection = connection;
                        var result = command.ExecuteReader();

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    //tracks[e.RowIndex].name = tracksGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    MessageBox.Show($"Changed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void tracksGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            name = tracksGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        private void filterTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterValueCB.Items.Clear();
            switch (filterTypeCB.SelectedIndex)
            {
                case 0:
                    filterValueCB.Items.AddRange((from item in authorList select item.value).ToArray());
                    break;

                case 1:
                    filterValueCB.Items.AddRange((from item in albumList select item.value).ToArray());
                    break;

                case 2:
                    filterValueCB.Items.AddRange((from item in genreList select item.value).ToArray());
                    break;

            }
        }

        private void filterValueCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (filterTypeCB.SelectedIndex)
            {
                case 0:
                    tracks = Track.getFromDB(new Author(filterValueCB.Text));
                    break;

                case 1:
                    tracks = Track.getFromDB(new Album(filterValueCB.Text));
                    break;

                case 2:
                    tracks = Track.getFromDB(new Genre(filterValueCB.Text));
                    break;

            }
            source.DataSource = null;
            tracksGrid.DataSource = null;
            source.DataSource = tracks;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }

        private void resetFiltersButton_Click(object sender, EventArgs e)
        {
            tracks = Track.getFromDB();
            source.DataSource = null;
            tracksGrid.DataSource = null;
            source.DataSource = tracks;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }
    }
}
