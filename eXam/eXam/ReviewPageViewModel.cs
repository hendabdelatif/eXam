using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXam
{
    public class ReviewPageViewModel
    {
        public ReviewPageViewModel(Game game)
        {
            QuestionViewModels = new List<QuizQuestionViewModel>(game.NumberOfQuestions);
            for (int i = 0; i < game.NumberOfQuestions-1; i++)
            {
                QuestionViewModels.Add(new QuizQuestionViewModel(game.Questions[i], game.Responses[i]));
            }
        }

        public List<QuizQuestionViewModel> QuestionViewModels { get; set; }
    }
}
