using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class GameUserEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public bool ExternalUser { get; set; }
        public int Score { get; set; }

        public UserEntity User { get; set; }
        public GameEntity Game { get; set; }
    }
}
