
using System.Runtime.Serialization.Json;
using System.Text.Json;
using Models;

namespace CS_Lab1_2
{


    public partial class MainForm : Form
    {
        List<Track> tracks = new List<Track>();
        List<Models.Author> authorList = new List<Models.Author>();
        List<Models.Genre> genreList = new List<Models.Genre>();
        List<Models.Album> albumList = new List<Models.Album>();
        BindingSource source = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            source.DataSource = tracks;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();

        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            IOrderedEnumerable<Track>? result;
            switch (sortCBox.SelectedIndex)
            {
                case 0:
                    if (ascRButton.Checked)
                    {
                        result = from Track in tracks orderby Track.album select Track;
                    }
                    else
                    {
                        result = from Track in tracks orderby Track.album descending select Track;
                    }
                    source.DataSource = null;
                    tracksGrid.DataSource = null;
                    source.DataSource = result.ToList<Track>();
                    tracksGrid.DataSource = source;
                    tracksGrid.AutoResizeColumns();
                    tracksGrid.AutoResizeRows();
                    break;

                case 1:
                    if (ascRButton.Checked)
                    {
                        result = from Track in tracks orderby Track.author select Track;
                    }
                    else
                    {
                        result = from Track in tracks orderby Track.author descending select Track;
                    }
                    source.DataSource = null;
                    tracksGrid.DataSource = null;
                    source.DataSource = result.ToList();
                    tracksGrid.DataSource = source;
                    tracksGrid.AutoResizeColumns();
                    tracksGrid.AutoResizeRows();
                    break;

                case 2:
                    if (ascRButton.Checked)
                    {
                        result = from Track in tracks orderby Track.genre select Track;
                    }
                    else
                    {
                        result = from Track in tracks orderby Track.genre descending select Track;
                    }
                    source.DataSource = null;
                    tracksGrid.DataSource = null;
                    source.DataSource = result.ToList();
                    tracksGrid.DataSource = source;
                    tracksGrid.AutoResizeColumns();
                    tracksGrid.AutoResizeRows();
                    break;

                case 3:
                    if (ascRButton.Checked)
                    {
                        result = from Track in tracks orderby Track.name select Track;
                    }
                    else
                    {
                        result = from Track in tracks orderby Track.name descending select Track;
                    }
                    source.DataSource = null;
                    tracksGrid.DataSource = null;
                    source.DataSource = result.ToList();
                    tracksGrid.DataSource = source;
                    tracksGrid.AutoResizeColumns();
                    tracksGrid.AutoResizeRows();
                    break;

                default:
                    if (ascRButton.Checked)
                    {
                        result = from Track in tracks orderby Track.album select Track;
                    }
                    else
                    {
                        result = from Track in tracks orderby Track.album descending select Track;
                    }
                    source.DataSource = null;
                    tracksGrid.DataSource = null;
                    source.DataSource = result.ToList();
                    tracksGrid.DataSource = source;
                    tracksGrid.AutoResizeColumns();
                    tracksGrid.AutoResizeRows();
                    break;
            }
        }

        private void EditTracksButton_Click(object sender, EventArgs e)
        {
            TracksEditForm tef = new TracksEditForm(ref tracks, ref authorList, ref genreList, ref albumList);
            tef.ShowDialog();
            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            tracks = Track.getFromDB();
            authorList = Author.synchronizeWithDB();
            genreList = Genre.synchronizeWithDB();
            albumList = Album.synchronizeWithDB();
            source.DataSource = tracks;
            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
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

        private void editAuthorsButton_Click(object sender, EventArgs e)
        {
            EditAuthorsForm editAuthorsForm = new EditAuthorsForm(ref authorList);
            editAuthorsForm.ShowDialog();
            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }

        private void editAlbumsButton_Click(object sender, EventArgs e)
        {
            EditAlbumsForm editAlbumsForm = new EditAlbumsForm(ref albumList, ref authorList);
            editAlbumsForm.ShowDialog();
            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }

        private void editGenresButton_Click(object sender, EventArgs e)
        {
            EditGenresForm editGenresForm = new EditGenresForm(ref genreList);
            editGenresForm.ShowDialog();
            tracksGrid.DataSource = null;
            tracksGrid.DataSource = source;
            tracksGrid.AutoResizeColumns();
            tracksGrid.AutoResizeRows();
        }
        private void linksButton_Click_1(object sender, EventArgs e)
        {
            var linksForm = new LinksForm(ref albumList);
            linksForm.ShowDialog();
        }
    }

}