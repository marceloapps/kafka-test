﻿using System;

namespace TimeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your message. Enter q for quitting");
            var message = default(string);
            while ((message = Console.ReadLine()) != "q")
            {
                var producer = new BookingProducer();
                producer.Produce(StringSerializer.jSonSerializer(message));
            }
        }
    }
}
