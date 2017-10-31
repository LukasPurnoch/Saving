using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using FileHelpers;



namespace Saving
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>

    


    //[DelimitedRecord(",")]
    public partial class MainWindow : Window
    {
        List<Score> score = new List<Score>();
        ObservableCollection<int> scoreListView = new ObservableCollection<int>();
        ObservableCollection<int> savescore = new ObservableCollection<int>();

        public MainWindow()
        {
            InitializeComponent();

            Score test = new Score();
            test.SCORE += 69;

            score.Add(test);

            CSVWrite();

            CSVRead();
        }
        public void CSVWrite()
        {
            var engine = new FileHelperEngine<Score>();
            engine.WriteFile("FileSave.csv", score);
        }

        public void CSVRead()
        {
            var engine = new FileHelperEngine<Score>();
            var result = engine.ReadFile("FileSave.csv");

            foreach (Score points in result)
            {
                scoreListView.Add(points.SCORE);
            }
            LIST.ItemsSource = scoreListView;

        }

       
    }
}
