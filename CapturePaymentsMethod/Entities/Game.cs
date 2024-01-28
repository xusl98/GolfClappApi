using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapturePaymentsMethod.Entities
{

    public class Game
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public int ProviderCourseId { get; set; }
        public int Holes { get; set; }
        public int NumberOfPlayers { get; set; }
        public string PackageCombination { get; set; }
        public string CreatorUserClientSecret { get; set; }
        public Guid? Creator { get; set; }
        public bool FullyPaid { get; set; }


    }
}
