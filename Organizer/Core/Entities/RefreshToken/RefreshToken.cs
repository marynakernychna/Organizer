﻿namespace Core.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
