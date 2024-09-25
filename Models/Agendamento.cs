public class Agendamento
{
    public string ID { get; set; }
    public Paciente Paciente { get; set; }
    public Medico Medico { get; set; }
    public DateTime Data { get; set; }
}