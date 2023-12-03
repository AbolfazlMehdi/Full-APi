using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Users
    {
        public Users()
        {
            IsDeleted = false;
        }


        [Key]
        public int UserId { get; set; }
        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public byte Age { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}


public class UserDTO
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MobileNumber { get; set; }

    public byte Age { get; set; }


}