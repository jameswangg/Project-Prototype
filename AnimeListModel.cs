using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListRepository.Models
{
    public class AnimeListModel
    {
        public string AnimeTitle { get; set; }
        public string AnimeJapaneseName { get; set; }
        public string AnimeStudio { get; set; }
        public string AnimeStudioJapanese { get; set; }
        public int AnimePopularityScore { get; set; }
        public int AnimeRatings { get; set; }
        public int AnimeAgeGroups { get; set; }
        public int AnimeSeasonYear { get; set; }
        public DateTime CreatedDate { get; set; }

        //why AnimeListModel not working
        public AnimeListRepository.AnimeListModel ToRepositoryModel()
        {
            var repositoryModel = new AnimeListRepository.AnimeListModel
            {
                AnimeTitle = AnimeTitle,
                AnimeJapaneseName = AnimeJapaneseName,
                AnimeStudio = AnimeStudio,
                AnimeStudioJapanese = AnimeStudioJapanese,
                AnimePopularityScore = AnimePopularityScore,
                AnimeRatings = AnimeRatings,
                AnimeAgeGroups = AnimeAgeGroups,
                AnimeSeasonYear = AnimeSeasonYear

            };

            return repositoryModel;
        }

        public static AnimeListModel ToModel(AnimeListRepository.AnimeListModel respositoryModel)
        {
            var contactModel = new AnimeListModel
            {
                AnimeTitle = respositoryModel.AnimeTitle,
                AnimeJapaneseName = respositoryModel.AnimeJapaneseName,
                AnimeStudio = respositoryModel.AnimeStudio,
                AnimeStudioJapanese = respositoryModel.AnimeStudioJapanese,
                AnimePopularityScore = respositoryModel.AnimePopularityScore,
                AnimeRatings = respositoryModel.AnimeRatings,
                AnimeAgeGroups = respositoryModel.AnimeAgeGroups,
                AnimeSeasonYear = respositoryModel.AnimeSeasonYear
            };

            return contactModel;
        }
    }
}



