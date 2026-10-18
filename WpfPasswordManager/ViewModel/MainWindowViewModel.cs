using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using WpfPasswordManager.MVVM;

namespace WpfPasswordManager.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string dbPath = Path.Combine(projectDirectory + "\\DB\\data.db");
            if (File.Exists(dbPath))
            {
                try
                {
                    using var connection = new SqliteConnection(@"Data Source=" + dbPath);
                    connection.Open();

                    Console.WriteLine("Connected to the SQLite database!");

                }
                catch (SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Database not found, would you like to create a new one?", "DB not found!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using var connection = new SqliteConnection(@"Data Source=" + dbPath);
                        connection.Open();

                        Console.WriteLine("Connected to the SQLite database!");
                    }
                    catch (SqliteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }
        }

    }
}
