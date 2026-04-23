using System.ComponentModel.DataAnnotations;

namespace EventsPage.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public string Location { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}