﻿namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }

        public string WorkDepartment { get; set; }
        public int WorkDepartmentID { get; set; }
    }
}
