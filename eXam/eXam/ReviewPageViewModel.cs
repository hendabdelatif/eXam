using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXam
{

    public class ReviewPageViewModel
    {
        private Game game;
        public ReviewPageViewModel(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            this.game = game;

            QuestionViewModels = new List<QuizQuestionViewModel>(game.NumberOfQuestions);
            for (int i = 0; i < game.NumberOfQuestions; i++)
            {
                QuestionViewModels.Add(new QuizQuestionViewModel(game.Questions[i], game.Responses[i]));
            }

        }

        public List<QuizQuestionViewModel> QuestionViewModels { get; set; }

       
    }
}
