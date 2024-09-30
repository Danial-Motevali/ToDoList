﻿using ToDoList.Application.DTO.Base_Dto;
using ToDoList.Application.Feature.Command;

namespace ToDoList.Application.DTO.EndPointsDto
{
    public class RegisterInputDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
