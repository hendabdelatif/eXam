using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eXam
{
    public class QuestionPageViewModel : INotifyPropertyChanged
    {
        private Game game;
        public QuestionPageViewModel(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            this.game = game;
            this.game.Restart();
            TrueSelected = new Command(OnTrue);
            FalseSelected = new Command(OnFalse);
            NextSelected = new Command(OnNext, OnCanExecuteNext); 
        }

        public string Question {
            get {
                return game.CurrentQuestion.Question;
            }
        }

        public string Response {
            get {
                if (game.CurrentResponse == null)
                {
                    return string.Empty;
                }
                if (game.CurrentQuestion.Answer == game.CurrentResponse)
                {
                    return "Correct!";
                }
                else
                {
                    return "Incorrect";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command TrueSelected { get; protected set; }
        public Command FalseSelected { get; protected set; }
        public Command NextSelected { get; protected set; }
        void OnTrue()
        {
            game.OnTrue();
            RaiseAllPropertiesChanged();
            NextSelected.ChangeCanExecute();
        }

        void OnFalse()
        {
            game.OnFalse();
            RaiseAllPropertiesChanged();
            NextSelected.ChangeCanExecute();
        }

        async void OnNext()
        {
            if (game.NextQuestion())
            {
                NextSelected.ChangeCanExecute();
                RaiseAllPropertiesChanged();
            }
            else
            {
                NavigationService navService = DependencyService.Get<NavigationService>();
                await navService.GotoPageAsync(AppPage.ReviewPage);

            }
        }
        bool OnCanExecuteNext()
        {
            return game.CurrentResponse.HasValue;
        }

        public void RaiseAllPropertiesChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(""));
            }
        }
    }
}
