using ProjetDevAppli.Ctrl;
using ProjetDevAppli.DAL;
using ProjetDevAppli.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetDevAppli
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int selectedAdminId;
        int selectedBeneId;
        int selectedEspeceId;
        int selectedPlageId;
        int selectedEtudeId;
        int selectedZoneId;

        PersonneViewModel myDataObject;
        PlageViewModel plageDataObject;
        EtudeViewModel etudeDataObject;
        ZonePrelevementViewModel zonePDataObject;
        ZoneEspeceViewModel zoneEDataObject;
        ObservableCollection<PersonneViewModel> ladmins;
        ObservableCollection<PersonneViewModel> lbene;
        ObservableCollection<PlageViewModel> lplages;
        ObservableCollection<EspèceViewModel> lespèces;
        ObservableCollection<EtudeViewModel> letudes;
        ObservableCollection<ZonePrelevementViewModel> lzonesP;

        public MainWindow()
        {
            InitializeComponent();
            DALConnection.Connection();
            DALPersonne personne = new DALPersonne();
            DALPlage plage = new DALPlage();
            DALEspèce espèce = new DALEspèce();

            ladmins = ORMPersonne.listeAdmins();
            lbene = ORMPersonne.listeBenevoles();
            lplages = ORMPlage.listePlages();
            lespèces = ORMEspèce.listeEspèce();
            letudes = ORMEtude.listeEtudes();
            lzonesP = ORMZonePrelevement.listeZones();
            
            listeAdmins.ItemsSource = ladmins;
            listeBenevoles.ItemsSource = lbene;
            listePlages.ItemsSource = lplages;
            listeEspèces.ItemsSource = lespèces;
            listeEtudes.ItemsSource = letudes;
            listeAdminsSelect.ItemsSource = ladmins;
            listeEtudeSelect.ItemsSource = letudes;
            listePlageSelect.ItemsSource = lplages;
            liste2AdminSelect.ItemsSource = ladmins;
            listeZones.ItemsSource = lzonesP;
            listeEspeces.ItemsSource = lespèces;
            listeZones2.ItemsSource = lzonesP;
            listeEtudes2.ItemsSource = letudes;
            listePlages2.ItemsSource = lplages;

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void listeAdmins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeAdmins.SelectedIndex < ladmins.Count) && (listeAdmins.SelectedIndex >= 0))
            {
                selectedAdminId = (ladmins.ElementAt<PersonneViewModel>(listeAdmins.SelectedIndex)).idPersonneProperty;
            }
        }

        private void listeBenevoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeBenevoles.SelectedIndex < lbene.Count) && (listeBenevoles.SelectedIndex >= 0))
            {
                selectedBeneId = (lbene.ElementAt<PersonneViewModel>(listeBenevoles.SelectedIndex)).idPersonneProperty;
            }
        }

        private void listeEspeces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspèces.SelectedIndex < lespèces.Count) && (listeEspèces.SelectedIndex >= 0))
            {
                selectedEspeceId = (lespèces.ElementAt<EspèceViewModel>(listeEspèces.SelectedIndex)).idEspèceProperty;
            }
        }

        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lplages.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlageId = (lplages.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
            }
        }

        private void listeEtudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < letudes.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEspeceId = (letudes.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }

        private void listeZones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeZones2.SelectedIndex < lzonesP.Count) && (listeZones2.SelectedIndex >= 0))
            {
                selectedZoneId = (lzonesP.ElementAt<ZonePrelevementViewModel>(listeZones2.SelectedIndex)).idZonePrelevementProperty;
            }
        }

        private int listeAdmin2_Selection(object sender, SelectionChangedEventArgs e)
        {
            int id;
            selectedAdminId = (ladmins.ElementAt<PersonneViewModel>(listeAdmins.SelectedIndex)).idPersonneProperty;
            id = selectedAdminId;
            return id;
        }


        private void addPersonneButton_Click(object sender, EventArgs e)
        {
            int select;
            if (checkAdmin.IsChecked ?? true)
            {
                myDataObject = new PersonneViewModel();
                select = 0;
            }
            else
            {
                myDataObject = new PersonneViewModel();
                select = 1;
            }
            
            myDataObject.nomPersonneProperty = nomTextBox.Text;
            myDataObject.prénomPersonneProperty = prenomTextBox.Text;
            myDataObject.adminbénéPersonneProperty = select;
            PersonneViewModel nouveau = new PersonneViewModel(DALPersonne.getMaxIdPersonne(), myDataObject.nomPersonneProperty, myDataObject.prénomPersonneProperty, myDataObject.adminbénéPersonneProperty);
            
            if (checkAdmin.IsChecked ?? true)
            {
                ladmins.Add(nouveau);
                ORMPersonne.addPersonne(nouveau);
                listeAdmins.Items.Refresh();
            }
            else
            {
                lbene.Add(nouveau);
                ORMPersonne.addPersonne(nouveau);
                listeBenevoles.Items.Refresh();
            }
        }

        private void delBeneButton_Click(object sender, EventArgs e)
        {
            PersonneViewModel del = (PersonneViewModel)listeBenevoles.SelectedItem;
            lbene.Remove(del);
            listeBenevoles.Items.Refresh();
            ORMPersonne.deletePersonne(selectedBeneId);
        }

        private void delAdminButton_Click(object sender, EventArgs e)
        {
            PersonneViewModel del = (PersonneViewModel)listeAdmins.SelectedItem;
            ladmins.Remove(del);
            listeAdmins.Items.Refresh();
            ORMPersonne.deletePersonne(selectedAdminId);
        }

        private void addPlageButton_Click(object sender, EventArgs e)
        {
            int superficie = int.Parse(superficieTextBox.Text);

            plageDataObject = new PlageViewModel();
            plageDataObject.nomPlageProperty = nomPlageTextBox.Text;
            plageDataObject.communeProperty = communeTextBox.Text;
            plageDataObject.départementProperty = departementTextBox.Text;
            plageDataObject.superficieProperty = superficie;

            PlageViewModel nouvelle = new PlageViewModel(DALPlage.getMaxIdlage(), plageDataObject.nomPlageProperty, plageDataObject.communeProperty, plageDataObject.départementProperty, plageDataObject.superficieProperty);
            lplages.Add(nouvelle);
            ORMPlage.addPlage(nouvelle);
            listePlages.Items.Refresh();
        }

        private void addEtudeButton_Click(object sender, EventArgs e)
        {
            selectedAdminId = (ladmins.ElementAt<PersonneViewModel>(listeAdminsSelect.SelectedIndex)).idPersonneProperty;
            PersonneViewModel personne = ORMPersonne.getPersonne(selectedAdminId);

            string date = dateEtudeDatePicker.Text;
            DateTime myDate;
            DateTime current = DateTime.Now;

            etudeDataObject = new EtudeViewModel();
            etudeDataObject.nomEtudeProperty = nomEtudeTextBox.Text;
            etudeDataObject.dateEtudeProperty = DateTime.TryParse(date, out myDate) ? myDate : current;
            etudeDataObject.idPersonneProperty = personne;

            EtudeViewModel nouvelle = new EtudeViewModel(DALEtude.getMaxIdEtude(), etudeDataObject.nomEtudeProperty, etudeDataObject.dateEtudeProperty, etudeDataObject.idPersonneProperty);
            letudes.Add(nouvelle);
            ORMEtude.addEtude(nouvelle);
            listeEtudes.Items.Refresh();
        }

        private void addZonePButton_Click(object sender, EventArgs e)
        {
            selectedEtudeId = (letudes.ElementAt<EtudeViewModel>(listeEtudeSelect.SelectedIndex)).idEtudeProperty;
            EtudeViewModel etude = ORMEtude.getEtude(selectedEtudeId);

            selectedPlageId = (lplages.ElementAt<PlageViewModel>(listePlageSelect.SelectedIndex)).idPlageProperty;
            PlageViewModel plage = ORMPlage.getPlage(selectedPlageId);

            selectedAdminId = (ladmins.ElementAt<PersonneViewModel>(liste2AdminSelect.SelectedIndex)).idPersonneProperty;
            PersonneViewModel personne = ORMPersonne.getPersonne(selectedAdminId);

            int angle1 = int.Parse(Angle1TextBox.Text);
            int angle2 = int.Parse(Angle2TextBox.Text);
            int angle3 = int.Parse(Angle3TextBox.Text);
            int angle4 = int.Parse(Angle4TextBox.Text);

            zonePDataObject = new ZonePrelevementViewModel();
            zonePDataObject.idEtudeProperty = etude;
            zonePDataObject.idPlageProperty = plage;
            zonePDataObject.Angle1Property = angle1;
            zonePDataObject.Angle2Property = angle2;
            zonePDataObject.Angle3Property = angle3;
            zonePDataObject.Angle4Property = angle4;
            zonePDataObject.idPersonneProperty = personne;

            ZonePrelevementViewModel nouvelle = new ZonePrelevementViewModel(DALZonePrelevement.getMaxIdZone(), zonePDataObject.idEtudeProperty, zonePDataObject.idPlageProperty, zonePDataObject.Angle1Property, zonePDataObject.Angle2Property, zonePDataObject.Angle3Property, zonePDataObject.Angle4Property, zonePDataObject.idPersonneProperty);
            lzonesP.Add(nouvelle);
            ORMZonePrelevement.addZone(nouvelle);
            listeZones2.Items.Refresh();
        }

        private void addZoneEButton_Click(object sender, EventArgs e)
        {
            selectedEspeceId = (lespèces.ElementAt<EspèceViewModel>(listeEspeces.SelectedIndex)).idEspèceProperty;
            EspèceViewModel espece = ORMEspèce.getEspèce(selectedEspeceId);

            selectedZoneId = (lzonesP.ElementAt<ZonePrelevementViewModel>(listeZones.SelectedIndex)).idZonePrelevementProperty;
            ZonePrelevementViewModel zone = ORMZonePrelevement.getZone(selectedZoneId);

            selectedEtudeId = (letudes.ElementAt<EtudeViewModel>(listeEtudes2.SelectedIndex)).idEtudeProperty;
            EtudeViewModel etude = ORMEtude.getEtude(selectedEtudeId);

            selectedPlageId = (lplages.ElementAt<PlageViewModel>(listePlages2.SelectedIndex)).idPlageProperty;
            PlageViewModel plage = ORMPlage.getPlage(selectedPlageId);

            int nbr = int.Parse(nbrAnimaux.Text);

            zoneEDataObject = new ZoneEspeceViewModel();
            zoneEDataObject.idEspeceProperty = espece;
            zoneEDataObject.idZonePrelevementProperty = zone;
            zoneEDataObject.idEtudeProperty = etude;
            zoneEDataObject.idPlageProperty = plage;
            zoneEDataObject.nombreProperty = nbr;

            ZoneEspeceViewModel nouvelle = new ZoneEspeceViewModel(DALZoneEspece.getMaxIdZone() ,zoneEDataObject.idEspeceProperty, zoneEDataObject.idZonePrelevementProperty, zoneEDataObject.idEtudeProperty, zoneEDataObject.idPlageProperty, zoneEDataObject.nombreProperty);
            ORMZoneEspece.addZone(nouvelle);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
