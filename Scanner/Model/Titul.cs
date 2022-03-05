using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Model
{
    public class Titul : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public int TitulId { get; set; }
        public int StudentId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public bool TitulScanStatus { get; set; }
        public List<Keys> FirstMainScienceQuestions { get; set; }
        public List<Keys> SecondMainScienceQuestions { get; set; }
        public List<Keys> FirstAdditionalScienceQuestions { get; set; }
        public List<Keys> SecondAdditionalScienceQuestions { get; set; }
        public List<Keys> ThirdAdditionalScienceQuestions { get; set; }

    }
}
