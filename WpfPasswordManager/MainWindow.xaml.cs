using System.Windows;
using System.IO;
using Microsoft.Data.Sqlite;

namespace WpfPasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            DataContext = this;
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string dbPath = Path.Combine(projectDirectory + "\\DB\\data.db");
            if (File.Exists(dbPath))
            {
                txtTest.Text = "File Exists";
                try
                {
                    using var connection = new SqliteConnection(@"Data Source="+dbPath);
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
                txtTest.Text = dbPath;
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
                        txtTest.Text = ex.Message;
                    }
                }
            }
        }
    }
}