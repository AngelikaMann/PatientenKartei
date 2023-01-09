using System.IO;//Input/Output
using System.Text;
using System.Windows;


namespace PatientenKartei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public const string DIR_PATH = @"C:\Users\angelika\Desktop\test\";
        public const string FILE_EXT = ".txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        //In Datei wurde mit FileStream und mit Write geschrieben 
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = textBoxFileName.Text;

            if (Directory.Exists(DIR_PATH))
            {
                MessageBox.Show("Ordner existiert");
            }
            else
            {
                Directory.CreateDirectory(DIR_PATH);
            }
            using (FileStream fs = File.Create(DIR_PATH + filename + FILE_EXT))
            {
                byte[] contentConvertedToBytes = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvertedToBytes, 0, contentConvertedToBytes.Length);

            }
            MessageBox.Show("Datei wurde eingelegt");
        }
        //Die Datei wurde gelesen
        private void btnLesen_Click(object sender, RoutedEventArgs e)
        {
            string filename = textBoxFileName.Text;


            using (FileStream fs = File.OpenRead(DIR_PATH + filename + FILE_EXT))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content;
                }
            }
        }
        //Daten wurden hinzugefügt
        //ohne FileStream und mit StreamWriter 
        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = textBoxFileName.Text;
            string path = DIR_PATH + filename + FILE_EXT;

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(content);
                MessageBox.Show("Daten wurden hinzugefügt");
            }
        }

        //In Datei wurde mit FileStream mit StreamWriter geschrieben

        //private void btnWrite_Click(object sender, RoutedEventArgs e)
        //{
        //    string content = textBoxContent.Text;
        //    string filename = textBoxFileName.Text;
        //    string path = DIR_PATH + filename + FILE_EXT;
        //    using (FileStream fs = new FileStream(path, FileMode.Append))
        //    {
        //        using (StreamWriter sw = new StreamWriter(fs))
        //        {
        //            sw.WriteLine(content);
        //            MessageBox.Show("Datei wurde geschrieben");

        //        }
        //    }
        //}
    }
}
