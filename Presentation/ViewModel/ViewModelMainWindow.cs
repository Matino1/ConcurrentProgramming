using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelMainWindow : INotifyPropertyChanged
    {
        private ModelAPI modelApi;
        private readonly double scale = 5.35;
        public ObservableCollection<BallInModel> Balls { get; set; }
        public ICommand StartButtonClick { get; set; }
        private string inputText;

        public string InputText
        {
            get
            {
                return inputText;
            }
            set
            {
                inputText = value;
                RaisePropertyChanged(nameof(InputText));
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get 
            { 
                return errorMessage; 
            }
            set 
            { 
                errorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelMainWindow() : this(ModelAPI.CreateApi())
        {

        }

        public ViewModelMainWindow(ModelAPI baseModel)
        {
            this.modelApi = baseModel;
            StartButtonClick = new RelayCommand(() => StartButtonClickHandler());
            Balls = new ObservableCollection<BallInModel>();
        }

        private void StartButtonClickHandler()
        {
            modelApi.AddBallsAndStart(readFromTextBox());

            Task.Run(() => {
                Balls.Clear();
                foreach (BallInModel ball in modelApi.Balls)
                {
                    Balls.Add(ball);
                }
                RaisePropertyChanged(nameof(Balls));
            });
            
        }

        public int readFromTextBox()
        {
            int number;
            if (Int32.TryParse(InputText, out number))
            {
                number = Int32.Parse(InputText);
                ErrorMessage = "";
                if (number > 100)
                {
                    return 100;
                }
                return number;
            }
            ErrorMessage = "Nieprawidłowa liczba";
            return 0;
        }
             
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}