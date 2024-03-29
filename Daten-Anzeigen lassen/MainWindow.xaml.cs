﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Daten_Anzeigen_lassen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           
        }
        string UP_TourGA = "ihr Pfad";
        string UP_TourKFZ = "ihr Pfad";
        string UP_AUFT_NB = "ihr Pfad";
        string UP_Alle = "ihr Pfad";
        string UP_KFZ = "ihr Pfad";
        string offenelink = "ihr Pfad";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtbox1.Clear();
            if (MeineComboBox.SelectedIndex == 0)
            {
                string[] lines = File.ReadAllLines(offenelink);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 8)
                    {
                        string datePart = parts[6];
                        string timePart = parts[7];
                        DateTime recordDateTime;
                        if (DateTime.TryParse($"{datePart} {timePart}", out recordDateTime))
                        {
                            TimeSpan difference = DateTime.Now - recordDateTime;
                            if (difference.TotalHours > 1)
                            {
                                txtbox1.Text = line;
                            }
                            else
                            {
                                MessageBox.Show("Fehler");
                            }
                        }
                    }
                }
            }
            else if (MeineComboBox.SelectedIndex == 1)
            {
                System.Diagnostics.Process.Start(UP_TourGA);
            }
            else if (MeineComboBox.SelectedIndex == 2)
            {
                System.Diagnostics.Process.Start(UP_TourKFZ);
            }
            else if (MeineComboBox.SelectedIndex == 3)
            {
                System.Diagnostics.Process.Start(UP_AUFT_NB);
            }
            else if (MeineComboBox.SelectedIndex == 4)
            {
                System.Diagnostics.Process.Start(UP_Alle);
            }
            else if (MeineComboBox.SelectedIndex == 5)
            {
                System.Diagnostics.Process.Start(UP_KFZ);
            }
        }

    }
}
