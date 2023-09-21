namespace ELearningProject.DAL.Entities
{
    public class Carousel
    {
        public int CarouselID { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}