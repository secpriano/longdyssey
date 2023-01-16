using WebApplication.Models.SpaceshipModels;

namespace WebApplication.Models.Dienstregeling
{
    public class DienstregelingViewModel
    {
        public List<AstronomicalObjectModel> AstronomicalObjects { get; set; }
        public List<SpaceshipModel> Spaceships { get; set; }
        public string Name { get; set; }
        public string SpaceshipName { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }

        public DienstregelingViewModel(List<AstronomicalObjectModel> astronomicalObjects, List<SpaceshipModel> spaceships)
        {
            AstronomicalObjects = astronomicalObjects;
            Spaceships = spaceships;
        }

        public DienstregelingViewModel()
        {

        }
    }
}
