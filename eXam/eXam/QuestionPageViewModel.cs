using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXam
{
    public class QuestionPageViewModel
    {
        Game game;
        public QuestionPageViewModel(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            this.game = game;
            this.game.Restart();
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
                if (game.CurrentQuestion.Answer == game.CurrentResponse.)
                {

                }   
            }
        }
    }
}
