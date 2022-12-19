namespace LongdysseyWebApplication.Models.Dienstregeling
{
    public class DienstregelingViewModel
    {
        public List<AstronomicalObjectModel> AstronomicalObjects { get; set; }

        public DienstregelingViewModel(List<AstronomicalObjectModel> astronomicalObjects)
        {
            AstronomicalObjects = astronomicalObjects;
        }
    }
}
