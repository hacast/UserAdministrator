﻿namespace Users.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}