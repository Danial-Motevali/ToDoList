﻿namespace ToDoList.Application.Settings
{
    public class HashingSetting
    {
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
    }
}
