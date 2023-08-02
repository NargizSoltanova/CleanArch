using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;


ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://qwmnpfdy:Lkfkc8vt-zaX8ao1deKwpzxAeGE5eKxN@rat.rmq2.cloudamqp.com/qwmnpfdy");
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();
channel.QueueDeclare("message-queue", false, false, true);

EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("message-queue", true, consumer);
consumer.Received += (sender, e) =>
{
    var body = JsonSerializer.Deserialize<Tuple<string, string, string>>(Encoding.UTF8.GetString(e.Body.Span));
    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
    {
        Port = 587,
        Credentials = new NetworkCredential("7279uar@code.edu.az", "qlhzdoehzfoyyiwf"),
        EnableSsl = true
    };
    MailMessage message = new MailMessage("7279uar@code.edu.az", body.Item1, body.Item3, body.Item2);
    message.IsBodyHtml = true;
    smtpClient.Send(message);
};

Console.Read();