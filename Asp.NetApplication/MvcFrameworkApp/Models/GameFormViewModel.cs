using DAL;
using Shared.Models;
using System.Collections.Generic;

namespace MvcFrameworkApp.Models
{
    public class GameFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }
        public GameModel GameModel { get; set; }
    }
}