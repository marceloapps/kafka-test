using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;

namespace TimeManagement
{
    class BookingProducer : IBookingProducer
    {
        public void Produce(string message)
        {
            var conf = new ProducerConfig { BootstrapServers = "localhost:9092" };

            Action<DeliveryReport<Null, string>> handler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");

            using (var p = new ProducerBuilder<Null, string>(conf).Build())
            {
                p.Produce("timemanagement_booking", new Message<Null, string> { Value = message }, handler);

                // wait for up to 10 seconds for any inflight messages to be delivered.
                p.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}
