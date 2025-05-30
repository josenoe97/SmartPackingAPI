﻿using System.ComponentModel.DataAnnotations;

namespace SmartPacking.Model
{
    public class BoxModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public int Volume => Height * Width * Length;
    }
}
