using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMDBProject.BLL.IMDBService;
using IMDBProject.Entities.DTO;
using IMDBProject.Entities.Models;
namespace IMDBProject.WinUI.UserForms
{
    public partial class DirectorForm : Form
    {
        public Director yonetmen { get; set; }
        public DirectorService _directorService;
        public FilmServices _filmServices;
        public DirectorForm()
        {
            InitializeComponent();
            _directorService = new DirectorService();
            _filmServices = new FilmServices();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            yonetmen = _directorService.GetByIdDirectorService(FilmForm._idYonetmen);
            List<DirectorRatingDTO> filmler = _directorService.GetDirectorTopFive(yonetmen);
            lblYonetmenBio.Text = _directorService.GetByIdDirectorService(FilmForm._idYonetmen).DirectorBiography;
            string year = _directorService.GetByIdDirectorService(FilmForm._idYonetmen).BirthDate.Year.ToString();
            string month = _directorService.GetByIdDirectorService(FilmForm._idYonetmen).BirthDate.Month.ToString();
            string day = _directorService.GetByIdDirectorService(FilmForm._idYonetmen).BirthDate.Day.ToString();
            lblDogumTarihi.Text = day +"-"+ month+"-" + year; 
            lblUlke.Text = _directorService.GetByIdDirectorService(FilmForm._idYonetmen).Country.CountryName;
            lblDirektorName.Text = _directorService.GetByIdDirectorService(FilmForm._idYonetmen).DirectorName+" "+ _directorService.GetByIdDirectorService(FilmForm._idYonetmen).DirectorSurname;
            pcbYonetmenResim.ImageLocation = Application.StartupPath + _directorService.GetByIdDirectorService(FilmForm._idYonetmen).PhotoUrl;
            try
            {
                pcbPopFilm1.ImageLocation = Application.StartupPath + _filmServices.GetByIdFilmService(filmler[0].FilmID).PosterUrl;
                pcbPopFilm2.ImageLocation = Application.StartupPath + _filmServices.GetByIdFilmService(filmler[1].FilmID).PosterUrl;
                pcbPopFilm3.ImageLocation = Application.StartupPath + _filmServices.GetByIdFilmService(filmler[2].FilmID).PosterUrl;
                pcbPopFilm4.ImageLocation = Application.StartupPath + _filmServices.GetByIdFilmService(filmler[3].FilmID).PosterUrl;
                pcbPopFilm5.ImageLocation = Application.StartupPath + _filmServices.GetByIdFilmService(filmler[4].FilmID).PosterUrl;

            }
            catch (Exception)
            {
                
                
            }
        }
    }
}
