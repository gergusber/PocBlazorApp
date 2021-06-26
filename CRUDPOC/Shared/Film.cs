﻿using System;

namespace CRUDPOC.Shared
{
    [Serializable]
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}