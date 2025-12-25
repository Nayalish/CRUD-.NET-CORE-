using System.ComponentModel;

namespace CRUD2025.Models
{
    public class user
    {
        public int ID { get; set; }
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        [DisplayName("Education")]
        public string Education { get; set; }

        public int Age { get; set; }
    }
}
