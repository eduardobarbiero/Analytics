﻿using System;

namespace Application.Domain.Domain
{
    public class Value : Entity<long>
    {
        public Value()
        {
        }

        public long Id { get; set; }


        public string Name { get; set; }


    }
}
