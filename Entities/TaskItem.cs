using TesteTecnico.Entities.Enums;

namespace TesteTecnico.Entities
{
    public record TaskItem(Guid Id, string Title, string Description, Status Status);
}