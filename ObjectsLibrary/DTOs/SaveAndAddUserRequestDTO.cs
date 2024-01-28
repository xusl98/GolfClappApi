using iMasterLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class SaveAndAddUserRequestDTO
    {
        public string Date { get; set; }
        public string? CourseId { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public double PricePerPart { get; set; }
        public int ProviderCourseId { get; set; }
        public string CreatorUserClientSecret { get; set; }
        public List<Rate> PackageCombination { get; set; }
        public List<Guid> UsersIds { get; set; }
        public int NonUserPlayers { get; set; }
        public int NumberOfPlayers { get; set; }
        public List<Guid> PayedUsersIds { get; set; }



    }
}
