using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Prog3_Practis3._1
{
    public class ModelStundent : INotifyPropertyChanged
    {
        private int matNr;

        private string name;

        public int MatNumber
        {
            set
            {
                matNr = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventHandler(nameof(MatNumber));
            }
            get
            {
                return matNr;
            }
        }

        public string Name
        {
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventHandler(nameof(Name)));
            }
            get { return name; }
        }


        public ModelStundent(int mat, string name)
        {
            this.matNr = mat;
            this.name = name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
